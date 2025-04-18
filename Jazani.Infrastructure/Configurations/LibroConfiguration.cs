using Jazani.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jazani.Infrastructure.Configurations
{
    public class LibroConfiguration : IEntityTypeConfiguration<Libro>
    {
        public void Configure(EntityTypeBuilder<Libro> builder)
        {
            builder.ToTable("libros");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("id");

            builder.Property(x => x.Isbn)
                .HasColumnName("isbn")
                .HasMaxLength(100);

            builder.Property(x => x.Titulo)
                .HasColumnName("titulo")
                .HasMaxLength(300);

            builder.Property(x => x.Autores)
                .HasColumnName("autores")
                .HasMaxLength(300);

            builder.Property(x => x.Edicion)
                .HasColumnName("edicion")
                .HasMaxLength(100);

            builder.Property(x => x.Anio)
                .HasColumnName("anio");

            builder.Property(x => x.IdEditorial)
                .HasColumnName("id_editorial");

            builder.Property(x => x.FechaRegistro)
                .HasColumnName("fecha_registro");

            builder.Property(x => x.Estado)
                .HasColumnName("estado");

            builder.HasOne(x => x.Editorial)
                .WithMany()
                .HasForeignKey(x => x.IdEditorial);

        }
    }
}
