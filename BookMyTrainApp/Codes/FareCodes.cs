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
    public class FareCodes
    {

        private readonly string Baseurl = "https://localhost:44365/";
        public async Task<List<Fare>> List()
        {
            List<Fare> info = new List<Fare>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Fares");

                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    info = JsonConvert.DeserializeObject<List<Fare>>(Response);

                }
                return info;
            }
        }

        public async Task<Fare> GetMoneyByCoachType(string coach)
        {
            Fare fare = new Fare();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(Baseurl + "api/Fares/" + coach))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    fare = JsonConvert.DeserializeObject<Fare>(apiResponse);
                }
            }
            return fare;
        }

        public async Task<Fare> AddFare(Fare e)
        {
            Fare fare = new Fare();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(e), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(Baseurl + "api/Fares", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        fare = JsonConvert.DeserializeObject<Fare>(apiResponse);
                    }
                }
            }
            catch (Exception) { throw; }
            return fare;
        }

       

        public async Task<bool> UpdateFare(Fare f)
        {
            Fare received = new Fare();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string id = f.TypeOfCoach;
                    StringContent content1 = new StringContent(JsonConvert.SerializeObject(f), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync(Baseurl + "api/Fares/" + id, content1))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        received = JsonConvert.DeserializeObject<Fare>(apiResponse);
                    }
                }
            }
            catch (Exception) { return false; }
            return true;
        }

        public async Task<bool> DeleteFare(Fare f)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync(Baseurl + "api/Fares/" + f.TypeOfCoach))
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
