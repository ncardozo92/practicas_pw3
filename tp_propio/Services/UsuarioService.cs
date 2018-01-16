using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tp_propio.Services
{
    public class UsuarioService
    {
        //el nombre del contexto se encuentra en el <connectionString> </connectionString> de Web.config
        private PW3TurismoEntities context = new PW3TurismoEntities();

        public Usuario GetUsuario(Usuario Usuario)
        {

            return context.Usuario.Where(u => u.Email == Usuario.Email && u.Contrasenia == Usuario.Contrasenia).FirstOrDefault();
        }
    }
}