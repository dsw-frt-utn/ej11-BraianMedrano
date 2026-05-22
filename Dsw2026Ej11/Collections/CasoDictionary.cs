using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Collections;

//Crear un diccionario donde la clave sea el legajo y el valor el alumno
//Incluir un método para agregar un alumno al diccionario
//Incluir un método para buscar un alumno utilizando la clave
//Incluir un método para retornar el diccionario
//Incluir un método para eliminar un alumno utilizando la clave
public class CasoDictionary
{
    private readonly Dictionary<int, Alumno> _alumnos = new();

    // un diccionario es una colección de pares clave-valor, donde cada clave es única y se utiliza para acceder a su valor asociado. En este caso, la clave es el legajo del alumno (un número entero) y el valor es un objeto Alumno que contiene la información del alumno.

    public void AgregarAlumno(Alumno alumno)
    {
        if (alumno == null) throw new ArgumentNullException(nameof(alumno));
        _alumnos[alumno.Id] = alumno;
    }

    public Alumno? BuscarAlumno(int legajo)
    {
        return _alumnos.TryGetValue(legajo, out Alumno? alumno) ? alumno : null;
    }

    public Dictionary<int, Alumno> ObtenerDiccionario()
    {
        // Primero verificamos si el diccionario está vacío para evitar retornar un diccionario nulo o vacío.
        if (_alumnos.Count == 0)
        {
            throw new InvalidOperationException("El diccionario de alumnos está vacío.");
        }
        return _alumnos;
    }

    public void EliminarAlumno(int legajo)
    {
        if (!_alumnos.Remove(legajo))
        {
            throw new KeyNotFoundException($"No se encontró un alumno con el legajo {legajo} para eliminar.");
        }
    }


}
