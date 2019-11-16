using DataAccess.Models;
using MedicalRepos.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace MedicalRepos
{
    public class CitasRepository : GenericRepository<Citas>, ICitasRepository
    {
        private readonly MedicalAppointmentContext _DbContext;
        

        public CitasRepository(MedicalAppointmentContext context) : base(context)
        {
            this._DbContext = context;
        }

        public IEnumerable<Citas> ObtieneCitasPorFecha(DateTime pFecha)
        {
            return from c in _DbContext.Citas 
                   where c.Fecha.ToShortDateString().Equals(pFecha.ToShortDateString())
                   select c;
        }
    }
}
