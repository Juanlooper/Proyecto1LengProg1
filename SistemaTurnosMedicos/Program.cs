using System;

namespace SistemaTurnosMedicos
{
    class Program
    {
        static void Main(string[] args)
        {
            // Instanciamos los objetos necesarios que controlarán el flujo del programa
            AsignadorTurnos asignador = new AsignadorTurnos();
            InterfazUsuario ui = new InterfazUsuario();
            
            bool continuarEjecucion = true;

            // Ciclo do-while para permitir el registro de múltiples turnos
            do
            {
                ui.MostrarEncabezado();
                
                // --- 1. Solicitar datos básicos del paciente ---
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("--- Registro de Paciente ---");
                Console.ResetColor();
                
                Console.Write("Ingrese el nombre del paciente: ");
                string nombre = Console.ReadLine() ?? string.Empty;
                
                Console.Write("Ingrese el apellido del paciente: ");
                string apellido = Console.ReadLine() ?? string.Empty;
                
                // Validación básica de entrada con estructura if
                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido))
                {
                    ui.MostrarError("El nombre y apellido no pueden estar vacíos.");
                    ui.Pausar();
                    continue; // Reinicia el ciclo para volver a pedir los datos
                }

                Console.Write("Ingrese la edad del paciente: ");
                string edadStr = Console.ReadLine() ?? string.Empty;
                int edad;

                // Validación para asegurar que la edad es un número válido
                if (!int.TryParse(edadStr, out edad) || edad < 0 || edad > 120)
                {
                    ui.MostrarError("Edad inválida. Por favor, ingrese un número entero entre 0 y 120.");
                    ui.Pausar();
                    continue;
                }

                // Instancia de la clase Paciente
                Paciente pacienteActual = new Paciente(nombre, apellido, edad);
                Console.WriteLine();

                // --- 2. Mostrar menú de especialidades y capturar selección ---
                ui.MostrarMenuEspecialidades();
                Console.Write("Seleccione la especialidad deseada (1-3): ");
                string opcionStr = Console.ReadLine() ?? string.Empty;
                int opcionEspecialidad;

                // Validación para la selección de especialidad
                if (!int.TryParse(opcionStr, out opcionEspecialidad) || opcionEspecialidad < 1 || opcionEspecialidad > 3)
                {
                    ui.MostrarError("Opción no válida. Debe seleccionar un número del 1 al 3.");
                    ui.Pausar();
                    continue;
                }

                // --- 3. Asignación de Turno y Cálculo de Tiempo ---
                // Uso de los métodos de la clase AsignadorTurnos
                string turnoAsignado = asignador.AsignarTurno(opcionEspecialidad);
                int tiempoEspera = asignador.CalcularTiempoEspera(opcionEspecialidad);
                string nombreEspecialidad = asignador.ObtenerNombreEspecialidad(opcionEspecialidad);

                // --- 4. Mostrar resumen del turno ---
                ui.MostrarResumenTurno(pacienteActual, nombreEspecialidad, turnoAsignado, tiempoEspera);

                // --- 5. Preguntar si se desea registrar otro turno ---
                Console.WriteLine();
                Console.Write("¿Desea registrar otro turno? (S/N): ");
                string respuesta = Console.ReadLine() ?? string.Empty;

                if (respuesta != null && respuesta.Trim().ToUpper() == "N")
                {
                    continuarEjecucion = false;
                }

            } while (continuarEjecucion);

            // Mensaje final de despedida
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("======================================================");
            Console.WriteLine("  Gracias por utilizar el Sistema de Control de Turnos");
            Console.WriteLine("             ¡Que tenga un excelente día!");
            Console.WriteLine("======================================================");
            Console.ResetColor();
        }
    }
}
