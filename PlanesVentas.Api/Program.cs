using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using PlanesVentas.Dominio.Puertos.Repositorios;
using PlanesVentas.Dominio.Servicios.Planes;
using PlanesVentas.Dominio.Servicios.Productos;
using PlanesVentas.Dominio.Servicios.Vendedores;
using PlanesVentas.Infraestructura.Adaptadores.RepositorioGenerico;
using PlanesVentas.Infraestructura.Adaptadores.Repositorios;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "V.1.0.1",
        Title = "Servicio Planes de venta",
        Description = "Administración de los planes de venta"
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
        {
            {
                new OpenApiSecurityScheme
                {
                    Reference = new OpenApiReference
                    {
                        Type=ReferenceType.SecurityScheme,
                        Id="Bearer"
                    }
                },
            Array.Empty<string>()
            }
        });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.Load("PlanesVentas.Aplicacion")));
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//Capa Infraestructura
builder.Services.AddDbContext<PlanesVentasDbContext>(options =>
                options.UseNpgsql(builder.Configuration.GetConnectionString("PlanesVentasDbContext")), ServiceLifetime.Transient);
builder.Services.AddTransient(typeof(IRepositorioBase<>), typeof(RepositorioBase<>));
builder.Services.AddTransient<IPlanVentaRepositorio, PlanVentaRepositorio>();
builder.Services.AddTransient<IProductosRepositorio, ProductosRepositorio>();
builder.Services.AddTransient<IVendedoresRepositorio, VendedoresRepositorio>();
//Capa Dominio - Servicios
builder.Services.AddTransient<Crear>();
builder.Services.AddTransient<ConsultarPlanes>();
builder.Services.AddTransient<ConsultarPlan>(); 
builder.Services.AddTransient<AgregarProducto>();
builder.Services.AddTransient<ConsultarProductos>();
builder.Services.AddTransient<AgregarVendedor>();
builder.Services.AddTransient<ConsultarVendedor>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("AllowAllOrigins");
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

await app.RunAsync();
