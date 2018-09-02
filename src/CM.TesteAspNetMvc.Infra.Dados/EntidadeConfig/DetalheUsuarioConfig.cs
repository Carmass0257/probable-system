using System.Data.Entity.ModelConfiguration;
using CM.TesteAspNetMvc.Dominio.Entidades;

namespace CM.TesteAspNetMvc.Infra.Dados.EntidadeConfig
{
    public class DetalheUsuarioConfig : EntityTypeConfiguration<DetalheUsuario>
    {
        public DetalheUsuarioConfig()
        {
            HasKey(k => k.Id);

            Property(c => c.Id).HasColumnName("DetalheUsuarioId");
            Property(c => c.Endereco).IsRequired().HasMaxLength(255);
            Property(c => c.Telefone).IsRequired().HasMaxLength(20);
            Ignore(c => c.ValidationResult);

            ToTable("DetalheUsuarios");
        }
    }
}