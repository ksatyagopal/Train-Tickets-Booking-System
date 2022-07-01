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
    public class AccountCodes
    {
        private readonly string baseurl = "https://localhost:44351/api/Accounts";
        public async Task<List<Account>> List()
        {
            List<Account> userInfo = new List<Account>();

            using (var client = new HttpClient())
            {
                HttpResponseMessage Res = await client.GetAsync(baseurl);

                if (Res.IsSuccessStatusCode)
                {
                    var Response = Res.Content.ReadAsStringAsync().Result;
                    userInfo = JsonConvert.DeserializeObject<List<Account>>(Response);

                }
                return userInfo;
            }
        }

        
    }
}
