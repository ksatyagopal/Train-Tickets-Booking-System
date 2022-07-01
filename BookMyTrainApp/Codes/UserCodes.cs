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
    public class UserCodes
    {
        private readonly string Baseurl = "https://localhost:44323/";
        public async Task<List<User>> List()
        {
            List<User> userInfo = new List<User>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);

                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("api/Users");

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    userInfo = JsonConvert.DeserializeObject<List<User>>(EmpResponse);

                }
                return userInfo;
            }
        }

        public async Task<User> AddUser(User e)
        {
            try
            {
                User obj = new User();
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(e), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(Baseurl+"api/Users", content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        obj = JsonConvert.DeserializeObject<User>(apiResponse);
                    }
                }
                return obj;
            }
            catch (Exception) { throw; }
        }

        public async Task<User> GetUserByID(int id)
        {
            User emp = new User();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(Baseurl+ "api/Users/GetUserById/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    emp = JsonConvert.DeserializeObject<User>(apiResponse);
                }
            }
            return emp;
        }

        public async Task<bool> UpdateUser(User e)
        {
            User receivedemp = new User();
            try
            {
                using (var httpClient = new HttpClient())
                {
                    int id = e.UserId;
                    StringContent content1 = new StringContent(JsonConvert.SerializeObject(e), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync(Baseurl+"api/Users/" + id, content1))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        receivedemp = JsonConvert.DeserializeObject<User>(apiResponse);
                    }
                }
            }
            catch (Exception) { return false; }
            return true;
        }

        public async Task<bool> DeleteUser(User e)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    using (var response = await httpClient.DeleteAsync(Baseurl+"api/Users/" + e.UserId))
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
