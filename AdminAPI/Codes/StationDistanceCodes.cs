using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AdminAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace AdminAPI.Codes
{
    public class StationDistanceCodes
    {
        private readonly string Baseurl = "https://localhost:44365/";
        public async Task<List<StationDistance>> List()
        {
            List<StationDistance> userInfo = new List<StationDistance>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/StationDistances");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    userInfo = JsonConvert.DeserializeObject<List<StationDistance>>(EmpResponse);

                }
                return userInfo;
            }
        }

        public async Task<StationDistance> AddStationDistance(StationDistance e)
        {
            try
            {
                StationDistance obj = new StationDistance();
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(e), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(Baseurl + "api/StationDistances", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        obj = JsonConvert.DeserializeObject<StationDistance>(apiResponse);
                    }
                }
                return obj;
            }
            catch (Exception) { throw; }
        }


        public async Task<bool> UpdateStationDistance(StationDistance e)
        {
            StationDistance receivedemp = new StationDistance();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    int id = e.Id;
                    StringContent content1 = new StringContent(JsonConvert.SerializeObject(e), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync(Baseurl + "api/StationDistances/" + id, content1))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        receivedemp = JsonConvert.DeserializeObject<StationDistance>(apiResponse);
                    }
                }
            }
            catch (Exception) { return false; }
            return true;
        }

        public async Task<bool> DeleteStationDistance(StationDistance e)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync(Baseurl + "api/StationDistances/" + e.Id))
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
