using Dsw2026Ej11.Domain;

namespace Dsw2026Ej11.Collections;

//Crear un campo que represente una lista de alumnos (List<>)
//Incluir un método para agregar alumnos a la lista
//Incluir un método para retornar la lista
//Incluir un método para buscar un alumno por nombre
//Incluir un método para eliminar un alumno (debe recibir un alumno)
//Incluir un método para eliminar un alumno en una determinada posición de la lista
public class CasoList
{
    // Campo privado y de solo lectura que representa nuestra lista
    private readonly List<Alumno> _alumnos = new();

    // Método para agregar alumnos a la lista
    public void AgregarAlumno(Alumno alumno)
    {
        if (alumno == null) throw new ArgumentNullException(nameof(alumno), "El alumno no puede ser nulo.");
        _alumnos.Add(alumno);
    }

    // Método para retornar la lista
    public List<Alumno> ObtenerLista()
    {
        return _alumnos;
    }

    // Método para buscar un alumno por nombre
    public Alumno? BuscarPorNombre(string nombre)
    {
        if (string.IsNullOrWhiteSpace(nombre)) return null;
        
        // Comparamos ignorando mayúsculas y minúsculas para una búsqueda más robusta
        return _alumnos.FirstOrDefault(a => a.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
    }

    // Método para eliminar un alumno (debe recibir un alumno)
    public bool EliminarAlumno(Alumno alumno)
    {
        if (alumno == null) throw new ArgumentNullException(nameof(alumno), "El alumno a eliminar no puede ser nulo.");
        return _alumnos.Remove(alumno);
    }

    // Método para eliminar un alumno en una determinada posición de la lista
    public void EliminarEnPosicion(int indice)
    {
        // Validamos que el índice se encuentre dentro de los límites de la lista
        if (indice >= 0 && indice < _alumnos.Count)
        {
            _alumnos.RemoveAt(indice);
        }
        else
        {
            throw new ArgumentOutOfRangeException(nameof(indice), "El índice se encuentra fuera del rango de la lista.");
        }
    }
}
