using System;

namespace SistemaTurnosMedicos
{
    /// <summary>
    /// Clase que representa a un paciente en el consultorio médico.
    /// </summary>
    public class Paciente
    {
        // Atributos básicos del paciente
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        /// <summary>
        /// Constructor para inicializar los datos del paciente.
        /// </summary>
        /// <param name="nombre">Nombre del paciente.</param>
        /// <param name="apellido">Apellido del paciente.</param>
        /// <param name="edad">Edad del paciente.</param>
        public Paciente(string nombre, string apellido, int edad)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
        }

        /// <summary>
        /// Retorna el nombre completo del paciente.
        /// </summary>
        public string ObtenerNombreCompleto()
        {
            return $"{Nombre} {Apellido}";
        }
    }
}
