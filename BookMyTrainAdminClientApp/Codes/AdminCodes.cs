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
    public class AdminCodes
    {
        private readonly string Baseurl = "https://localhost:44379/";
        public async Task<List<Admin>> List()
        {
            List<Admin> info = new List<Admin>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Admins");

                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    info = JsonConvert.DeserializeObject<List<Admin>>(Response);

                }
                return info;
            }
        }

        public async Task<Admin> GetAdminById(int id)
        {
            Admin admin = new Admin();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(Baseurl + "api/Admins/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    admin = JsonConvert.DeserializeObject<Admin>(apiResponse);
                }
            }
            return admin;
        }

        public async Task<Admin?> isValidAdmin(string username, string password)
        {
            var isadmin = (from i in await List()
                     where i.UserName == username
                     select i).FirstOrDefault();
            return isadmin;
        }

        public async Task<Admin> AddAdmin(Admin e)
        {
            Admin admin = new Admin();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(e), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(Baseurl + "api/Admins", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        admin = JsonConvert.DeserializeObject<Admin>(apiResponse);
                    }
                }
            }
            catch (Exception) { throw; }
            return admin;
        }



        public async Task<bool> UpdateAdmin(Admin f)
        {
            Admin received = new Admin();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    int id = f.AdminId;
                    StringContent content1 = new StringContent(JsonConvert.SerializeObject(f), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync(Baseurl + "api/Admins/" + id, content1))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        received = JsonConvert.DeserializeObject<Admin>(apiResponse);
                    }
                }
            }
            catch (Exception) { return false; }
            return true;
        }

        public async Task<bool> DeleteAdmin(Admin f)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync(Baseurl + "api/Admins/" + f.AdminId))
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
