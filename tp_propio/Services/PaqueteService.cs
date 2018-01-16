using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tp_propio.Services
{
    public class PaqueteService
    {
        private PW3TurismoEntities context = new PW3TurismoEntities();

        public List<Paquete> getPaquetes(int Inicio, int Cantidad)
        {

            return context.Paquete.OrderByDescending(p => p.FechaInicio).Skip(((Inicio - 1) * Cantidad)).Take(Cantidad).ToList();
        }

        public int ContarPaquetes()
        {

            return context.Paquete.Count();
        }

        public bool Add( Paquete p)
        {
            try
            {
                context.Paquete.Add(p);

                context.SaveChanges();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public Paquete GetPaquete(long id)
        {

            return context.Paquete.Find(id);
        }

        public List<Paquete> GetDestacados()
        {
            
            return (from p in context.Paquete where  p.Destacado select p).ToList();
        }

        public bool Actualizar( Paquete PaqueteModificado)
        {
            try
            {
                Paquete PaqueteActual = this.GetPaquete(PaqueteModificado.Id);

                PaqueteActual.Nombre = PaqueteModificado.Nombre;
                PaqueteActual.Descripcion = PaqueteModificado.Descripcion;
                PaqueteActual.Foto = PaqueteModificado.Foto;
                PaqueteActual.FechaInicio = PaqueteModificado.FechaInicio;
                PaqueteActual.FechaFin = PaqueteModificado.FechaFin;
                PaqueteActual.LugaresDisponibles = PaqueteModificado.LugaresDisponibles;
                PaqueteActual.PrecioPorPersona = PaqueteModificado.PrecioPorPersona;
                PaqueteActual.Destacado = PaqueteModificado.Destacado;

                context.SaveChanges();

                return true;
            }
            catch(Exception e)
            {
                return false;
            }

        }

        public void Eliminar(Paquete p)
        {
            Paquete Paquete = GetPaquete(p.Id);
            context.Paquete.Remove(Paquete);
            context.SaveChanges();
        }

        
    }
}