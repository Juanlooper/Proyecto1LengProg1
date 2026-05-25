# 🏥 Sistema de Control de Turnos Médicos

![C#](https://img.shields.io/badge/C%23-239120?style=for-the-badge&logo=c-sharp&logoColor=white)
![.NET](https://img.shields.io/badge/.NET-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)
![Console App](https://img.shields.io/badge/Console-App-black?style=for-the-badge&logo=windows-terminal)

Un sistema de consola interactivo desarrollado en **C# (.NET 8.0)** para simular el registro y la asignación de turnos de atención médica en un consultorio (Clínica La Salud). 

Este proyecto fue desarrollado como cumplimiento del **Proyecto #1 de Programación I**, aplicando los principios de la Programación Orientada a Objetos (POO), manejo estricto de excepciones y diseño de consola dinámico.

---

## ✨ Características Principales

*   **Gestión de Pacientes:** Registro de datos básicos (Nombre, Apellido, Edad).
*   **Asignación Inteligente:** Generación de tickets secuenciales por especialidad médica (`MG-01`, `PE-02`, `CA-03`).
*   **Cálculo Dinámico de Espera:** El tiempo de atención estimado se calcula automáticamente dependiendo de la especialidad seleccionada:
    *   💊 *Medicina General:* 15 minutos por turno previo.
    *   🧸 *Pediatría:* 20 minutos por turno previo.
    *   ❤️ *Cardiología:* 30 minutos por turno previo.
*   **Validación de Datos (Anti-Crash):** Implementación de validaciones robustas mediante delegados (`Func<string, bool>`) y `TryParse`. El sistema guía al usuario ante entradas incorrectas sin reiniciar el progreso general.
*   **Diseño Visual Atractivo (Creatividad):**
    *   Interfaz coloreada para diferenciar encabezados, advertencias, opciones y resultados.
    *   Animación fluida (simulación de carga de sistema) al momento de asignar los turnos.
    *   Banners con formato enmarcado.

---

## 🏗️ Arquitectura del Código

El código fue estructurado siguiendo el principio de Responsabilidad Única para no depender de arreglos (arrays), vectores ni matrices. Se divide en cuatro clases principales:

1.  **`Program.cs`:** Punto de entrada de la aplicación. Orquesta el menú principal, controla el ciclo de repetición (`while`) y gestiona el flujo de peticiones hacia el usuario mediante métodos de captura segura.
2.  **`AsignadorTurnos.cs`:** El núcleo matemático. Se encarga de la lógica de asignación con la estructura `switch`, el control secuencial de los mostradores (usando contadores independientes) y el cálculo matemático del tiempo de espera.
3.  **`InterfazUsuario.cs`:** Maneja exclusivamente toda la interacción con la consola (estética visual). Centraliza los métodos para pintar errores en rojo, opciones en verde/amarillo, banners, el menú de opciones y las animaciones de carga.
4.  **`Paciente.cs`:** Modelo de datos. Funciona como el molde que representa a la entidad paciente dentro de la memoria RAM durante la asignación del turno.

---

## 🚀 Requisitos para Ejecutar

Para correr este proyecto necesitas tener instalado en tu computadora:

*   [.NET SDK 8.0 o superior](https://dotnet.microsoft.com/en-us/download).

---

## 💻 Instrucciones de Uso

1.  **Clona o descarga** este repositorio en tu máquina local.
2.  Abre una terminal o consola de comandos en la raíz del proyecto.
3.  Navega hasta la carpeta del código fuente:
    ```bash
    cd SistemaTurnosMedicos
    ```
4.  Compila y ejecuta la aplicación:
    ```bash
    dotnet run
    ```
5.  Sigue las instrucciones en pantalla para registrar pacientes, asignando turnos secuencialmente o abandonando el programa desde el menú principal.

---

## 📝 Autor / Equipo

Proyecto académico desarrollado para el Módulo II (Programación I).
*Elaborado sin el uso de matrices ni arreglos, aplicando exclusivamente estructuras cíclicas, condicionales y Programación Orientada a Objetos.*