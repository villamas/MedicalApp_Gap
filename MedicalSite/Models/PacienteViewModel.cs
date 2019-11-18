using System;
namespace MedicalSite.Models
{
    public class PacienteViewModel
    {
        public string IdPaciente { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public decimal? Telefono { get; set; }
        public string Correo { get; set; }
        public DateTime? FecNacimiento { get; set; }
    }
}
