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
    public class TransactionCodes
    {
        private readonly string Baseurl = "https://localhost:44351/api/Transactions/";
        public async Task<List<Transaction>> List()
        {
            List<Transaction> userInfo = new List<Transaction>();

            using (var client = new HttpClient())
            {
                
                HttpResponseMessage Res = await client.GetAsync(Baseurl);

                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
                    userInfo = JsonConvert.DeserializeObject<List<Transaction>>(EmpResponse);

                }
                return userInfo;
            }
        }

        public async Task<Transaction> AddTransaction(Transaction e)
        {
            try
            {
                
                Transaction obj = new Transaction();
                using (var httpClient = new HttpClient())
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(e), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(Baseurl, content))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        obj = JsonConvert.DeserializeObject<Transaction>(apiResponse);
                    }
                }
                
                return obj;
            }
            catch (Exception) { throw; }
        }

        public async Task<Transaction> GetTransactionByID(int id)
        {
            Transaction emp = new();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(Baseurl+ id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    emp = JsonConvert.DeserializeObject<Transaction>(apiResponse);
                }
            }
            return emp;
        }
    }
}
