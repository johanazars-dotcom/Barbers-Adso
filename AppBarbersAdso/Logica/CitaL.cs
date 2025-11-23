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

        // GUARDAR O EDITAR CITA
        public string MtGuardarCita(CitaM c)
        {
            // Validar si el barbero ya tiene una cita a esa misma fecha y hora
            if (citaD.BarberoOcupado(c.idBarbero, c.fechaCita, c.hora))
            {
                return "ocupado";
            }

            citaD.MtGuardarCita(c);
            return "ok";
        }

        // ELIMINAR CITA
        public void MtEliminarCita(int id)
        {
            citaD.MtEliminarCita(id);
        }
    }
}
