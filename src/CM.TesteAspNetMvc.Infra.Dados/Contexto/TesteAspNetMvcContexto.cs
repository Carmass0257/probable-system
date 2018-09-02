using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using CM.TesteAspNetMvc.Dominio.Entidades;
using CM.TesteAspNetMvc.Infra.Dados.EntidadeConfig;

namespace CM.TesteAspNetMvc.Infra.Dados.Contexto
{
    public class TesteAspNetMvcContexto : DbContext
    {
        public TesteAspNetMvcContexto() : base("DefaultConnection")
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<DetalheUsuario> DetalheUsuarios { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new UsuarioConfig());
            modelBuilder.Configurations.Add(new DetalheUsuarioConfig());

            base.OnModelCreating(modelBuilder);
        }
    }
}