﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using MedicalSite.Models;
using MedicalSite.Utilitarios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MedicalSite.Controllers
{
    public class CitasController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShowData()
        {
            ApiUtil<List<CitasViewModel>> apiUtil = new Utilitarios.ApiUtil<List<CitasViewModel>>();
            var datos = apiUtil.SeguridadApi(null, "/api/Citas", HttpContext.Session.GetString("token"));

            if (datos == null)
            {
                ViewBag.Message = "Unauthorized!";
                return View("../Login/Login");
            }
            else
            {

                return View("Citas", datos);

            }


        }
        // public SelectList CountryList { get; set; }

        public IActionResult NuevaCita()
        {


            ApiUtil<List<TipoCitasViewModel>> apiUtil = new Utilitarios.ApiUtil<List<TipoCitasViewModel>>();
            var x = apiUtil.SeguridadApi(null, "/api/TipoCitas", HttpContext.Session.GetString("token"));

            SelectList ListaTipoCitas = new SelectList((List<TipoCitasViewModel>)x, "IdTipoCita", "Descripcion");


            var tupleData = new Tuple<CitasViewModel, SelectList>(new CitasViewModel(), (Microsoft.AspNetCore.Mvc.Rendering.SelectList)ListaTipoCitas.AsEnumerable());
            return View("AddCita", tupleData);
            // return  View ("AddCita",new Tuple<CitasViewModel, SelectList>)
        }

        [HttpPost]
        public IActionResult GuardaCita(CitasViewModel citas)
        {
            ApiUtil<List<CitasViewModel>> apiUtil = new ApiUtil<List<CitasViewModel>>();
            CitasViewModel data = new CitasViewModel();
            data = citas;

            var datos = apiUtil.SeguridadApiPost(data, "/api/Citas/AgregaCita", HttpContext.Session.GetString("token"));

            if (datos == null)
            {
                ViewBag.Message = "Unauthorized!";
                return View("../Login/Login");

            }
            else
            {

                ViewBag.Message = datos.ToString();
                if (!string.IsNullOrEmpty(datos.ToString()))
                {
                    ApiUtil<List<TipoCitasViewModel>> apiUtil2 = new Utilitarios.ApiUtil<List<TipoCitasViewModel>>();
                    var x = apiUtil2.SeguridadApi(null, "/api/TipoCitas", HttpContext.Session.GetString("token"));

                    SelectList ListaTipoCitas = new SelectList((List<TipoCitasViewModel>)x, "IdTipoCita", "Descripcion");


                    var tupleData = new Tuple<CitasViewModel, SelectList>(new CitasViewModel(), (Microsoft.AspNetCore.Mvc.Rendering.SelectList)ListaTipoCitas.AsEnumerable());
                    return View("AddCita", tupleData);
                }
                else
                {
                    // ApiUtil<List<CitasViewModel>> apiUtil3 = new Utilitarios.ApiUtil<List<CitasViewModel>>();
                    datos = apiUtil.SeguridadApi(null, "/api/Citas", HttpContext.Session.GetString("token"));

                    if (datos == null)
                    {
                        ViewBag.Message = "Unauthorized!";
                        return View("../Login/Login");
                    }
                    else
                    {

                        return View("Citas", datos);

                    }


                }
            }


        }

        public IActionResult Cancelar(string idPaciente)
        {


            ApiUtil<List<CitasViewModel>> apiUtil = new Utilitarios.ApiUtil<List<CitasViewModel>>();
            CitasViewModel data = new CitasViewModel();
           // data = citas;
            data.idPaciente = idPaciente;
            data.fecha = DateTime.Now;
            var datos = apiUtil.SeguridadApiPost(data, "/api/Citas/Cancel", HttpContext.Session.GetString("token"));

            if (datos == null)
            {
                ViewBag.Message = "Unauthorized!";
                return View("../Login/Login");
            }
            else
            {
                ViewBag.Message = datos.ToString();
                datos = apiUtil.SeguridadApi(null, "/api/Citas", HttpContext.Session.GetString("token"));

                if (datos == null)
                {
                    ViewBag.Message = "Unauthorized!";
                    return View("../Login/Login");
                }
                else
                {

                    return View("Citas", datos);

                }

            }

        }




    }
}
