# Sistema de Control de Turnos Médicos - Guía Explicativa Completa

¡Hola! Este documento es una guía exhaustiva diseñada para que entiendas **cada línea de código** de este proyecto. Está escrito pensando en estudiantes y principiantes en la programación. Si te preguntan en la evaluación cómo funciona tu programa, aquí tienes absolutamente todas las respuestas.

---

## 1. Conceptos Básicos y Palabras Reservadas en C#

Antes de ver los archivos, es crucial entender las palabras clave que se repiten en todo el código:

*   **`using System;`**: Es como decirle al programa "Quiero usar la caja de herramientas básica de C#". `System` nos permite usar funciones básicas del lenguaje como `Console.WriteLine()` para imprimir en la pantalla.
*   **`namespace`**: Imagina que es una "carpeta lógica" o "apellido" para tus archivos. Todos nuestros archivos dicen `namespace SistemaTurnosMedicos`. Esto agrupa todas nuestras clases bajo un mismo techo, asegurando que todos se conocen entre sí y pertenecen al mismo proyecto.
*   **`class`** (Clase): Es un "molde" o "plano" para crear objetos. En programación orientada a objetos (POO), no escribimos todo de corrido; creamos moldes (ej. un molde `Paciente`) y luego creamos a los pacientes reales usando ese molde.
*   **Modificadores de Acceso (`public` y `private`)**: 
    *   **`public`**: Significa que otras partes del código pueden ver, leer y usar esa variable o método libremente. 
    *   **`private`**: Significa que es un secreto que solo pertenece a esa clase. Por ejemplo, en `AsignadorTurnos`, los contadores de turnos son privados para evitar que desde otra parte del código se modifiquen por accidente (o haciendo trampa).
*   **Tipos de datos**: 
    *   `string`: Sirve para guardar cadenas de texto (ej. "Juan", "Pediatría").
    *   `int`: Sirve para guardar números enteros sin decimales (ej. 1, 2, 25, 100).
    *   `bool`: Solo puede guardar dos estados: verdadero (`true`) o falso (`false`).
*   **`void`**: Se usa en la firma de los métodos (funciones) para decirle a la computadora: "Este método hace un trabajo, pero al terminar NO devuelve ningún valor". Por ejemplo, un método que solo imprime en pantalla.
*   **`return`**: Es lo opuesto a `void`. Se usa para devolver un resultado final a quien llamó a la función (por ejemplo, devolver el cálculo de los minutos de espera).
*   **`static`**: Significa que pertenece a la clase en general y no hace falta crear un "objeto" para usarlo. El método principal por donde arranca el programa (`static void Main`) siempre debe ser estático para que Windows sepa ejecutarlo de inmediato.
*   **`out`**: Es una palabra clave que le indica a un método que una variable que le estamos enviando será *modificada* y nos será *devuelta* con un valor nuevo desde adentro del método. Lo usamos mucho en el manejo de errores (lo veremos más abajo).

---

## 2. Cómo se conectan los archivos (Instanciación y Llamado de Métodos)

Una de las preguntas más comunes es: **¿Cómo hace `Program.cs` (el archivo principal) para usar el código que escribimos en otros archivos?**

En Programación Orientada a Objetos, esto se hace en dos pasos: **Instanciar** y **Llamar**.

### Paso 1: Instanciar (La palabra `new`)
En `Program.cs`, casi al principio del `Main`, vas a ver esto:
```csharp
AsignadorTurnos asignador = new AsignadorTurnos();
InterfazUsuario ui = new InterfazUsuario();
```
*   `AsignadorTurnos` es el *molde* (la clase) que está en el otro archivo.
*   `asignador` es la *variable* donde guardamos nuestro objeto real.
*   `new AsignadorTurnos();` es la orden que le dice a la memoria RAM de la computadora: "¡Construye un objeto real usando este molde!".
Hacemos lo mismo con la Interfaz de Usuario (`ui`). A partir de ese momento, `Program.cs` ya tiene acceso a las herramientas de esos otros archivos.

