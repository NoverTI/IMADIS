using IMADIS.API.Aplicacion;
using IMADIS.API.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace IMADIS.API.Ingreso
{
    public class EstudianteController : ODataController
    {
        private readonly IEstudianteService _service;

        public EstudianteController(IEstudianteService service)
        {
            _service = service;
        }

        /// <summary>
        /// Obtiene todos los estudiantes con soporte para consultas OData
        /// </summary>
        /// <returns>Lista de estudiantes</returns>
        [EnableQuery]
        public async Task<ActionResult<IEnumerable<Estudiante>>> Get()
        {
            var estudiantes = await _service.GetAllAsync();
            return Ok(estudiantes);
        }

        /// <summary>
        /// Obtiene un estudiante por ID
        /// </summary>
        /// <param name="key">ID del estudiante</param>
        /// <returns>Estudiante encontrado</returns>
        [EnableQuery]
        public async Task<ActionResult<Estudiante>> Get([FromRoute] int key)
        {
            var estudiante = await _service.GetByIdAsync(key);
            if (estudiante == null)
                return NotFound();

            return Ok(estudiante);
        }

        /// <summary>
        /// Crea un nuevo estudiante
        /// </summary>
        /// <param name="estudiante">Datos del estudiante</param>
        /// <returns>Estudiante creado</returns>
        public async Task<ActionResult<Estudiante>> Post(Estudiante estudiante)
        {
            try
            {
                var created = await _service.CreateAsync(estudiante);
                return Created(created);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Actualiza un estudiante existente
        /// </summary>
        /// <param name="key">ID del estudiante</param>
        /// <param name="estudiante">Datos actualizados del estudiante</param>
        /// <returns>Estudiante actualizado</returns>
        public async Task<ActionResult<Estudiante>> Put([FromRoute] int key, Estudiante estudiante)
        {
            try
            {
                var updated = await _service.UpdateAsync(key, estudiante);
                if (updated == null)
                    return NotFound();

                return Ok(updated);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// Elimina un estudiante
        /// </summary>
        /// <param name="key">ID del estudiante</param>
        /// <returns>Resultado de la operación</returns>
        public async Task<ActionResult> Delete([FromRoute] int key)
        {
            var result = await _service.DeleteAsync(key);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
