using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AE5.Models
{
    /*Ejercicio 2*/
    public class EventoDTO
    {
        public string EquipoLocal  { get; set; }
        public string EquipoVisitante { get; set; }
        public double OverUnder  { get; set; }
        public double CuotaOver  { get; set; }
        public double CuotaUnder { get; set; }
        public double DineroOver { get; set; }
        public double DineroUnder { get; set; }

        public EventoDTO(string eLocal, string eVisitante, double tipo, double cuotaOver, double cuotaUnder, double dineroOver, double dineroUnder)
        {
            EquipoLocal = eLocal;
            EquipoVisitante = eVisitante;
            OverUnder = tipo;
            CuotaOver = cuotaOver;
            CuotaUnder = cuotaUnder;
            DineroOver = dineroOver;
            DineroUnder = dineroUnder;

        }

        public EventoDTO()
        {

        }


    }
}