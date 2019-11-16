using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Models;

namespace MedicalRepos.Contracts
{
   public interface ICitasRepository
    {
        IEnumerable<Citas> ObtieneCitasPorFecha(DateTime pFecha);
    }
}
