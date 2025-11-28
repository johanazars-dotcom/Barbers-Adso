using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarbersAdso.Modelo
{
    public class FinanzaM
    {
        public int IdFinanzas { get; set; }
        public string Pago { get; set; }
        public int IdPuesto { get; set; }
        public int IdContrato { get; set; }
        public int IdAdministrador { get; set; }
    }
}