using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Citas
    {
        public decimal IdCita { get; set; }
        public string IdPaciente { get; set; }
        public decimal IdTipoCita { get; set; }
        public DateTime Fecha { get; set; }
        public byte[] Estado { get; set; }
        public string NombreMedico { get; set; }

        public virtual Paciente IdPacienteNavigation { get; set; }
        public virtual TipoCitas IdTipoCitaNavigation { get; set; }
    }
}
