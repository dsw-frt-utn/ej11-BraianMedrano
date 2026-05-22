using Dsw2026Ej11.Collections;
using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Tests;


internal class Ejemplos
{
    //Agregar 3 alumnos a la lista
    //Listar por consola los alumnos
    //Buscar por nombre un alumno que exista y mostrar por consola
    //Buscar por nombre un alumno que no exista y mostrar por consola el texto "No existe"
    //Eliminar un alumno y listar por consola los alumnos
    //Eliminar el primer elemento de la lista y listar por consola los alumnos
    public static void EjemploList()
    {
        Console.WriteLine("\n=== INICIANDO EJEMPLO LIST ===");
        CasoList casoList = new CasoList();

        // Agregar 3 alumnos a la lista
        Alumno alumno1 = new Alumno(1, "Ana Martinez", 8.5);
        Alumno alumno2 = new Alumno(2, "Luis Gomez", 7.0);
        Alumno alumno3 = new Alumno(3, "Sofia Fernandez", 9.2);

        casoList.AgregarAlumno(alumno1);
        casoList.AgregarAlumno(alumno2);
        casoList.AgregarAlumno(alumno3);

        // Listar por consola los alumnos
        Console.WriteLine("\n--- Alumnos en la lista ---");
        foreach (var alumno in casoList.ObtenerLista())
        {
            Console.WriteLine(alumno);
        }

        // Buscar por nombre un alumno que exista y mostrar por consola
        Console.WriteLine("\n--- Buscando 'Luis Gomez' ---");
        Alumno? alumnoExistente = casoList.BuscarPorNombre("Luis Gomez");
        if (alumnoExistente != null)
        {
            Console.WriteLine($"Encontrado: {alumnoExistente}");
        }

        // Buscar por nombre un alumno que no exista y mostrar por consola el texto "No existe"
        Console.WriteLine("\n--- Buscando 'Pedro Sanchez' ---");
        Alumno? alumnoInexistente = casoList.BuscarPorNombre("Pedro Sanchez");
        if (alumnoInexistente == null)
        {
            Console.WriteLine("No existe");
        }

        // Eliminar un alumno y listar por consola los alumnos
        Console.WriteLine("\n--- Eliminando a 'Ana Martinez' ---");
        casoList.EliminarAlumno(alumno1);
        foreach (var alumno in casoList.ObtenerLista())
        {
            Console.WriteLine(alumno);
        }

        // Eliminar el primer elemento de la lista y listar por consola los alumnos
        Console.WriteLine("\n--- Eliminando el primer elemento (índice 0) ---");
        casoList.EliminarEnPosicion(0); // Ahora el primero debería ser Luis Gomez
        foreach (var alumno in casoList.ObtenerLista())
        {
            Console.WriteLine(alumno);
        }
    }

