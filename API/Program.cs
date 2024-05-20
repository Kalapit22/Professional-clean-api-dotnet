using API.Extensions;
using Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.Services.ConfigureCors();
builder.Services.AddAplicationServices();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();




// Agregar Contexto
builder.Services.AddDbContext<TiendaContext>(options => {
    var connectionString =  builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
});

// Registrar controladores

builder.Services.AddControllers();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Ejecuta migraciones pendientes
using (var scope = app.Services.CreateScope()) {
    var services = scope.ServiceProvider;
    var loggerFactory = services.GetRequiredService<ILoggerFactory>();
    try {
        var context = services.GetRequiredService<TiendaContext>();
        await context.Database.MigrateAsync();
        await TiendaContextSeed.SeedAsync(context,loggerFactory);

    } catch(Exception ex) {
        var logger = loggerFactory.CreateLogger<Program>();
        logger.LogError(ex,"Ocurrio un error durante la migracion");
    }

}


// Middlewares
app.UseCors("PoliticaDesarrollo"); // Agregar cors predefinido

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

