using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedicalSite.Models;
using MedicalSite.Utilitarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalSite.Controllers
{
    public class TipoCitasController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowData()
        {
            /* string baseUrl = "https://localhost:5001";
             HttpClient client = new HttpClient
             {
                 BaseAddress = new Uri(baseUrl)
             };
             var contentType = new MediaTypeWithQualityHeaderValue
         ("application/json");
             client.DefaultRequestHeaders.Accept.Add(contentType);

             client.DefaultRequestHeaders.Authorization =
         new AuthenticationHeaderValue("Bearer",
         HttpContext.Session.GetString("token"));

             HttpResponseMessage response = client.GetAsync
         ("/api/Citas").Result;
             string stringData = response.Content.
         ReadAsStringAsync().Result;
             List<CitasViewModel> data = JsonConvert.DeserializeObject
         <List<CitasViewModel>>(stringData);


            ApiUtil<List<TipoCitasViewModel>> apiUtil = new Utilitarios.ApiUtil<List<TipoCitasViewModel>>();
            apiUtil.SeguridadApi(null, "/api/Citas", HttpContext.Session.GetString("token"));

        

            if (response.StatusCode == HttpStatusCode.Unauthorized)
            {
                ViewBag.Message = "Unauthorized!";
            }
            else
            {
                string strTable = "<table border='1' cellpadding='10'>";
                foreach (PacienteViewModel paciente in data)
                {
                    strTable += "<tr>";
                    strTable += "<td>";
                    strTable += paciente.IdPaciente;
                    strTable += "</td>";
                    strTable += "<td>";
                    strTable += paciente.Nombre;
                    strTable += "</td>";
                    strTable += "<td>";
                    strTable += paciente.PrimerApellido;
                    strTable += "</td>";
                    strTable += "<td>";
                    strTable += paciente.SegundoApellido;
                    strTable += "</td>";
                    strTable += "<td>";
                    strTable += paciente.Telefono;
                    strTable += "</td>";
                    strTable += "<td>";
                    strTable += paciente.Correo;
                    strTable += "</td>";
                    strTable += "<td>";
                    strTable += paciente.FecNacimiento;
                    strTable += "</td>";
                    strTable += "</tr>";

                }
                strTable += "</table>";

                ViewBag.Message = strTable;
            }*/

            return View("Index");
        }

    }
}
