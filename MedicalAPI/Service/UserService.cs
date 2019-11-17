using System;
using System.Collections.Generic;
using System.Linq;
using MedicalAPI.Utilitarios;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace MedicalAPI.Service
{
    public class UserService : Interface.IUserService
    {
        private List<Usuarios> _users = new List<Usuarios>
        {
            new Usuarios { Id = 1, FullName = "Jose Pablo Villavicencio", Username = "Villamas", Password = "Drako2019" }
        };

        private readonly ConfigSettings _configSettings;

        public UserService(IOptions<ConfigSettings> configSettings)
        {
            _configSettings = configSettings.Value;
        }

        public Usuarios Authenticate(string username, string password)
        {
            var Usuarios = _users.SingleOrDefault(x => x.Username == username && x.Password == password);

            if (Usuarios == null)
                return null;

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configSettings.TokenSecret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, Usuarios.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            Usuarios.Token = tokenHandler.WriteToken(token);

            Usuarios.Password = null;

            return Usuarios;
        }

    }
}

