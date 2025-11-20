using AppBarbersAdso.Modelo;
using Datos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Logica
{
    public class CitaL
    {
        CitaD datos = new CitaD();

        public List<CitaM> Listar() => datos.Listar();
        public void GuardarCita(CitaM c) => datos.Guardar(c);
        public void Eliminar(int id) => datos.Eliminar(id);
    }
}

