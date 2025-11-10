using IMADIS.API.Modelos;

namespace IMADIS.API.Datos
{
    public interface IEstudianteRepository
    {
        Task<IEnumerable<Estudiante>> GetAllAsync();
        Task<Estudiante?> GetByIdAsync(int id);
        Task<Estudiante> CreateAsync(Estudiante estudiante);
        Task<Estudiante?> UpdateAsync(int id, Estudiante estudiante);
        Task<bool> DeleteAsync(int id);
    }
}
