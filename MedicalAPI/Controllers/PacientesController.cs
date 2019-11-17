
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Dynamic;
using MedicalRepos;
using MedicalRepos.Contracts;
using DataAccess.Models;
using System.Runtime.InteropServices.WindowsRuntime;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;

namespace MedicalAPI.Controllers
{


    [EnableCors("CorsPolicy")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class PacientesController : ControllerBase
    {

        private readonly UnitOfWork _UOW;

        public PacientesController(IUnitOfWork uOW)
        {
            _UOW = uOW as UnitOfWork;
        }

        [HttpGet]
        public ActionResult Get()
        {
            dynamic model = new ExpandoObject();
            model.Paciente = this._UOW.PacienteRepository.GetAll();
            return Ok(model.Paciente);



        }

        [HttpPost]
        public async Task<ActionResult> PostAsync([FromBody] Paciente paciente)
        {


            //  model.Paciente =
            this._UOW.PacienteRepository.Add(paciente);
            await _UOW.Commit();
            return Ok("Inserción Exitosa");
        }

    }
}