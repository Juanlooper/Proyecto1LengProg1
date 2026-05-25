using System;

namespace SistemaTurnosMedicos
{
    // Esta clase es la que hace toda la matemática. Lleva la cuenta de los turnos y calcula cuánto hay que esperar.
    public class AsignadorTurnos
    {
        // Acá llevo la cuenta de los turnos de cada área. No uso arreglos porque era regla del proyecto.
        private int turnosMedicinaGeneral;
        private int turnosPediatria;
        private int turnosCardiologia;

        // Tiempo fijo que tarda cada consulta (lo definí yo para hacer el cálculo más fácil)
        private const int TiempoAtencionPorTurno = 15;

        public AsignadorTurnos()
        {
            turnosMedicinaGeneral = 0;
            turnosPediatria = 0;
            turnosCardiologia = 0;
        }

        // Genera el ticket en orden dependiendo de la especialidad que se eligió.
        //El número que el usuario metió en el menú.</param>
        //El texto del ticket, por ejemplo MG-01.</returns>
        public string AsignarTurno(int opcionEspecialidad)
        {
            // Usé el switch que vimos en clase para separar las opciones
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
                    return "Invalido"; // Pongo esto por si acaso, pero no debería llegar acá por las validaciones de antes
            }
        }

        // Saca la cuenta de cuántos minutos va a tener que esperar el paciente.
        //El área médica.</param>
        //Los minutos de espera.</returns>
        public int CalcularTiempoEspera(int opcionEspecialidad)
        {
            int turnosPrevios = 0;
            int tiempoAtencion = 0;

            // Reviso cuántos turnos se dieron antes en esa área.
            // Como al asignar el turno arriba ya le sumé 1 al contador, acá le resto 1 para saber cuántos había *antes*.
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

        // Solo sirve para devolver el nombre del área en texto en vez del número.
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
