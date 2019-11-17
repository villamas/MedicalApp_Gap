using System;
using MedicalAPI.Utilitarios;

namespace MedicalAPI.Interface
{
    public interface IUserService
    {
        Usuarios Authenticate(string username, string password);
    }
}
