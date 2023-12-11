using FoodAdmin.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Net.Http;
using FoodAdminClient.Service;
using FoodAdminClient.Models;
using System.Text;

namespace FoodAdmin.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly HttpClient httpClient;
        private readonly Token Token;

        public HomeController(ILogger<HomeController> logger, HttpClient httpClient, Token Token)
        {
            _logger = logger;
            this.httpClient = httpClient;
            this.Token = Token;
        }

        public IActionResult Index()
        {
            return View();
        }
        public ActionResult Create(string textarea)
        {
            return View(textarea);

        }

        public async Task<IActionResult> update(IFormFile fileHinhAnh)
        {
            

          

            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.imgur.com/3/image/{{imageDeleteHash}}");
            request.Headers.Add("Authorization", "Client-ID c759633e812f8b5");
            var content = new MultipartFormDataContent();
            content.Add(new StreamContent(fileHinhAnh.OpenReadStream()), "image", fileHinhAnh.FileName);
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());
            var result = await response.Content.ReadFromJsonAsync<ImgurApiResponse>();
            return View(result);
        

        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}