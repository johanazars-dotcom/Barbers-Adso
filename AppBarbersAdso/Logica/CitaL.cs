using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppBarbersAdso.Datos;
using AppBarbersAdso.Modelo;

namespace AppBarbersAdso.Logica
{
    public class CitaL
    {
        CitaD citaD = new CitaD();

        public List<CitaM> MtListarCitas()
        {
            return citaD.MtListarCitas();
        }

        public string MtGuardarCita(CitaM c)
        {
            if (citaD.BarberoOcupado(c.idBarbero, c.fechaCita, c.hora))
            {
                return "ocupado";
            }

            citaD.MtGuardarCita(c);
            return "ok";
        }

        public void MtEliminarCita(int id)
        {
            citaD.MtEliminarCita(id);
        }
    }
}
