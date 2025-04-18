using Jazani.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Jazani.Infrastructure.Configurations
{
    public class SolicitanteConfiguration : IEntityTypeConfiguration<Solicitante>
    {
        public void Configure(EntityTypeBuilder<Solicitante> builder)
        {
            builder.ToTable("solicitantes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.NombreCompleto).HasColumnName("nombre_completo").HasMaxLength(200);
            builder.Property(x => x.DocumentoIdentidad).HasColumnName("documento_identidad").HasMaxLength(20);
            builder.Property(x => x.Email).HasColumnName("email").HasMaxLength(100);
            builder.Property(x => x.Telefono).HasColumnName("telefono").HasMaxLength(20);
            builder.Property(x => x.FechaRegistro).HasColumnName("fecha_registro");
            builder.Property(x => x.Estado).HasColumnName("estado");
        }
    }
}
