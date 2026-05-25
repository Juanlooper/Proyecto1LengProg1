# Sistema de Control de Turnos Médicos

Este es mi proyecto para la clase de Programación I (Módulo II). Es un sistema de consola básico hecho en C# (.NET 8.0) que sirve para registrar pacientes y asignarles turnos en una clínica llamada "Clínica La Salud".

Lo desarrollé aplicando lo que aprendimos en clase sobre Programación Orientada a Objetos (POO), manejo estricto de excepciones (para que no se caiga el programa si el usuario mete un dato mal) y le puse un diseño de consola un poco más dinámico y creativo.

Algo muy importante de este proyecto es que está hecho sin usar arreglos (arrays), vectores ni matrices. Esa era una de las reglas del trabajo, así que todo funciona exclusivamente usando ciclos, condicionales y clases.

## Características Principales

*   **Gestión de Pacientes:** El programa te pide los datos básicos de la persona, que en este caso son el Nombre, Apellido y Edad.
*   **Asignación Inteligente de turnos:** El sistema genera tickets en orden secuencial dependiendo de la especialidad médica que elijas:
    *   Medicina General: te da un ticket tipo MG-01, MG-02...
    *   Pediatría: te da un ticket tipo PE-01, PE-02...
    *   Cardiología: te da un ticket tipo CA-01, CA-02...
*   **Cálculo Dinámico de Espera:** Te dice aproximadamente cuánto vas a tener que esperar. Esto lo calcula automáticamente dependiendo de la cantidad de turnos que ya se dieron en esa especialidad. Medicina general suma 15 minutos por cada turno previo, pediatría suma 20 minutos y cardiología suma 30 minutos.
*   **Validación de Datos (Anti-Crash):** Le puse validaciones bastante robustas usando delegados (`Func<string, bool>`) y bloques `TryParse`. Esto hace que si por ejemplo escribes letras donde va la edad, el programa no se cierre de golpe, sino que te avise del error y te deje volver a intentarlo sin perder el progreso.
*   **Diseño Visual:** Le agregué algunos detalles para que se vea mejor en la consola:
    *   Colores diferentes para los mensajes de error, opciones y los resultados finales.
    *   Una pequeña animación de carga simulada al momento de asignar los turnos.
    *   Banners con formato enmarcado.

## Arquitectura del Código

El código lo estructuré siguiendo el principio de Responsabilidad Única para no depender de arreglos y mantener todo ordenado. Lo dividí en cuatro clases principales:

1.  `Program.cs`: Es el punto de entrada de la aplicación. Acá armé el menú principal, controlo el ciclo de repetición (`while`) y gestiono cómo se le piden los datos al usuario usando métodos de captura segura.
2.  `AsignadorTurnos.cs`: Este es el núcleo matemático del programa. Se encarga de toda la lógica de asignación usando una estructura `switch`. También lleva el control de los mostradores (usando contadores independientes en vez de listas) y calcula los tiempos de espera.
3.  `InterfazUsuario.cs`: Toda la parte visual (la estética) está manejada exclusivamente por esta clase. Centralicé los métodos para pintar errores en rojo, los menús en colores, los banners y las animaciones.
4.  `Paciente.cs`: Es el modelo de datos. Funciona como el molde o plantilla que representa a la persona que se está registrando en la memoria RAM en ese momento.

## Requisitos para Ejecutar

Para correr este proyecto necesitas tener instalado en tu computadora:

*   .NET SDK 8.0 o alguna versión superior.

## Instrucciones de Uso

1.  Descarga o clona la carpeta de este repositorio en tu computadora.
2.  Abre una terminal o consola de comandos y navega hasta la carpeta del proyecto.
    ```bash
    cd SistemaTurnosMedicos
    ```
3.  Compila y ejecuta la aplicación escribiendo el comando:
    ```bash
    dotnet run
    ```
4.  Sigue las instrucciones del menú en pantalla para registrar pacientes o salir del programa.

## Autor / Equipo

Proyecto académico desarrollado para el Módulo II de la materia Programación I.
Elaborado sin el uso de matrices ni arreglos, aplicando exclusivamente estructuras cíclicas, condicionales y Programación Orientada a Objetos.