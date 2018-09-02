using System;
using System.Collections.Generic;
using CM.TesteAspNetMvc.Dominio.Validacoes;
using DomainValidation.Validation;

namespace CM.TesteAspNetMvc.Dominio.Entidades
{
    public class DetalheUsuario
    {
        public DetalheUsuario()
        {
            Id = Guid.NewGuid();
            Usuarios = new List<Usuario>();
        }

        public Guid Id { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
        public ValidationResult ValidationResult { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }

        public bool EstaValido()
        {
            ValidationResult = new DetalheUsuarioAptoCadastroValidacao().Validate(this);
            return ValidationResult.IsValid;
        }
        
    }
}