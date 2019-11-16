using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public partial class TipoCitas
    {
        public TipoCitas()
        {
            Citas = new HashSet<Citas>();
        }

        public decimal IdTipoCita { get; set; }
        public string Descripcion { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<Citas> Citas { get; set; }
    }
}
