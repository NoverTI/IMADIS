# IMADIS
Estructura IMADIS - Sistema de gestión con arquitectura en capas

## Estructura del Proyecto

El proyecto sigue la estructura IMADIS organizada en las siguientes capas:

- **Ingreso** - Controladores y puntos de entrada de la API (Controllers)
- **Modelos** - Modelos de datos y entidades
- **Aplicación** - Lógica de negocio y servicios (con interfaces)
- **Datos** - Repositorios y acceso a datos (con interfaces)
- **Integración** - Servicios de integración con sistemas externos (con interfaces)
- **Sistema** - Configuraciones y utilidades del sistema

## Tecnologías Utilizadas

- **.NET 9.0** - Framework principal
- **OData** - Para consultas avanzadas y filtrado
- **Swagger/OpenAPI** - Documentación de la API
- **ASP.NET Core Web API** - Framework web

## Ejecutar el Proyecto

```bash
cd IMADIS.API
dotnet restore
dotnet build
dotnet run
```

La API estará disponible en:
- HTTP: http://localhost:5000
- Swagger UI: http://localhost:5000/swagger

## Endpoints Disponibles

### Estudiantes

- `GET /odata/Estudiante` - Obtener todos los estudiantes
- `GET /odata/Estudiante/{id}` - Obtener un estudiante por ID
- `POST /odata/Estudiante` - Crear un nuevo estudiante
- `PUT /odata/Estudiante/{id}` - Actualizar un estudiante
- `DELETE /odata/Estudiante/{id}` - Eliminar un estudiante

### Características de OData

Puedes usar las siguientes características de OData en las consultas:

- **$filter** - Filtrar resultados: `/odata/Estudiante?$filter=contains(Nombre,'Juan')`
- **$orderby** - Ordenar resultados: `/odata/Estudiante?$orderby=Apellido asc`
- **$top** - Limitar resultados: `/odata/Estudiante?$top=10`
- **$skip** - Saltar resultados: `/odata/Estudiante?$skip=5`
- **$select** - Seleccionar campos: `/odata/Estudiante?$select=Nombre,Email`
- **$count** - Obtener conteo: `/odata/Estudiante?$count=true`

## Colección de Postman

Puedes encontrar una colección de Postman con ejemplos de todas las operaciones en la carpeta `CollectionsPostMan`.

## Ejemplo de Estudiante

```json
{
  "nombre": "Juan",
  "apellido": "Pérez",
  "email": "juan.perez@example.com",
  "fechaInscripcion": "2024-11-10T00:00:00"
}
```

