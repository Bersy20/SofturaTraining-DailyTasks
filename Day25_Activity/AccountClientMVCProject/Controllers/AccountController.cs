using AccountClientMVCProject.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace AccountClientMVCProject.Controllers
{
    public class AccountController : Controller
    {
        public async Task<ActionResult> Index()
        {
            string Baseurl = "http://localhost:31566/";
            var AccountInfo = new List<Account>();
            //HttpClient cl = new HttpClient();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Accounts");
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var AccountResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    AccountInfo = JsonConvert.DeserializeObject<List<Account>>(AccountResponse);

                }
                //returning the employee list to view  
                return View(AccountInfo);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Account a)
        {
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(a), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:31566/api/Accounts", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<Account>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Details(int id)
        {
            Account a = new Account();
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync("http://localhost:31566/api/Accounts/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    a = JsonConvert.DeserializeObject<Account>(apiResponse);
                }
            }
            return View(a);
        }
        public async Task<ActionResult> Delete(int id)
        {
            TempData["AccountId"] = id;
            Account a = new Account();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:31566/api/Accounts/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    a = JsonConvert.DeserializeObject<Account>(apiResponse);
                }
            }
            return View(a);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(Account a)
        {
            int AccountId = Convert.ToInt32(TempData["AccountId"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:31566/api/Accounts/" + AccountId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Edit(int id)
        {
            TempData["AccountId"] = id;
            Account a = new Account();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:31566/api/Accounts/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    a = JsonConvert.DeserializeObject<Account>(apiResponse);
                }
            }
            return View(a);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Account a)
        {
            int AccountId = Convert.ToInt32(TempData["AccountId"]);
            a.AccountNumber = AccountId;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(a), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("http://localhost:31566/api/Accounts/" + AccountId, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<Account>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
    }
}
