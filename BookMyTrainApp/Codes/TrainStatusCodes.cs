using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BookMyTrainApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookMyTrainApp.Codes
{
    public class TrainStatusCodes
    {
        private readonly string Baseurl = "https://localhost:44365/";
        public async Task<List<TrainStatus>> List()
        {
            List<TrainStatus> userInfo = new List<TrainStatus>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/TrainStatus");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    userInfo = JsonConvert.DeserializeObject<List<TrainStatus>>(EmpResponse);

                }
                return userInfo;
            }
        }

        public async Task<TrainStatus> AddTrainStatus(TrainStatus e)
        {
            try
            {
                TrainStatus obj = new TrainStatus();
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(e), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(Baseurl + "api/TrainStatus", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        obj = JsonConvert.DeserializeObject<TrainStatus>(apiResponse);
                    }
                }
                return obj;
            }
            catch (Exception) { throw; }
        }

        public async Task<TrainStatus> CheckTrainStatus(DateTime date, int trainNumber)
        {
            try
            {
                var tsPresent = GetTrainStatusByTrain(trainNumber).Result.FirstOrDefault(ts=>ts.Doj==date);
                if (tsPresent != null)
                {
                    return tsPresent;
                }
                TrainCodes trainCodes = new();
                TrainStatusCodes tsCodes = new();
                Train train = trainCodes.GetTrainByNumber(trainNumber).Result;
                TrainStatus trainStatus = new();
                var temp = tsCodes.List().Result.OrderBy(e=>e.tsId).LastOrDefault();
                trainStatus.tsId = temp.tsId+1;
                trainStatus.Doj = date;
                trainStatus.TrainNumber = trainNumber;
                trainStatus.AcSeats1Available = train.NAc1Coaches * 90;
                trainStatus.AcSeats2Available = train.NAc2Coaches * 90;
                trainStatus.AcSeats3Available = train.NAc3Coaches * 90;
                trainStatus.SlSeatsAvailable = train.NSlCoaches * 90;
                trainStatus.SsSeatsAvailable = train.NSsCoaches * 90;
                trainStatus.AcSeats1Booked = 0;
                trainStatus.AcSeats2Booked = 0;
                trainStatus.AcSeats3Booked = 0;
                trainStatus.SlSeatsBooked = 0;
                trainStatus.SsSeatsBooked = 0;
                TrainStatus obj = new TrainStatus();
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(trainStatus), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(Baseurl + "api/TrainStatus", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        obj = JsonConvert.DeserializeObject<TrainStatus>(apiResponse);
                    }
                }
                return obj;
            }
            catch (Exception) { throw; }
        }

        public async Task<List<TrainStatus>> GetTrainStatusByTrain(int trainnum)
        {
            List<TrainStatus> emp = new();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(Baseurl + "api/TrainStatus/" + trainnum))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    emp = JsonConvert.DeserializeObject<List<TrainStatus>>(apiResponse);
                }
            }
            return emp;
        }

        public async Task<bool> UpdateTrainStatus(TrainStatus e)
        {
            TrainStatus receivedemp = new TrainStatus();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    int id = e.tsId;
                    StringContent content1 = new StringContent(JsonConvert.SerializeObject(e), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync(Baseurl + "api/TrainStatus/" + id, content1))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        receivedemp = JsonConvert.DeserializeObject<TrainStatus>(apiResponse);
                    }
                }
            }
            catch (Exception) { return false; }
            return true;
        }

        public async Task<bool> DeleteTrainStatus(TrainStatus e)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync(Baseurl + "api/TrainStatus/" + e.tsId))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
            }
            catch (Exception) { return false; }
            return true;
        }
    }
}
