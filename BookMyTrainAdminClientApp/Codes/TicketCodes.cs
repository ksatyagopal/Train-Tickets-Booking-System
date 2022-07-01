using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using BookMyTrainAdminClientApp.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookMyTrainAdminClientApp.Codes
{
    public class TicketCodes
    {
        private readonly string Baseurl = "https://localhost:44323/";
        public async Task<List<Ticket>> List()
        {
            List<Ticket> userInfo = new List<Ticket>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Tickets");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    userInfo = JsonConvert.DeserializeObject<List<Ticket>>(EmpResponse);

                }
                return userInfo;
            }
        }

        public async Task<List<Ticket>> TicketListByPNR(long pnrnumber)
        {
            List<Ticket> userInfo = new List<Ticket>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Tickets");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    userInfo = JsonConvert.DeserializeObject<List<Ticket>>(EmpResponse);

                }
                return (from i in userInfo where i.Pnrnumber == pnrnumber select i).ToList();
            }
        }

        public async Task<Ticket> AddTicket(Ticket e)
        {
            try
            {
                Ticket obj = new Ticket();
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(e), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(Baseurl + "api/Tickets", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        obj = JsonConvert.DeserializeObject<Ticket>(apiResponse);
                    }
                }
                return obj;
            }
            catch (Exception) { throw; }
        }

        public async Task<Ticket> GetTicketByID(int id)
        {
            Ticket emp = new Ticket();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(Baseurl + "api/Tickets/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    emp = JsonConvert.DeserializeObject<Ticket>(apiResponse);
                }
            }
            return emp;
        }

        public async Task<bool> UpdateTicket(Ticket e)
        {
            Ticket receivedemp = new Ticket();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    int id = e.TicketId;
                    StringContent content1 = new StringContent(JsonConvert.SerializeObject(e), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync(Baseurl + "api/Tickets/" + id, content1))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        receivedemp = JsonConvert.DeserializeObject<Ticket>(apiResponse);
                    }
                }
            }
            catch (Exception) { return false; }
            return true;
        }

        public async Task<bool> DeleteTicket(Ticket e)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync(Baseurl + "api/Tickets/" + e.TicketId))
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
