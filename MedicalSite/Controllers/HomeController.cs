using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MedicalSite.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using MedicalSite.Utilitarios;
using Microsoft.AspNetCore.Http;

namespace MedicalSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Remove("token");
            ViewBag.Message = "User logged out successfully!";
            return View("Index");
        }

        public IActionResult Login(string Username, string password)
        {
            try
            {
                string baseUrl = "http://localhost:5001";
                using (HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(baseUrl)
                })
                {
                    var contentType = new MediaTypeWithQualityHeaderValue
("application/json");
                    client.DefaultRequestHeaders.Accept.Add(contentType);

                    UsuarioViewModel userModel = new UsuarioViewModel();
                    userModel.Username = Username;
                    userModel.Password = password;

                    string stringData = JsonConvert.SerializeObject(userModel);
                    var contentData = new StringContent(stringData, System.Text.Encoding.UTF8, "application/json");

                    HttpResponseMessage response = client.PostAsync
                ("/api/seguridad/authenticate", contentData).Result;
                    string stringJWT = response.Content.
                ReadAsStringAsync().Result;
                    Utilitarios.JWT jwt = JsonConvert.DeserializeObject
                <Utilitarios.JWT>(stringJWT);

                    HttpContext.Session.SetString("token", jwt.Token);
                }

                ViewBag.Message = "User logged in successfully!";

                return View("Index");
            }
            catch (Exception ex)
            {
                ViewBag.Message = "Error al Loguear!";
                return View("../Login/Login");
            }
            
        }


        public IActionResult Loguear()
        {
            return View("../Login/Login");
        }

        public IActionResult Index()
        {
            return View();
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
