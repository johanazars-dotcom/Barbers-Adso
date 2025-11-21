using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Modelos; // Necesario para usar la clase CitaM

namespace Logica
{
    // Renombrada a CitaL para mantener la consistencia con el modelo y la capa de datos.
    public class CitaL
    {
        // Instancia la capa de acceso a datos corregida.
        private Datos.CitaD datos = new Datos.CitaD();

        /// <summary>
        /// Obtiene el historial de citas de un usuario específico.
        /// Llama directamente al método en la capa de datos.
        /// </summary>
        /// <param name="idUsuario">El ID del usuario logueado.</param>
        /// <returns>Una lista de objetos CitaM.</returns>
        public List<CitaM> ObtenerHistorial(int idUsuario)
        {
            // Llama al método ObtenerHistorial de la capa de datos (CitaD)
            return datos.ObtenerHistorial(idUsuario);
        }

        /// <summary>
        /// Llama al método para listar todas las citas.
        /// </summary>
        public List<CitaM> ListarTodasLasCitas()
        {
            // Llama al método Listar de la capa de datos (CitaD)
            return datos.Listar();
        }

        // Aquí se agregarían otros métodos de lógica como GuardarCita(CitaM c), 
        // ValidarFechaDisponible(), etc.
    }
}