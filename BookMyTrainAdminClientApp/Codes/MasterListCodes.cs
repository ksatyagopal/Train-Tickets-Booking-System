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
    public class MasterListCodes
    {
        private readonly string Baseurl = "https://localhost:44323/";
        public async Task<List<MasterList>> List()
        {
            List<MasterList> userInfo = new List<MasterList>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/MasterLists");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    userInfo = JsonConvert.DeserializeObject<List<MasterList>>(EmpResponse);

                }
                return userInfo;
            }
        }

        public async Task<List<MasterList>> MasterListByUser(int id)
        {
            List<MasterList> userInfo = new List<MasterList>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/MasterLists/GetMasterListByUser/"+id);

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    userInfo = JsonConvert.DeserializeObject<List<MasterList>>(EmpResponse);

                }
                return userInfo;
            }
        }

        public async Task<MasterList> AddMasterList(MasterList e)
        {
            try
            {
                MasterList obj = new MasterList();
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(e), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(Baseurl + "api/MasterLists", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        obj = JsonConvert.DeserializeObject<MasterList>(apiResponse);
                    }
                }
                return obj;
            }
            catch (Exception) { throw; }
        }

        public async Task<MasterList> GetMasterListByID(int id)
        {
            MasterList emp = new MasterList();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(Baseurl + "api/MasterLists/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    emp = JsonConvert.DeserializeObject<MasterList>(apiResponse);
                }
            }
            return emp;
        }

        public async Task<bool> UpdateMasterList(MasterList e)
        {
            MasterList receivedemp = new MasterList();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    int id = e.Mid;
                    StringContent content1 = new StringContent(JsonConvert.SerializeObject(e), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync(Baseurl + "api/MasterLists/" + id, content1))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        receivedemp = JsonConvert.DeserializeObject<MasterList>(apiResponse);
                    }
                }
            }
            catch (Exception) { return false; }
            return true;
        }

        public async Task<bool> DeleteMasterList(MasterList e)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync(Baseurl + "api/MasterLists/" + e.UserId))
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