    //Agregar 3 alumnos al diccionario
    //Listar por consola los alumnos
    //Buscar un alumno por clave y mostrar por consola
    //Buscar un alumno por clave, pero que no exista, y mostrar por consola el texto "No existe"
    //Eliminar un alumno por clave y listar por consola los alumnos
    public static void EjemploDictionary()
    {
        Console.WriteLine("\n=== INICIANDO EJEMPLO DICTIONARY ===");
        // Crear una instancia de CasoDictionary para gestionar los alumnos
        CasoDictionary casoDictionary = new CasoDictionary();
        casoDictionary.AgregarAlumno(new Alumno(1, "Juan Pérez", 8.5));
        casoDictionary.AgregarAlumno(new Alumno(2, "María García", 9.0));
        casoDictionary.AgregarAlumno(new Alumno(3, "Carlos López", 7.5));

        // Listar por consola los alumnos
        Console.WriteLine("\n--- Alumnos en el diccionario ---");
        foreach (var alumno in casoDictionary.ObtenerDiccionario().Values)
        {
            Console.WriteLine($"Legajo: {alumno.Id}, Nombre: {alumno.Nombre}, Promedio: {alumno.Promedio}");
        }

        // Buscar un alumno por clave y mostrar por consola
        int legajoBuscar1 = 2;
        Console.WriteLine($"\n--- Buscando alumno con legajo {legajoBuscar1} ---");
        Alumno? alumnoEncontrado = casoDictionary.BuscarAlumno(legajoBuscar1);

        if (alumnoEncontrado != null)
        {
            Console.WriteLine($"Alumno encontrado: Legajo: {alumnoEncontrado.Id}, Nombre: {alumnoEncontrado.Nombre}, Promedio: {alumnoEncontrado.Promedio}");
        }

        // Buscar un alumno por clave, pero que no exista, y mostrar por consola el texto "No existe"
        int legajoBuscar2 = 4;
        Console.WriteLine($"\n--- Buscando alumno con legajo {legajoBuscar2} ---");
        Alumno? alumnoNoEncontrado = casoDictionary.BuscarAlumno(legajoBuscar2);

        if (alumnoNoEncontrado == null)
        {
            Console.WriteLine("No existe");
        }

        // Eliminar un alumno por clave y listar por consola los alumnos
        Console.WriteLine($"\n--- Eliminando alumno con legajo {legajoBuscar1} ---");
        casoDictionary.EliminarAlumno(legajoBuscar1);
        Console.WriteLine("Alumnos en el diccionario después de eliminar:");
        foreach (var alumno in casoDictionary.ObtenerDiccionario().Values)
        {
            Console.WriteLine($"Legajo: {alumno.Id}, Nombre: {alumno.Nombre}, Promedio: {alumno.Promedio}");
        }
    }

    //Realizar una llamada a cada método definido en CasoLinq y mostar por consola según corresponda
    public static void EjemploLinq()
    {
        Console.WriteLine("\n=== INICIANDO EJEMPLO LINQ ===");
        CasoLinq casoLinq = new CasoLinq();

        Console.WriteLine("\n--- 1. Obtener el primer libro ---");
        Libro? primero = casoLinq.GetPrimero();
        Console.WriteLine(primero != null ? $"{primero.Titulo} - {primero.Precio:C2}" : "No hay libros");

        Console.WriteLine("\n--- 2. Obtener el último libro ---");
        Libro? ultimo = casoLinq.GetUltimo();
        Console.WriteLine(ultimo != null ? $"{ultimo.Titulo} - {ultimo.Precio:C2}" : "No hay libros");

        Console.WriteLine("\n--- 3. Obtener la suma de precios ---");
        Console.WriteLine($"Total: {casoLinq.GetTotalPrecios():C2}");

        Console.WriteLine("\n--- 4. Obtener el promedio de precios ---");
        Console.WriteLine($"Promedio: {casoLinq.GetPromedioPrecios():C2}");

        Console.WriteLine("\n--- 5. Libros con Id mayor a 15 ---");
        foreach (var libro in casoLinq.GetListById())
        {
            Console.WriteLine($"[Id: {libro.Id}] {libro.Titulo}");
        }

        Console.WriteLine("\n--- 6. Lista de libros con formato moneda ---");
        foreach (var textoLibro in casoLinq.GetLibros())
        {
            Console.WriteLine(textoLibro);
        }

        Console.WriteLine("\n--- 7. Libro con el precio más alto ---");
        Libro? masCaro = casoLinq.GetMayorPrecio();
        Console.WriteLine(masCaro != null ? $"{masCaro.Titulo} ({masCaro.Precio:C2})" : "No hay libros");

        Console.WriteLine("\n--- 8. Libro con el precio más bajo ---");
        Libro? masBarato = casoLinq.GetMenorPrecio();
        Console.WriteLine(masBarato != null ? $"{masBarato.Titulo} ({masBarato.Precio:C2})" : "No hay libros");

        Console.WriteLine("\n--- 9. Libros cuyo precio sea mayor al promedio ---");
        foreach (var libro in casoLinq.GetMayorPromedio())
        {
            Console.WriteLine($"{libro.Titulo} ({libro.Precio:C2})");
        }

        Console.WriteLine("\n--- 10. Libros ordenados por título descendente ---");
        foreach (var libro in casoLinq.GetLibrosOrdenadosDescendente())
        {
            Console.WriteLine(libro.Titulo);
        }
    }
}
