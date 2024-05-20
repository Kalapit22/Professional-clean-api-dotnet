using Core.Interfaces;
using Infraestructure.Data;
using Infraestructure.Repositories;

namespace API.Extensions;


public static class ApplicationServiceExtensions {

    
    public static void ConfigureCors(this IServiceCollection services) {

        services.AddCors(options => {
            options.AddPolicy("PoliticaDesarrollo",builder => {
                builder.AllowAnyOrigin() // WithOrigins("https://dominio.com")
                .AllowAnyMethod()   //   WithMethods ("GET","POST")
                .AllowAnyHeader();  // WithHeaders("accept","Content-Type")    
            });
        });
    }


    public static void AddAplicationServices(this IServiceCollection services) {

        services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
        services.AddScoped<IProductoRepository,ProductoRepository>();
        services.AddScoped<ICategoriaRepository,CategoriaRepository>();
        services.AddScoped<IMarcaRepository,MarcaRepository>();

    }

 
}

