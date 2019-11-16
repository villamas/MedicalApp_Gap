using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class Paciente
    {
        public Paciente()
        {
            Citas = new HashSet<Citas>();
        }

        public string IdPaciente { get; set; }
        public string Nombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public decimal? Telefono { get; set; }
        public string Correo { get; set; }
        public DateTime? FecNacimiento { get; set; }

        public virtual ICollection<Citas> Citas { get; set; }
    }
}
