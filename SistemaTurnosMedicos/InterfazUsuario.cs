using System;

namespace SistemaTurnosMedicos
{
    // Toda la parte de los colores, los menúes y lo que ve el usuario en la consola lo puse en esta clase para no mezclarlo con la lógica.
    public class InterfazUsuario
    {
        // Pinta el título bonito que aparece arriba de todo.
        public void MostrarEncabezado()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("   +=============================================+");
            Console.WriteLine("   |                                             |");
            Console.WriteLine("   |     SISTEMA DE CONTROL DE TURNOS MÉDICOS    |");
            Console.WriteLine("   |            ~ Clinica La Salud ~             |");
            Console.WriteLine("   |                                             |");
            Console.WriteLine("   +=============================================+");
            Console.ResetColor();
            Console.WriteLine();
        }

        // Hace una pequeña animación con puntitos para simular que el programa está pensando.
        public void MostrarProcesando(string mensaje)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.Write(mensaje);
            for (int i = 0; i < 3; i++)
            {
                System.Threading.Thread.Sleep(600); // Pausa de 600ms
                Console.Write(".");
            }
            Console.WriteLine();
            Console.ResetColor();
        }

        // Muestra las opciones de áreas médicas que el paciente puede elegir.
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

        // Pinta los errores de rojo para que el usuario se dé cuenta rápido que hizo algo mal.
        public void MostrarError(string mensaje)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERROR] {mensaje}");
            Console.ResetColor();
        }

        // Muestra el resultado final con los datos del paciente y su turno, acomodado para que se vea bien.
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
            
            // Esto lo agregué para que si la espera es de 60 min o más, lo muestre en horas en vez de solo minutos
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

        // Pausa el programa hasta que el usuario toque cualquier tecla para poder leer antes de que limpie la pantalla.
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
