using AccountClientMVCProject.Models;
using AccountClientMVCProject.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
    public class TransactionController : Controller
    {
        private ILogger<TransactionController> _logger;
        private IRepo<Account> _repo;


        public TransactionController(IRepo<Account> repo, ILogger<TransactionController> logger)
        {
            _logger = logger;
            _repo = repo;
        }
        public async Task<ActionResult> Index()
        {
            string Baseurl = "http://localhost:33690/";
            var TransactionInfo = new List<Transaction>();
            //HttpClient cl = new HttpClient();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Transactions");
                //Checking the response is successful or not which is sent using HttpClient  
                if (Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api   
                    var TransactionResponse = Res.Content.ReadAsStringAsync().Result;

                    //Deserializing the response recieved from web api and storing into the Employee list  
                    TransactionInfo = JsonConvert.DeserializeObject<List<Transaction>>(TransactionResponse);

                }
                //returning the employee list to view  
                return View(TransactionInfo);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Create(Transaction t)
        {
            
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PostAsync("http://localhost:33690/api/Transactions", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<Transaction>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Details(int id)
        {
            Transaction t = new Transaction();
            using (var httpClient = new HttpClient())
            {

                using (var response = await httpClient.GetAsync("http://localhost:33690/api/Transactions/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    t = JsonConvert.DeserializeObject<Transaction>(apiResponse);
                }
            }
            return View(t);
        }
        public async Task<ActionResult> Delete(int id)
        {
            TempData["TransactionId"] = id;
            Transaction t = new Transaction();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:33690/api/Transactions/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    t = JsonConvert.DeserializeObject<Transaction>(apiResponse);
                }
            }
            return View(t);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(Transaction t)
        {
            int TransactionId = Convert.ToInt32(TempData["TransactionId"]);
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.DeleteAsync("http://localhost:33690/api/Transactions/" + TransactionId))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> Edit(int id)
        {
            TempData["TransactionId"] = id;
            Transaction t = new Transaction();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:33690/api/Transactions/" + id))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    t = JsonConvert.DeserializeObject<Transaction>(apiResponse);
                }
            }
            return View(t);
        }
        [HttpPost]
        public async Task<ActionResult> Edit(Transaction t)
        {
            int TransactionId = Convert.ToInt32(TempData["TransactionId"]);
            t.TransactionId = TransactionId;
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(t), Encoding.UTF8, "application/json");

                using (var response = await httpClient.PutAsync("http://localhost:33690/api/Transactions/" + TransactionId, content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    var obj = JsonConvert.DeserializeObject<Account>(apiResponse);
                }
            }
            return RedirectToAction("Index");
        }
        public async Task<ActionResult> GetAccounts()
        {
            string Baseurl = "http://localhost:33690/";
            var AccountInfo = new List<Account>();
            //HttpClient cl = new HttpClient();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                //Define request data format  
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                //Sending request to find web api REST service resource GetAllEmployees using HttpClient  
                HttpResponseMessage Res = await client.GetAsync("api/Transactions/Accounts");
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
 
        public ActionResult Login()
        {
            Account account = new Account();
            TempData["un"] = account.AccountNumber;
            if (TempData.Count == 1)
                return View();

            account.CustomerName = TempData.Peek("un").ToString();
            
            return View(account);
        }

        // POST: UsersController/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Account account)
        {
            try
            {
                if (_repo.Login(account))
                    return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
            return View();
        }

    }

}
