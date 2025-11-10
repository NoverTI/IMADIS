# Colección de Postman - IMADIS API

## Descripción

Esta colección contiene ejemplos de todas las operaciones disponibles en la API de IMADIS para el módulo de Estudiantes.

## Importar la Colección

1. Abrir Postman
2. Click en "Import"
3. Seleccionar el archivo `IMADIS_API.postman_collection.json`
4. La colección aparecerá en el panel izquierdo

## Configurar Variables

La colección usa una variable de entorno:

- **baseUrl**: `https://localhost:5001` (por defecto)

Para cambiarla:
1. Click en el ícono de ojo (👁️) en la esquina superior derecha
2. Editar la variable `baseUrl` con tu URL local
3. Por ejemplo: `http://localhost:5000`

## Requests Disponibles

### 1. Obtener todos los estudiantes
- **Método**: GET
- **URL**: `/odata/Estudiante`
- **Descripción**: Retorna todos los estudiantes
- **Respuesta**: Lista de estudiantes con metadatos OData

### 2. Obtener todos los estudiantes (con filtro)
- **Método**: GET
- **URL**: `/odata/Estudiante?$filter=contains(Nombre,'Juan')`
- **Descripción**: Filtra estudiantes por nombre usando OData
- **Ejemplo**: Buscar estudiantes que contengan "Juan" en su nombre

### 3. Obtener todos los estudiantes (ordenados)
- **Método**: GET
- **URL**: `/odata/Estudiante?$orderby=Apellido asc`
- **Descripción**: Ordena estudiantes por apellido ascendente
- **OData**: Soporta `asc` y `desc`

### 4. Obtener todos los estudiantes (con paginación)
- **Método**: GET
- **URL**: `/odata/Estudiante?$top=2&$skip=0`
- **Descripción**: Paginación con OData
- **Parámetros**:
  - `$top`: Cantidad de registros a retornar
  - `$skip`: Cantidad de registros a saltar

### 5. Obtener estudiante por ID
- **Método**: GET
- **URL**: `/odata/Estudiante/1`
- **Descripción**: Retorna un estudiante específico por su ID

### 6. Crear nuevo estudiante
- **Método**: POST
- **URL**: `/odata/Estudiante`
- **Headers**: `Content-Type: application/json`
- **Body**:
```json
{
  "nombre": "Ana",
  "apellido": "Martínez",
  "email": "ana.martinez@example.com",
  "fechaInscripcion": "2024-11-10T00:00:00"
}
```

### 7. Actualizar estudiante
- **Método**: PUT
- **URL**: `/odata/Estudiante/1`
- **Headers**: `Content-Type: application/json`
- **Body**:
```json
{
  "nombre": "Juan",
  "apellido": "Pérez Actualizado",
  "email": "juan.perez.nuevo@example.com",
  "fechaInscripcion": "2023-01-15T00:00:00"
}
```

### 8. Eliminar estudiante
- **Método**: DELETE
- **URL**: `/odata/Estudiante/1`
- **Descripción**: Elimina un estudiante por su ID

## Características de OData

Puedes combinar múltiples operadores OData:

### Filtros Avanzados
```
$filter=Nombre eq 'Juan'
$filter=contains(Nombre,'an')
$filter=Id gt 1
$filter=FechaInscripcion ge 2024-01-01
```

### Ordenamiento
```
$orderby=Nombre asc
$orderby=Apellido desc
$orderby=FechaInscripcion desc
```

### Selección de Campos
```
$select=Nombre,Email
$select=Id,Apellido
```

### Paginación
```
$top=10&$skip=20
$top=5
```

### Contar Registros
```
$count=true
```

### Combinaciones
```
$filter=contains(Nombre,'a')&$orderby=Apellido&$top=5
```

## Ejemplos de Uso

### Buscar estudiantes con nombre que contenga "María"
```
GET /odata/Estudiante?$filter=contains(Nombre,'María')
```

### Obtener los 3 estudiantes más recientes
```
GET /odata/Estudiante?$orderby=FechaInscripcion desc&$top=3
```

### Obtener solo nombre y email de todos
```
GET /odata/Estudiante?$select=Nombre,Email
```

### Buscar y ordenar
```
GET /odata/Estudiante?$filter=contains(Apellido,'ez')&$orderby=Nombre
```

## Notas

- La API devuelve respuestas en formato JSON con metadatos OData
- Los IDs se generan automáticamente al crear estudiantes
- La fecha de inscripción debe estar en formato ISO 8601
- Todos los campos son requeridos al crear/actualizar

## Troubleshooting

### Error de conexión
- Verificar que la API esté ejecutándose
- Verificar la variable `baseUrl`
- Revisar el puerto (5000 para HTTP, 5001 para HTTPS)

### Error 400 Bad Request
- Verificar que todos los campos requeridos estén presentes
- Verificar el formato de las fechas
- Revisar que los tipos de datos sean correctos

### Error 404 Not Found
- Verificar que el ID del estudiante exista
- Verificar la URL del endpoint
