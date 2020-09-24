using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Switch.Domain.Entities;

namespace Switch.Infra.Data.Config
{
    public class AmigoConfiguration : IEntityTypeConfiguration<Amigo>
    {
        //public DateTime DataPublicacao { get; set; }
        //public string Texto { get; set; }
        //public int UsuarioId { get; set; }
        //public virtual Usuario Usuario { get; set; }

        public void Configure(EntityTypeBuilder<Amigo> builder)
        {
            builder.HasKey(a => new { a.UsuarioId, a.UsuarioAmigo });
        }
    }
}
