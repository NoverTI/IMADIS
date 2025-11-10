using IMADIS.API.Aplicacion;
using IMADIS.API.Datos;
using IMADIS.API.Modelos;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Configurar OData
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<Estudiante>("Estudiante");
builder.Services.AddControllers().AddOData(options =>
{
    options.Select().Filter().OrderBy().Expand().Count().SetMaxTop(100);
    options.AddRouteComponents("odata", modelBuilder.GetEdmModel());
    options.EnableQueryFeatures();
});

// Configurar Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "IMADIS API",
        Version = "v1",
        Description = "API con estructura IMADIS (Ingreso, Modelos, Aplicación, Datos, Integración, Sistema)",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "IMADIS Team"
        }
    });
    
    // Configurar Swagger para incluir comentarios XML si existen
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        c.IncludeXmlComments(xmlPath);
    }
});

// Registrar servicios e implementaciones
builder.Services.AddScoped<IEstudianteRepository, EstudianteRepository>();
builder.Services.AddScoped<IEstudianteService, EstudianteService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "IMADIS API v1");
        c.RoutePrefix = "swagger";
    });
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.Run();
