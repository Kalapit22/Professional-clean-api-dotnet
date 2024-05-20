using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestructure.Data.Configuration;

// Al querer que en la base de datos aparezca singular, podemos cambiar eso aca
public class ProductoConfiguracion : IEntityTypeConfiguration<Producto>
{
    public void Configure(EntityTypeBuilder<Producto> builder)
    {
     
        builder.ToTable("Producto");

        builder.Property(p => p.Id).IsRequired();

        builder.Property(p => p.Name).IsRequired().HasMaxLength(100);

        builder.Property(p => p.Precio).IsRequired().HasColumnType("decimal(18,2)");


        // Las relacione se hacen en el que tiene las foraneas, en este caso la realcion es de uno a muchos 
        builder.HasOne(p => p.Marca).WithMany(p => p.Productos).HasForeignKey(p => p.MarcaId); // Una marca puede tener muchos productos

        builder.HasOne(p => p.Categoria).WithMany(p => p.Productos).HasForeignKey(p => p.CategoriaId); // Una categorria puede tener muchos productos 


    }
}