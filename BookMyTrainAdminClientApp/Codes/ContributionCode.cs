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
    public class ContributionCode
    {
        private readonly string Baseurl = "https://localhost:44379/";
        public async Task<List<Contribution>> List()
        {
            List<Contribution> info = new List<Contribution>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Contributions");

                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    info = JsonConvert.DeserializeObject<List<Contribution>>(Response);

                }
                return info;
            }
        }

        public async Task<Contribution> GetContributionById(int id)
        {
            Contribution c = new Contribution();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(Baseurl + "api/Contributions/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    c = JsonConvert.DeserializeObject<Contribution>(apiResponse);
                }
            }
            return c;
        }

        public async Task<Contribution> AddContribution(Contribution e)
        {
            Contribution fare = new Contribution();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(e), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(Baseurl + "api/Contributions", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        fare = JsonConvert.DeserializeObject<Contribution>(apiResponse);
                    }
                }
            }
            catch (Exception) { throw; }
            return fare;
        }



        public async Task<bool> UpdateContribution(Contribution f)
        {
            Contribution received = new Contribution();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    int id = f.Cid;
                    StringContent content1 = new StringContent(JsonConvert.SerializeObject(f), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync(Baseurl + "api/Contributions/" + id, content1))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        received = JsonConvert.DeserializeObject<Contribution>(apiResponse);
                    }
                }
            }
            catch (Exception) { return false; }
            return true;
        }

        public async Task<bool> DeleteContribution(Contribution f)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync(Baseurl + "api/Contributions/" + f.Cid))
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
