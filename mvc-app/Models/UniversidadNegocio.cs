using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mvc_app.Models
{
    public class UniversidadNegocio
    {

        private static List<Universidad> Universidades = new List<Universidad>();

        public List<Universidad> ListarTodas()
        {

            return Universidades ;
        }

        public void Add(Universidad uni)
        {
            
            Universidades.Add(uni);
        }

        
        public void Update(Universidad u)
        {

            

            int index = Universidades.FindIndex(uni => uni.Id == u.Id);

            Universidades[index] = u;
        }

        public Universidad BuscarUniversidad(int id)
        {
            
            return Universidades.Find(uni => uni.Id == id);
        }

        public void Delete(int id)
        {

            Universidades.Remove(BuscarUniversidad(id));
        }

        public int ContarTodas()
        {

            return Universidades.Count();
        }
    }
}