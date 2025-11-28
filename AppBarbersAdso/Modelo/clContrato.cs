using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppBarbersAdso.Modelo
{
    public class clContrato
    {
        public int idContrato { get; set; }
        public string numeroPuesto { get; set; }
        public string nombreBarbero { get; set; }
        public string apellidoBarbero { get; set; }
        public string estadoContrato { get; set; }
        public string tipoContrato { get; set; }
        public string ultimoPago { get; set; }
    }
}