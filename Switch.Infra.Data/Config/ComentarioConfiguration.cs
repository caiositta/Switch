using System.Security.Principal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;

namespace Switch.Infra.Data.Config
{
    public class ComentarioConfiguration : IEntityTypeConfiguration<Comentario>
    {
        //public DateTime DataPublicacao { get; set; }
        //public string Texto { get; set; }
        //public int UsuarioId { get; set; }
        //public virtual Usuario Usuario { get; set; }

        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(c => c.DataPublicacao).IsRequired();
            builder.Property(c => c.Texto).IsRequired().HasMaxLength(100);
            builder.HasOne(c => c.Usuario);
        }
    }
}
