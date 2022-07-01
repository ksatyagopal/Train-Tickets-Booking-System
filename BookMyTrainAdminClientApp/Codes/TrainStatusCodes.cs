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

        public async Task<TrainStatus> GetTrainStatusByTrain(int trainnum)
        {
            TrainStatus emp = new TrainStatus();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(Baseurl + "api/TrainStatus/" + trainnum))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    emp = JsonConvert.DeserializeObject<TrainStatus>(apiResponse);
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
