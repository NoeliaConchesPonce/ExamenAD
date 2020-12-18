using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AE5.Models
{
    public class EventosRepository
    {
        // recuperar todas los eventos 
        public List<Evento> retrieve()
        {
            List<Evento> eventos;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                eventos = context.Evento.ToList();

            }
            return eventos;
        }
       

        public void Save (Evento e)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Evento.Add(e);
            context.SaveChanges();

        }
    }
}