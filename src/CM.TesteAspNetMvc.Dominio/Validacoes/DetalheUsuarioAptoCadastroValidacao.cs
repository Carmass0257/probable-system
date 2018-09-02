using CM.TesteAspNetMvc.Dominio.Entidades;
using CM.TesteAspNetMvc.Dominio.Especificacoes.DetalheUsuario;
using DomainValidation.Validation;

namespace CM.TesteAspNetMvc.Dominio.Validacoes
{
    public class DetalheUsuarioAptoCadastroValidacao :Validator<DetalheUsuario>
    {
        public DetalheUsuarioAptoCadastroValidacao()
        {
            var endereco = new DetalheDeveTerEnderecoEspecificacao();
            var telefone = new DetalheDeveTerTelefoneEspecificacao();

            base.Add("Endereco", new Rule<DetalheUsuario>(endereco,"Endereço deve ser preenchido"));
            base.Add("Telefone", new Rule<DetalheUsuario>(telefone,"Telefone deve ser preenchido"));
        }
    }
}