using CM.TesteAspNetMvc.Dominio.Entidades;
using CM.TesteAspNetMvc.Dominio.Especificacoes.Usuario;
using DomainValidation.Validation;

namespace CM.TesteAspNetMvc.Dominio.Validacoes
{
    public class UsuarioAptoParaCadastroValidacao : Validator<Usuario>
    {
        public UsuarioAptoParaCadastroValidacao()
        {
            var nome = new UsuarioDeveTerNomeEspecificacao();
            var sobrenome = new UsuarioDeveTerSobrenomeEspecificacao();
            var email = new UsuarioDeveTerEmailEspecificacao();

            base.Add("Nome", new Rule<Usuario>(nome, "Preencha o nome do usuário!"));
            base.Add("Sobrenome", new Rule<Usuario>(sobrenome, "Preencha o Sobrenome do usuário"));
            base.Add("Email", new Rule<Usuario>(email, "Preencha o E-mail do usuário"));
        }
    }
}