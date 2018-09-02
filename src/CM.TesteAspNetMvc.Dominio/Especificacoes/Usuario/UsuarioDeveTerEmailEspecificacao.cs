using DomainValidation.Interfaces.Specification;

namespace CM.TesteAspNetMvc.Dominio.Especificacoes.Usuario
{
    public class UsuarioDeveTerEmailEspecificacao:ISpecification<Entidades.Usuario>
    {
        public bool IsSatisfiedBy(Entidades.Usuario entity)
        {
            return !string.IsNullOrWhiteSpace(entity.Email);
        }
    }
}