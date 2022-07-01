using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookMyTrainApp.Codes;
using BookMyTrainApp.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace BookMyTrainApp.Controllers
{
    public class BookTicketController : Controller
    {
        private readonly TrainCodes trains = new();
        private readonly StationCodes stations = new();
        private readonly StationDistanceCodes stDists = new();
        private readonly ReachCodes reaches = new();
        private readonly PnrCodes pnrs = new();
        private readonly TicketCodes tickets = new();
        private readonly FareCodes fares = new();
        private readonly TrainStatusCodes trainStatus = new();
        private static List<Ticket> passengers = new();
        private static int pCount = 0;
        public void Session(string sessionName, string value)
        {
            HttpContext.Session.SetString(sessionName, value);
        }
        public string? Session(string sessionName)
        {
            return HttpContext.Session.GetString(sessionName);
        }
        public IActionResult Index()
        {
            try
            {
                ViewBag.stations = stations.List().Result;
                return View();
            }
            catch (Exception)
            {
                TempData["typeofmessage"] = "warning";
                TempData["Message"] = "Failed to connect with Trains Server...";
                return RedirectToAction("Index", "Home");
            }
        }
        
        [HttpPost]
        public IActionResult Search([Bind("From,To,JDate")] SearchTrains search)
        {
            ViewBag.stations = stations.List().Result;
            ViewBag.search = search;
            ViewBag.fromName = stations.GetStationByCode(search.From).Result.StationName;
            ViewBag.toName = stations.GetStationByCode(search.To).Result.StationName;
            List<Train> reqTrains = new();
            var rs = reaches.List().Result;
            foreach(var train in trains.List().Result)
            {
                var from = rs.Find(r => (r.TrainNumber == train.TrainNumber && r.StationCode == search.From));
                var to = rs.Find(r => (r.TrainNumber == train.TrainNumber && r.StationCode == search.To));
                if (from!=null && to!=null && String.Compare(from.ArrivalTime,to.ArrivalTime)<0)
                {
                    reqTrains.Add(train);
                }
            }
            return View(reqTrains);
        }
        

        
        public IActionResult Booking(int tNumber, string from, string to, string jdate, string toc)
        {
            TempData["tNumber"] = tNumber;
            TempData["from"] = from;
            TempData["to"] = to;
            TempData["jDate"] = jdate;
            TempData["toc"] = toc;
            
            if (Session("userid") == null)
            {
                return RedirectToAction("Login", "Users");
            }
            return RedirectToAction("ConfirmBooking");
        }


        public IActionResult ConfirmBooking()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Payment(IEnumerable<Ticket> ps)
        {
            try
            {
                if (ps.Count() == 0)
                {
                    return RedirectToAction("ConfirmBooking");
                }
                passengers = ps.ToList();
                foreach (var i in ps.ToList())
                {
                    if (i.PassengerName != null)
                    {
                        pCount = pCount + 1;
                    }
                }
                return RedirectToAction("Payment");
            }
            catch (Exception)
            {
                TempData["typeofmessage"] = "error";
                TempData["Message"] = "Something went wrong, unable to process your request.";
                return View("Index", "Home");
            }
        }

        public IActionResult Payment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PaymentDetails(string mobile)
        {
            try
            {
                Codes.Codes codes = new();
                AccountCodes accounts = new();
                UserCodes users = new();
                Transaction transaction = new();
                var account = accounts.List().Result.Find(a => a.Mobile == mobile);
                if (account == null)
                {
                    TempData["typeofmessage"] = "warning";
                    TempData["Message"] = "No account linked to this mobile number.";
                    return RedirectToAction("Payment");
                }
                var distance = Distance((int)TempData.Peek("tNumber"), TempData.Peek("from").ToString(), TempData.Peek("to").ToString());
                var fare = Convert.ToInt32(distance * fares.GetMoneyByCoachType(TempData.Peek("toc").ToString()).Result.Fare1) * pCount;
                TransactionCodes transactions = new();
                transaction.ToAccount = 37193472822;
                transaction.FromAccount = account.AccountNumber;
                transaction.IsPending = true;
                transaction.TransactionState = true;
                transaction.TransactionType = "D";
                transaction.TransactionReason = "For Ticket Booking";
                transaction.TransactionAmount = fare;

                var transid = transactions.AddTransaction(transaction).Result;
                string subject = "BookMyTrain App Payment Request";
                var mailbody = $"Hi {account.AccHolderName},\n\n" +
                    $"We have requested a payment request to your account." +
                    $"\nOnce payment is verified you are redirected to your Tickets." +
                    $"Note: If you haven't raised this request please contact superiors as soon as possible.\n" +
                    $"\nBest Regards,\nBookMyTrain Team";

                codes.SendEmail(subject, mailbody, users.GetUserByID(Convert.ToInt32(Session("userid"))).Result.MailId);
                Transaction? res;
                for (int i = 0; i < 150; i++)
                {
                    Thread.Sleep(2000);
                    res = transactions.GetTransactionByID(transid.TransactionId).Result;
                    if (res != null && res.IsPending == false && res.TransactionState == true)
                    {
                        Pnr pnr = new();
                        pnr.UserId = Convert.ToInt32(Session("userid"));
                        pnr.JourneyDate = DateTime.Parse(TempData["jDate"].ToString());
                        var alltreaches = reaches.List().Result.FindAll(r => r.TrainNumber == (int)TempData["tNumber"]);
                        var startTime = alltreaches.Find(r => r.StationCode == TempData["from"].ToString());
                        var endTime = alltreaches.Find(r => r.StationCode == TempData["to"].ToString());
                        pnr.JourneyStartTime = startTime.ArrivalTime;
                        pnr.JourneyEndTime = endTime.ArrivalTime;
                        pnr.NumberOfPassengers = pCount;
                        pnr.TotalFare = fare;
                        pnr.IsDeleted = false;
                        pnr.TransactionId = transid.TransactionId;
                        pnr.FromStation = TempData["from"].ToString();
                        pnr.ToStation = TempData["to"].ToString();
                        pnr.BoardingStation = pnr.FromStation;
                        pnr.TrainNumber = (int)TempData["tNumber"];
                        pnr.TypeOfCoach = TempData["toc"].ToString();
                        var newPnr = pnrs.AddPnr(pnr).Result;
                        addTickets(newPnr);
                        var ts = trainStatus.GetTrainStatusByTrain((int)pnr.TrainNumber).Result;
                        var reducets = ts.Find(t => t.Doj == pnr.JourneyDate);
                        if (pnr.TypeOfCoach == "AC1")
                        {
                            reducets.AcSeats1Available -= pCount;
                            reducets.AcSeats1Booked += pCount;
                        }
                        if (pnr.TypeOfCoach == "AC2")
                        {
                            reducets.AcSeats2Available -= pCount;
                            reducets.AcSeats2Booked += pCount;
                        }
                        if (pnr.TypeOfCoach == "AC3")
                        {
                            reducets.AcSeats3Available -= pCount;
                            reducets.AcSeats3Booked += pCount;
                        }
                        if (pnr.TypeOfCoach == "SL")
                        {
                            reducets.SlSeatsAvailable-= pCount;
                            reducets.SlSeatsBooked += pCount;
                        }
                        if (pnr.TypeOfCoach == "SS")
                        {
                            reducets.SsSeatsAvailable -= pCount;
                            reducets.SsSeatsBooked += pCount;
                        }
                        TempData["tNumber"] = null;
                        TempData["Message"] = "Ticket Booked Successfully";
                        TempData["typeofmessage"] = "success";
                        return RedirectToAction("Index", "Pnrs");
                    }
                }
                TempData["typeofmessage"] = "failed";
                TempData["Message"] = "Window timeout, Ticket not Booked";
                return View("Index", "Home");
            }
            catch (Exception)
            {
                TempData["typeofmessage"] = "error";
                TempData["Message"] = "Something went wrong, unable to process your request.";
                return View("Index", "Home");
            }
        }

        public void addTickets(Pnr pnr)
        {
            foreach(Ticket t in passengers)
            {
                if (t.PassengerName != null)
                {
                    var newTicket = new Ticket();
                    newTicket.Pnrnumber = pnr.Pnrnumber;
                    newTicket.PassengerName = t.PassengerName;
                    newTicket.Age = t.Age;
                    newTicket.Gender = t.Gender;
                    Random r = new();
                    newTicket.SeatNumber = r.Next(1, 90);
                    newTicket.Coach = TempData["toc"].ToString();
                    newTicket.ReservationStatus = "booked";
                    newTicket.IsCancelled = false;
                    var res = tickets.AddTicket(newTicket).Result;
                }
            }
        }

        int Distance(int tNo, string startT, string endT)
        {
            int dist = 0;
            var distances = stDists.List().Result;
            List<string> allStationBtw = new();
            var order = reaches.List().Result.FindAll(r => r.TrainNumber == tNo).OrderBy(r => r.ArrivalTime);
            var found = false;
            foreach (var i in order)
            {
                if (i.StationCode == startT)
                {
                    found = true;
                }
                if (found)
                {
                    allStationBtw.Add(i.StationCode);
                }
                if (i.StationCode == endT)
                {
                    found = false;
                }
            }
            for (int i = 0; i < allStationBtw.Count - 1; i++)
            {
                var a = distances.Find(d => (d.StationA == allStationBtw[i] && d.StationB == allStationBtw[i + 1]));
                var b = distances.Find(d => (d.StationB == allStationBtw[i] && d.StationA == allStationBtw[i + 1]));
                if (a == null && b != null)
                {
                    dist = dist + (int)b.Distance;
                }
                if (a != null && b == null)
                {
                    dist = dist + (int)a.Distance;
                }
            }
            return dist;
        }

    }
}
