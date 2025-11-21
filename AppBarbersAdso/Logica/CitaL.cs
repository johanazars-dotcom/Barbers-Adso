using System.Collections.Generic;
using Modelos;
using Datos;

namespace Logica
{
    public class CitaL
    {
        private CitaD Datos = new CitaD();

        public List<CitaM> Listar() => Datos.Listar();
        public void GuardarCita(CitaM c) => Datos.Guardar(c);
        public void Eliminar(int id) => Datos.Eliminar(id);
    }
}
