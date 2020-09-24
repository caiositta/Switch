using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;

namespace Switch.Infra.Data.Config
{
    public class GrupoConfiguration : IEntityTypeConfiguration<Grupo>
    {
        //public DateTime DataPublicacao { get; set; }
        //public string Texto { get; set; }
        //public int UsuarioId { get; set; }
        //public virtual Usuario Usuario { get; set; }

        public void Configure(EntityTypeBuilder<Grupo> builder)
        {
            builder.HasKey(g => g.Id);
            builder.Property(g => g.Nome)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(g => g.Descricacao)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(g => g.UrlFoto)
                .IsRequired()
                .HasMaxLength(1000);
            builder.HasMany(g => g.Postagens).WithOne(p => p.Grupo);
        }
    }
}
