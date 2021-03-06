﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AE5.Models
{
    public class ApuestasRepository
    {
        // recuperar todas las apuestas
        public List<Apuesta> retrieve()
        {
            List<Apuesta> apuestas;
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuestas = context.Apuesta.Include(a => a.mercado).ToList();

            }
            return apuestas;
        }
        //recuperar un apuesta a partir de su id
        public Apuesta retireveId(int id)
        {
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                var apuesta = context.Apuesta.FirstOrDefault(a => a.ApuestaId == id);
                return apuesta;
            }

        }

        internal void Save(Apuesta a)
        {
            Mercado mercado;
            PlaceMyBetContext context = new PlaceMyBetContext();
            mercado = context.Mercado.FirstOrDefault(m => m.MercadoId == a.MercadoId);

            if (a.TipoApuesta == "over")
            {
                mercado.DineroOver += a.DineroApuesta;
                a.Cuota = mercado.CuotaOver;
            }

            if (a.TipoApuesta == "under")
            {
                mercado.DineroUnder += a.DineroApuesta;
                a.Cuota = mercado.CuotaUnder;
            }

            double probabilidadOver = mercado.DineroOver / (mercado.DineroOver + mercado.DineroUnder);

            double probabilidadUnder = mercado.DineroUnder / (mercado.DineroOver + mercado.DineroUnder);

            mercado.CuotaOver = (1 / probabilidadOver) * 0.95;

            mercado.CuotaUnder = (1 / probabilidadUnder) * 0.95;

            a.Fecha = DateTime.Now;
            a.OverUnder = mercado.OverUnder;
            a.EventoId = mercado.EventoId;

            context.Mercado.Update(mercado);
            context.Apuesta.Add(a);
            context.SaveChanges();
        }

        public static ApuestasDTO ToDTO( Apuesta a)
        {
            return new ApuestasDTO(a.UsuarioId, a.EventoId, a.TipoApuesta, a.Cuota, a.DineroApuesta, a.mercado);
        }

        internal List<ApuestasDTO> retrieveDTO()
        {
            List<ApuestasDTO> apuestas = new List<ApuestasDTO>();
            using (PlaceMyBetContext context = new PlaceMyBetContext())
            {
                apuestas = context.Apuesta.Include(e => e.mercado).Select(p => ToDTO(p)).ToList();

            }

            return apuestas;
        }
    }
}