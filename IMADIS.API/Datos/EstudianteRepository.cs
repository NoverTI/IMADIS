using IMADIS.API.Modelos;

namespace IMADIS.API.Datos
{
    public class EstudianteRepository : IEstudianteRepository
    {
        private static readonly List<Estudiante> _estudiantes = new()
        {
            new Estudiante { Id = 1, Nombre = "Juan", Apellido = "Pérez", Email = "juan.perez@example.com", FechaInscripcion = DateTime.Now.AddYears(-2) },
            new Estudiante { Id = 2, Nombre = "María", Apellido = "González", Email = "maria.gonzalez@example.com", FechaInscripcion = DateTime.Now.AddYears(-1) },
            new Estudiante { Id = 3, Nombre = "Carlos", Apellido = "Rodríguez", Email = "carlos.rodriguez@example.com", FechaInscripcion = DateTime.Now.AddMonths(-6) }
        };
        private static int _nextId = 4;

        public Task<IEnumerable<Estudiante>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Estudiante>>(_estudiantes);
        }

        public Task<Estudiante?> GetByIdAsync(int id)
        {
            var estudiante = _estudiantes.FirstOrDefault(e => e.Id == id);
            return Task.FromResult(estudiante);
        }

        public Task<Estudiante> CreateAsync(Estudiante estudiante)
        {
            estudiante.Id = _nextId++;
            _estudiantes.Add(estudiante);
            return Task.FromResult(estudiante);
        }

        public Task<Estudiante?> UpdateAsync(int id, Estudiante estudiante)
        {
            var existing = _estudiantes.FirstOrDefault(e => e.Id == id);
            if (existing == null)
                return Task.FromResult<Estudiante?>(null);

            existing.Nombre = estudiante.Nombre;
            existing.Apellido = estudiante.Apellido;
            existing.Email = estudiante.Email;
            existing.FechaInscripcion = estudiante.FechaInscripcion;

            return Task.FromResult<Estudiante?>(existing);
        }

        public Task<bool> DeleteAsync(int id)
        {
            var estudiante = _estudiantes.FirstOrDefault(e => e.Id == id);
            if (estudiante == null)
                return Task.FromResult(false);

            _estudiantes.Remove(estudiante);
            return Task.FromResult(true);
        }
    }
}