### Paso 2: Llamar a los métodos (El punto `.`)
Cuando queremos que la Interfaz haga algo, usamos nuestra variable `ui`, escribimos un punto (`.`) y el nombre del método:
```csharp
ui.MostrarEncabezado();
```
El punto (`.`) significa "de este objeto, usa esta habilidad". Así es como conectamos y hacemos que archivos separados interactúen entre sí como un equipo.

---

## 3. Explicación Archivo por Archivo

El proyecto está dividido en 4 clases para mantener el orden (esto es clave en POO y da puntos en la rúbrica).

### A) `Paciente.cs`
Este archivo es el molde para crear pacientes. Solo guarda datos.
*   **Propiedades (`get; set;`)**: `public string Nombre { get; set; }`. El `get` (obtener) permite que leamos el nombre después, y el `set` (establecer) permite asignarle un nombre en primer lugar.
*   **El Constructor (`public Paciente(string nombre, string apellido, int edad)`)**: Es un método especial que tiene *el mismo nombre* que la clase. Se ejecuta **automáticamente** en el momento que usamos la palabra `new`. Sirve para exigir que desde el momento cero, el paciente ya nazca con su nombre, apellido y edad.
*   **Interpolación de strings (`$"{Nombre} {Apellido}"`)**: El símbolo `$` antes de las comillas nos permite meter variables directamente adentro de las llaves `{}` para unir texto fácilmente, sin usar el signo `+`.

### B) `AsignadorTurnos.cs`
Aquí está toda la lógica matemática. **La regla de oro del proyecto era NO usar arreglos, vectores ni matrices**, por lo que cumplimos esto usando contadores individuales.
*   **`turnosMedicinaGeneral`, `turnosPediatria`, `turnosCardiologia`**: Son los contadores individuales que arrancan en cero.
*   **`switch (opcionEspecialidad)`**: Es una estructura de control ideal para menús. "En caso (`case`) de que haya elegido 1, suma un turno a Medicina General. En caso (`case`) 2, suma a Pediatría". Es mucho más rápido de leer que usar muchos `if` anidados.
*   **`turnosMedicinaGeneral++`**: Es un atajo para escribir `turnosMedicinaGeneral = turnosMedicinaGeneral + 1`. Básicamente, incrementa el número de la fila.
*   **Formato de dígitos (`:D2`)**: Cuando retornamos el turno (ej. `$"MG-{turnosMedicinaGeneral:D2}"`), el `:D2` le dice a la computadora: "Siempre ponle 2 dígitos a este número". Así, si es el turno 1, imprime "01".

### C) `InterfazUsuario.cs`
Para que la clase `Program` no se llene de código feo de colores y textos, sacamos la "estética" a esta clase.
*   **`Console.ForegroundColor = ConsoleColor.Cyan;`**: Cambia el color de la letra que se va a imprimir a continuación.
*   **`Console.ResetColor();`**: ¡Vital! Devuelve el color al blanco original. Si no lo pones, toda la consola se quedaría pintada de colores extraños para siempre.
*   **`Console.Clear();`**: "Borra el pizarrón". Limpia la pantalla para que el menú luzca como una aplicación nueva y no como una consola amontonada.
*   **`Console.ReadKey();`**: Detiene el programa y espera a que el usuario presione cualquier tecla física para continuar.

### D) `Program.cs` (El Director de la Orquesta)
Es la clase que contiene el `static void Main`, que es donde Windows sabe que debe iniciar la ejecución. Aquí es donde ocurre el ciclo principal (las repeticiones).

---

## 4. El Ciclo Paso a Paso (`do-while`)

Uno de los requisitos era permitir "registrar varios turnos hasta que el usuario decida finalizar". Para esto usamos un ciclo `do-while`.

**¿Por qué `do-while` y no `while` normal?**
La palabra `do` significa "hacer". El ciclo `do-while` asegura que el código se ejecute **por lo menos una vez** (ya que primero necesitamos mostrarle el menú al paciente al menos la primera vez) y, al final del todo (`while`), pregunta si queremos repetir.

