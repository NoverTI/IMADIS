# Arquitectura del Proyecto IMADIS

## Visión General

Este proyecto implementa la arquitectura IMADIS (Ingreso, Modelos, Aplicación, Datos, Integración, Sistema) para organizar el código en capas claramente definidas.

## Estructura de Carpetas

```
IMADIS.API/
├── Ingreso/              # Controladores y puntos de entrada
│   └── EstudianteController.cs
├── Modelos/              # Modelos de datos y entidades
│   └── Estudiante.cs
├── Aplicacion/           # Lógica de negocio
│   ├── IEstudianteService.cs
│   └── EstudianteService.cs
├── Datos/                # Acceso a datos y repositorios
│   ├── IEstudianteRepository.cs
│   └── EstudianteRepository.cs
├── Integracion/          # Servicios de integración externa
├── Sistema/              # Configuraciones y utilidades
└── Program.cs            # Configuración de la aplicación
```

## Capas de la Arquitectura

### 1. Ingreso (Controllers)
- **Responsabilidad**: Manejo de solicitudes HTTP y respuestas
- **Ejemplo**: `EstudianteController` maneja las operaciones CRUD para estudiantes
- **Tecnologías**: ASP.NET Core OData Controllers

### 2. Modelos (Models)
- **Responsabilidad**: Definición de entidades y objetos de dominio
- **Ejemplo**: `Estudiante` define la estructura de un estudiante
- **Características**: POCOs (Plain Old CLR Objects) con propiedades simples

### 3. Aplicación (Application/Business Logic)
- **Responsabilidad**: Lógica de negocio y reglas de validación
- **Ejemplo**: `EstudianteService` valida datos antes de persistir
- **Patrón**: Service Pattern con interfaces
- **Validaciones**: 
  - Campos requeridos
  - Reglas de negocio específicas
  - Transformaciones de datos

### 4. Datos (Data Access)
- **Responsabilidad**: Acceso y persistencia de datos
- **Ejemplo**: `EstudianteRepository` gestiona el almacenamiento
- **Patrón**: Repository Pattern con interfaces
- **Implementación actual**: In-memory storage (para demostración)
- **Futuro**: Puede cambiarse a Entity Framework, Dapper, etc.

### 5. Integración (Integration)
- **Responsabilidad**: Comunicación con sistemas externos
- **Uso**: APIs externas, servicios web, mensajería
- **Patrón**: Interfaces para facilitar testing y mocking

### 6. Sistema (System)
- **Responsabilidad**: Configuración, logging, utilidades
- **Uso**: Helpers, extensiones, configuraciones globales

## Flujo de Datos

```
Cliente HTTP
    ↓
Ingreso (Controller)
    ↓
Aplicación (Service) ← validaciones de negocio
    ↓
Datos (Repository)
    ↓
Base de Datos / Storage
```

## Inyección de Dependencias

El proyecto utiliza el contenedor de DI de .NET:

```csharp
builder.Services.AddScoped<IEstudianteRepository, EstudianteRepository>();
builder.Services.AddScoped<IEstudianteService, EstudianteService>();
```

## Beneficios de esta Arquitectura

1. **Separación de Responsabilidades**: Cada capa tiene un propósito específico
2. **Testabilidad**: Interfaces permiten mocking y unit testing
3. **Mantenibilidad**: Cambios en una capa no afectan otras
4. **Escalabilidad**: Fácil agregar nuevas funcionalidades
5. **Reutilización**: Servicios pueden ser compartidos entre controladores
6. **Flexibilidad**: Implementaciones pueden cambiar sin afectar clientes

## Ejemplo de Uso

### Agregar una Nueva Entidad

1. Crear modelo en `Modelos/`
2. Crear repositorio en `Datos/` con interfaz
3. Crear servicio en `Aplicacion/` con interfaz
4. Crear controlador en `Ingreso/`
5. Registrar servicios en `Program.cs`
6. Configurar en OData model builder

### Cambiar Implementación de Datos

Solo modificar la implementación del repositorio en `Datos/`, sin cambiar:
- Interfaz
- Servicios
- Controladores

## Tecnologías Integradas

- **OData**: Query avanzado, filtrado, paginación
- **Swagger**: Documentación automática de API
- **ASP.NET Core**: Framework web moderno
- **Dependency Injection**: Gestión de dependencias nativa
