using BookStorePortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace BookStorePortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> DisplayAllBooks()
        {
            List<BookDetails> menu = new List<BookDetails>();
            HttpClient client = new HttpClient();
            HttpResponseMessage res = new HttpResponseMessage();
            
            res = client.GetAsync("https://localhost:44348/api/Book/").Result;

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                menu = JsonConvert.DeserializeObject<List<BookDetails>>(result);
                ViewBag.UpdatedMember = menu;
                return View(menu);
            }
            return View("Index", "Home");
        }


        [HttpGet("id")]
        public IActionResult GetBookDetails(int id)
        {
            BookDetails menu = new BookDetails();

            using (var client = new HttpClient())
            {

                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = new HttpResponseMessage();

                response = client.GetAsync("https://localhost:44348/api/Book/getbookdetails?id=" + id).Result;
                var data = JsonConvert.DeserializeObject<BookDetails>(response.Content.ReadAsStringAsync().Result);
                return View("SpecificBookDetails",data);
            }
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
