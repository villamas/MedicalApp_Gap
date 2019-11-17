using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;
using MedicalRepos.Contracts;

namespace MedicalRepos
{
    public class TiposCitaRepository : GenericRepository<TipoCitas>, ITipoCitaRepository
    {
        private readonly MedicalAppointmentContext _DbContext;
        public TiposCitaRepository(MedicalAppointmentContext context) : base(context)
        {
            this._DbContext = context;
        }
    }
}
