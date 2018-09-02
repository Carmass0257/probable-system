using System;
using CM.TesteAspNetMvc.Dominio.Validacoes;
using DomainValidation.Validation;

namespace CM.TesteAspNetMvc.Dominio.Entidades
{
    public class Usuario
    {
        public Usuario()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public Guid DetalheUsuarioId { get; set; }

        public virtual DetalheUsuario DetalheUsuario { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public bool EstaValido()
        {
            ValidationResult = new UsuarioAptoParaCadastroValidacao().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}