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

      
        public List<CitaM> MtListarCitasBarbero(int idBarbero)
        {
            return citaD.MtListarCitasBarbero(idBarbero);
        }

        public List<CitaM> MtListarCitasCliente(int idUsuario)
        {
            return citaD.MtListarCitasCliente(idUsuario);
        }

        public string MtGuardarCita(CitaM c)
        {
            // Validar disponibilidad del barbero
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
