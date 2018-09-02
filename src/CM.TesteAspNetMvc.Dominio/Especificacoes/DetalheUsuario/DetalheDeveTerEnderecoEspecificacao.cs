using DomainValidation.Interfaces.Specification;

namespace CM.TesteAspNetMvc.Dominio.Especificacoes.DetalheUsuario
{
    public class DetalheDeveTerEnderecoEspecificacao : ISpecification<Entidades.DetalheUsuario>
    {
        public bool IsSatisfiedBy(Entidades.DetalheUsuario entity)
        {
            return !string.IsNullOrWhiteSpace(entity.Endereco);
        }
    }
}