using System;

namespace SistemaTurnosMedicos
{
    // Esta clase es como un molde para guardar los datos de cada paciente que se va registrando en memoria.
    public class Paciente
    {
        // Acá guardo los datos básicos que me pide el programa
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Edad { get; set; }

        // Este es el constructor que uso cuando creo un nuevo paciente con new Paciente(...)
        //El nombre de la persona.</param>
        //El apellido de la persona.</param>
        //Cuántos años tiene.</param>
        public Paciente(string nombre, string apellido, int edad)
        {
            Nombre = nombre;
            Apellido = apellido;
            Edad = edad;
        }

        // Una funcioncita rápida para pegar el nombre y el apellido y no tener que hacerlo a mano en cada WriteLine.
        public string ObtenerNombreCompleto()
        {
            return $"{Nombre} {Apellido}";
        }
    }
}
