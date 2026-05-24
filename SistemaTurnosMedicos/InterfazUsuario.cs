using System;

namespace SistemaTurnosMedicos
{
    /// <summary>
    /// Clase encargada de manejar la interacción visual con el usuario (estética en consola).
    /// </summary>
    public class InterfazUsuario
    {
        /// <summary>
        /// Muestra el encabezado principal del sistema.
        /// </summary>
        public void MostrarEncabezado()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("======================================================");
            Console.WriteLine("       SISTEMA DE CONTROL DE TURNOS MÉDICOS");
            Console.WriteLine("======================================================");
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Muestra el menú de especialidades disponibles.
        /// </summary>
        public void MostrarMenuEspecialidades()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("--- Especialidades Disponibles ---");
            Console.ResetColor();
            Console.WriteLine("1. Medicina General");
            Console.WriteLine("2. Pediatría");
            Console.WriteLine("3. Cardiología");
            Console.WriteLine("----------------------------------");
        }

        /// <summary>
        /// Imprime un mensaje de error con color rojo.
        /// </summary>
        public void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] {mensaje}");
            Console.ResetColor();
        }

        /// <summary>
        /// Muestra el resumen final del turno asignado de forma estética.
        /// </summary>
        public void MostrarResumenTurno(Paciente paciente, string especialidad, string numeroTurno, int tiempoEsperaMinutos)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("================ RESUMEN DE TURNO ================");
            Console.ResetColor();
            Console.WriteLine($" Paciente:             {paciente.ObtenerNombreCompleto()}");
            Console.WriteLine($" Edad:                 {paciente.Edad} años");
            Console.WriteLine($" Especialidad:         {especialidad}");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($" NÚMERO DE TURNO:      {numeroTurno}");
            Console.ResetColor();
            
            // Lógica para mostrar horas y minutos si el tiempo es mayor o igual a 60 min
            if (tiempoEsperaMinutos >= 60)
            {
                int horas = tiempoEsperaMinutos / 60;
                int minutos = tiempoEsperaMinutos % 60;
                Console.WriteLine($" Tiempo est. de espera: {horas} hora(s) y {minutos} minuto(s)");
            }
            else
            {
                Console.WriteLine($" Tiempo est. de espera: {tiempoEsperaMinutos} minuto(s)");
            }
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("==================================================");
            Console.ResetColor();
        }

        /// <summary>
        /// Espera a que el usuario presione una tecla antes de continuar.
        /// </summary>
        public void Pausar()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Presione cualquier tecla para continuar...");
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
