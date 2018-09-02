using System.Data.Entity.ModelConfiguration;
using CM.TesteAspNetMvc.Dominio.Entidades;

namespace CM.TesteAspNetMvc.Infra.Dados.EntidadeConfig
{
    public class UsuarioConfig : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfig()
        {
            HasKey(c => c.Id);

            Property(c => c.Id).HasColumnName("UsuarioId");
            Property(c => c.Nome).IsRequired().HasMaxLength(150);
            Property(c => c.Sobrenome).IsRequired().HasMaxLength(150);
            Property(c => c.Email).IsRequired().HasMaxLength(100);
            Ignore(c => c.ValidationResult);

            ToTable("Usuarios");

            HasRequired(e => e.DetalheUsuario).WithMany(e => e.Usuarios).HasForeignKey(f => f.DetalheUsuarioId);
        }
    }
}