**El flujo ocurre así:**
1.  **Inicio**: Se declara `bool continuarEjecucion = true;`. Esto es nuestra "bandera" de estado.
2.  **Apertura (`do {`)**: Entramos al ciclo.
3.  **Paso 1 (Ingreso)**: Se le pide nombre, apellido y edad al usuario. (Aquí ocurre la validación de errores).
4.  **Paso 2 (Menú)**: Se le pide elegir especialidad 1, 2 o 3. (Validación de errores otra vez).
5.  **Paso 3 (Proceso)**: Llamamos a `asignador.AsignarTurno()` pasándole la opción que eligió el usuario. El método hace el cálculo internamente y nos devuelve el número del ticket.
6.  **Paso 4 (Salida)**: Llamamos a `ui.MostrarResumenTurno(...)` y le mandamos todos los datos (el paciente, la especialidad y el ticket) para que lo imprima bonito con colores.
7.  **Paso 5 (La Pregunta)**: Le preguntamos al usuario `¿Desea registrar otro turno? (S/N)`. Si teclea "N", cambiamos nuestra bandera `continuarEjecucion` a `false`.
8.  **Cierre (`} while(continuarEjecucion);`)**: Aquí la computadora evalúa la bandera. Si sigue siendo `true` (el usuario puso "S"), el programa "salta" de regreso arriba a la palabra `do` y limpia la pantalla. Si es `false`, el ciclo se rompe, el programa "escapa" de las llaves y muestra el mensaje de despedida final.

---

## 5. ¿Cómo funciona el Control de Errores? (Manejo de Excepciones)

Si un usuario malicioso ingresa una letra "A" cuando le pides su edad, el programa normalmente "explotaría" (crash). Para evitarlo y ganar todos los puntos, usamos validaciones profesionales en `Program.cs`.

#### A. Validación de Textos Vacíos
```csharp
if (string.IsNullOrWhiteSpace(nombre))
```
*   **¿Para qué sirve?** Comprueba si el usuario le dio a 'Enter' sin teclear su nombre, o si trató de engañar al programa tecleando solo barras espaciadoras.
*   **¿Qué es `continue`?** Si detectamos el error (es `true`), mostramos un aviso en rojo y usamos la palabra **`continue;`**. Esta palabra es mágica: le dice al ciclo `do-while`: "Olvida lo que estabas haciendo, aborta esta iteración y **regresa al principio de inmediato**" para volver a pedir los datos.

#### B. Validación de Números (El poder de `TryParse` y `out`)
```csharp
if (!int.TryParse(edadStr, out edad) || edad < 0 || edad > 120)
```
Esta es la parte más técnica para leer números en C#:
1.  **`Console.ReadLine()`** SIEMPRE captura texto (string). Si el usuario escribe "15", para la PC eso es la palabra "15", no un valor matemático.
2.  **`int.TryParse(edadStr, out edad)`**: Es un método especial que "intenta traducir". Significa: "Intenta traducir el texto `edadStr` a un número matemático".
3.  **La palabra `out`**: Como `TryParse` necesita decirnos dos cosas a la vez (1: "Si tuvo éxito o no" y 2: "El número ya convertido"), usamos `out edad`. Significa: "Si logras traducir el texto a número, *escupelo* o *sácate* el número convertido hacia afuera y guárdalo en mi variable vacía llamada `edad`".
    *   Si el usuario escribió "Hola", falla al traducir, devuelve `false`, y no rompe nada.
4.  **El símbolo `!` (Not)**: Significa negación lógica. Toda la línea se lee: "Si **NO** se pudo traducir a número, **O** (`||`) la edad es menor a 0, **O** la edad es mayor a 120, entonces hay un error."

#### C. El arreglo de las Advertencias (Warnings CS8600)
Viste que agregamos `?? string.Empty` al final de los `Console.ReadLine()`.
*   A veces, bajo ciertas condiciones extremas, la consola podría devolver un valor nulo (`null`), que literalmente significa "vacío absoluto" (peor que un texto en blanco).
*   El operador `??` (Null-coalescing) funciona como un seguro de vida. 
*   Se lee así: "Lee lo que escriba el usuario. **PERO SI** resulta ser `null`, no causes un error, sino que reemplázalo automáticamente por `string.Empty` (un texto vacío `""`)". Así nos curamos en salud.

---
**¡Con esta guía están preparados para cualquier pregunta que el profesor les haga! Todo el proyecto está construido bajo buenas prácticas, cumpliendo al 100% su rúbrica y con una presentación visual superior al promedio.**
