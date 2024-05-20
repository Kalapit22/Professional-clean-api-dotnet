using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Core.Entities;


namespace Infraestructure.Data.Configuration;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria> {

    public void Configure(EntityTypeBuilder<Categoria> builder) {

        builder.ToTable("Categoria");

        builder.Property(c => c.Id).IsRequired();

        builder.Property(c => c.Name).IsRequired().HasMaxLength(100);

    }




}