using IMADIS.API.Datos;
using IMADIS.API.Modelos;

namespace IMADIS.API.Aplicacion
{
    public class EstudianteService : IEstudianteService
    {
        private readonly IEstudianteRepository _repository;

        public EstudianteService(IEstudianteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Estudiante>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Estudiante?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Estudiante> CreateAsync(Estudiante estudiante)
        {
            // Aquí podrían ir validaciones de negocio
            if (estudiante == null)
                throw new ArgumentNullException(nameof(estudiante));

            if (string.IsNullOrWhiteSpace(estudiante.Nombre))
                throw new ArgumentException("El nombre es requerido");
            
            if (string.IsNullOrWhiteSpace(estudiante.Apellido))
                throw new ArgumentException("El apellido es requerido");
            
            if (string.IsNullOrWhiteSpace(estudiante.Email))
                throw new ArgumentException("El email es requerido");

            return await _repository.CreateAsync(estudiante);
        }

        public async Task<Estudiante?> UpdateAsync(int id, Estudiante estudiante)
        {
            // Validaciones de negocio
            if (estudiante == null)
                throw new ArgumentNullException(nameof(estudiante));

            if (string.IsNullOrWhiteSpace(estudiante.Nombre))
                throw new ArgumentException("El nombre es requerido");
            
            if (string.IsNullOrWhiteSpace(estudiante.Apellido))
                throw new ArgumentException("El apellido es requerido");
            
            if (string.IsNullOrWhiteSpace(estudiante.Email))
                throw new ArgumentException("El email es requerido");

            return await _repository.UpdateAsync(id, estudiante);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            return await _repository.DeleteAsync(id);
        }
    }
}
