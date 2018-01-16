using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace tp_propio.Services
{
    public class ReservaService
    {

        private PW3TurismoEntities context = new PW3TurismoEntities();

        public bool AddReserva(Reserva r)
        {
            try {
                context.Reserva.Add(r);
                context.Paquete.Find(r.IdPaquete).LugaresDisponibles -= r.CantPersonas;
                context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {

                return false;
            }


        }

        public List<Reserva> GetReservas(int Id)
        {

            //return (from r in context.Reserva join p in context.Paquete on r. where r.;
            return context.Reserva.Where(r => r.IdUsuario == Id).ToList();
        }

        public bool Cancelar(int Id)
        {

            try
            {

                Reserva Reserva = context.Reserva.Find(Id);

                context.Reserva.Remove(Reserva);
                context.SaveChanges();
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        public void EliminarReservas(int IdPAquete)
        {

            List<Reserva> Reservas = context.Reserva.Where(r => r.IdPaquete == IdPAquete).ToList();

            foreach(Reserva Reserva in Reservas)
            {
                context.Reserva.Remove(Reserva);
            }
            context.SaveChanges();
        }
    }
}