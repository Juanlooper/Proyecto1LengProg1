using System;

namespace SistemaTurnosMedicos
{
    class Program
    {
        static void Main(string[] args)
        {
            AsignadorTurnos asignador = new AsignadorTurnos();
            InterfazUsuario ui = new InterfazUsuario();
            
            while (true)
            {
                ui.MostrarEncabezado();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("1. Registrar nuevo turno");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("2. Salir");
                Console.ResetColor();
                Console.Write("Seleccione una opción: ");
                string opcionMenu = Console.ReadLine() ?? string.Empty;

                if (opcionMenu == "2") break;
                if (opcionMenu != "1")
                {
                    ui.MostrarError("Opción no válida.");
                    ui.Pausar();
                    continue;
                }

                ui.MostrarEncabezado();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--- Registro de Paciente ---");
                Console.ResetColor();
                
                string nombre = ObtenerEntrada("Ingrese el nombre del paciente: ", (s) => !string.IsNullOrWhiteSpace(s), "El nombre no puede estar vacío.");
                string apellido = ObtenerEntrada("Ingrese el apellido del paciente: ", (s) => !string.IsNullOrWhiteSpace(s), "El apellido no puede estar vacío.");
                
                int edad = 0;
                while (true)
                {
                    Console.Write("Ingrese la edad del paciente: ");
                    string edadStr = Console.ReadLine() ?? string.Empty;
                    if (int.TryParse(edadStr, out edad) && edad >= 0 && edad <= 120) break;
                    ui.MostrarError("Edad inválida. Ingrese un número entero entre 0 y 120.");
                }

                Paciente pacienteActual = new Paciente(nombre, apellido, edad);
                
                int opcionEspecialidad = 0;
                while (true)
                {
                    ui.MostrarMenuEspecialidades();
                    Console.Write("Seleccione la especialidad deseada (1-3): ");
                    string opStr = Console.ReadLine() ?? string.Empty;
                    if (int.TryParse(opStr, out opcionEspecialidad) && opcionEspecialidad >= 1 && opcionEspecialidad <= 3) break;
                    ui.MostrarError("Opción no válida.");
                }

                ui.MostrarProcesando("Generando turno y calculando tiempo de espera");

                string turnoAsignado = asignador.AsignarTurno(opcionEspecialidad);
                int tiempoEspera = asignador.CalcularTiempoEspera(opcionEspecialidad);
                string nombreEspecialidad = asignador.ObtenerNombreEspecialidad(opcionEspecialidad);

                ui.MostrarResumenTurno(pacienteActual, nombreEspecialidad, turnoAsignado, tiempoEspera);
                ui.Pausar();
            }

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("======================================================");
            Console.WriteLine("  Gracias por utilizar el Sistema de Control de Turnos");
            Console.WriteLine("             ¡Que tenga un excelente día!");
            Console.WriteLine("======================================================");
            Console.ResetColor();
        }

        static string ObtenerEntrada(string prompt, Func<string, bool> validar, string mensajeError)
        {
            while (true)
            {
                Console.Write(prompt);
                string entrada = Console.ReadLine() ?? string.Empty;
                if (validar(entrada)) return entrada;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"[ERROR] {mensajeError}");
                Console.ResetColor();
            }
        }
    }
}
