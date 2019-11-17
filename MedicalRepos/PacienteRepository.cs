using DataAccess.Models;
using MedicalRepos.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace MedicalRepos
{
    public class PacienteRepository : GenericRepository<Paciente>, IPacientesRepository
    {
        private readonly MedicalAppointmentContext _DbContext;
        public PacienteRepository(MedicalAppointmentContext context) : base(context)
        {
            this._DbContext = context;
        }
    }
}
