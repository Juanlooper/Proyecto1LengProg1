using System;

namespace SistemaTurnosMedicos
{
    /// <summary>
    /// Clase responsable de gestionar la asignación de turnos y calcular tiempos de espera.
    /// </summary>
    public class AsignadorTurnos
    {
        // Contadores de turnos por especialidad (sin usar arreglos)
        private int turnosMedicinaGeneral;
        private int turnosPediatria;
        private int turnosCardiologia;

        // Tiempo fijo de atención en minutos por cada paciente (definido por el programador)
        private const int TiempoAtencionPorTurno = 15;

        public AsignadorTurnos()
        {
            turnosMedicinaGeneral = 0;
            turnosPediatria = 0;
            turnosCardiologia = 0;
        }

        /// <summary>
        /// Asigna un turno secuencial basado en la especialidad seleccionada.
        /// </summary>
        /// <param name="opcionEspecialidad">Opción numérica del menú de especialidades.</param>
        /// <returns>El número de turno asignado (ej. MG-01).</returns>
        public string AsignarTurno(int opcionEspecialidad)
        {
            // Uso de la estructura switch solicitada para la selección
            switch (opcionEspecialidad)
            {
                case 1:
                    turnosMedicinaGeneral++;
                    return $"MG-{turnosMedicinaGeneral:D2}";
                case 2:
                    turnosPediatria++;
                    return $"PE-{turnosPediatria:D2}";
                case 3:
                    turnosCardiologia++;
                    return $"CA-{turnosCardiologia:D2}";
                default:
                    return "Invalido"; // Esto no debería ocurrir debido a las validaciones previas
            }
        }

        /// <summary>
        /// Calcula el tiempo estimado de espera en minutos.
        /// </summary>
        /// <param name="opcionEspecialidad">Opción numérica de la especialidad.</param>
        /// <returns>Tiempo estimado de espera en minutos.</returns>
        public int CalcularTiempoEspera(int opcionEspecialidad)
        {
            int turnosPrevios = 0;
            int tiempoAtencion = 0;

            // Se determina cuántos turnos previos hay en esa especialidad
            // Al asignar un turno ya se incrementó el contador, por lo que restamos 1 para saber cuántos hay *antes*.
            if (opcionEspecialidad == 1)
            {
                turnosPrevios = turnosMedicinaGeneral - 1;
                tiempoAtencion = 15; // Medicina General atiende cada 15 min
            }
            else if (opcionEspecialidad == 2)
            {
                turnosPrevios = turnosPediatria - 1;
                tiempoAtencion = 20; // Pediatría toma más tiempo, 20 min
            }
            else if (opcionEspecialidad == 3)
            {
                turnosPrevios = turnosCardiologia - 1;
                tiempoAtencion = 30; // Cardiología toma 30 min
            }

            return turnosPrevios * tiempoAtencion;
        }

        /// <summary>
        /// Obtiene el nombre de la especialidad basado en la opción.
        /// </summary>
        public string ObtenerNombreEspecialidad(int opcionEspecialidad)
        {
            switch (opcionEspecialidad)
            {
                case 1: return "Medicina General";
                case 2: return "Pediatría";
                case 3: return "Cardiología";
                default: return "Desconocida";
            }
        }
    }
}
