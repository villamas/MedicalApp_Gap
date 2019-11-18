using System;
using System.ComponentModel.DataAnnotations;

namespace MedicalSite.Models
{
    public class CitasViewModel
    {
        public decimal idCita { get; set; }
        [Display(Name = "Identificación Paciente")]
        public string idPaciente { get; set; }
        [Display(Name = "Tipo Cita")]
        public decimal idTipoCita { get; set; }
        [Display(Name = "Fecha")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime fecha { get; set; }
        public bool estado { get; set; }
        [Display(Name = "Nombre Médico")]
        public string nombreMedico { get; set; }
    }
}
