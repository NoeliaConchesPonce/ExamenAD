﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AE5.Models
{
    public class MercadosRepository
    {
        // recuperar todas las mercados
        public List<Mercado> retrieve()
        {
            List<Mercado> mercados;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercados = context.Mercado.ToList();

            }
            return mercados;
        }

        //recuperar un mercado a partir de su id
        public Mercado retireveId(int id)
        {
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                var mercado = context.Mercado.FirstOrDefault(m => m.MercadoId == id);
                return mercado;
            }
                 
        }
        public void Save(Mercado m)
        {
            PlaceMyBetContext context = new PlaceMyBetContext();
            context.Mercado.Add(m);
            context.SaveChanges();

        }

        public static MercadoDTO ToDTO(Mercado m)
        {
            return new MercadoDTO(m.OverUnder, m.CuotaOver, m.CuotaUnder);
        }
        public List<MercadoDTO> retrieveDTO()
        {
            List<MercadoDTO> mercados;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                mercados = context.Mercado.Select(m => ToDTO(m)).ToList();

            }
            return mercados;
        }

    }
}