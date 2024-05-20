using System.Reflection;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
namespace Infraestructure.Data;



public class TiendaContext : DbContext {

    public TiendaContext(DbContextOptions options) : base(options) {}


    public DbSet<Producto> Productos {get;set;}

    public DbSet<Categoria> Categorias {get;set;}

    public DbSet<Marca> Marcas {get;set;}


    // Se aplican todas las configuraciones de Configuration
    protected override void OnModelCreating(ModelBuilder modelBuilder){
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }



}