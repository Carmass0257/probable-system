using CM.TesteAspNetMvc.Dominio.Entidades;
using CM.TesteAspNetMvc.Dominio.Interfaces.Repositorio;
using CM.TesteAspNetMvc.Infra.Dados.Contexto;

namespace CM.TesteAspNetMvc.Infra.Dados.Repositorio
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(TesteAspNetMvcContexto contexto) : base(contexto)
        {
        }
    }
}