using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using MedicalRepos.Contracts;

namespace MedicalRepos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MedicalAppointmentContext _DbContext;

        public CitasRepository CitasRepository { get; private set; }
        public PacienteRepository PacienteRepository { get; private set; }
        public TiposCitaRepository TiposCitaRepository { get; private set; }

        public UnitOfWork(MedicalAppointmentContext context)
        {
            _DbContext = context;
            this.CitasRepository = new CitasRepository(this._DbContext);
            this.PacienteRepository = new PacienteRepository(this._DbContext);
            this.TiposCitaRepository = new TiposCitaRepository(this._DbContext);
          
        }

        public async Task Commit()
        {
            await this._DbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            this._DbContext.Dispose();
        }
    }
}
