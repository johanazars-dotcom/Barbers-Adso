using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppBarbersAdso.Modelo;
using System.Data;

namespace AppBarbersAdso.Logica
{

    public class FinanzaL
    {
        FinanzaD dal = new FinanzaD();

        public DataTable ListarPagos()
        {
            return dal.ObtenerPagos();
        }

        public bool CrearPago(FinanzaM f)
        {
            return dal.RegistrarPago(f);
        }
    }

}