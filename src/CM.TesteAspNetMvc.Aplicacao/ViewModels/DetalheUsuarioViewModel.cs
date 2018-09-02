using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using ValidationResult = DomainValidation.Validation.ValidationResult;

namespace CM.TesteAspNetMvc.Aplicacao.ViewModels
{
    public class DetalheUsuarioViewModel
    {
        public DetalheUsuarioViewModel()
        {
            Id = Guid.NewGuid();
            Usuarios = new List<UsuarioViewModel>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O Telefone não pode estar vazio")]
        [MaxLength(20, ErrorMessage = "Máximo de {0} caracteres")]
        [DataType(DataType.PhoneNumber)]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O Endereço não pode estar vazio")]
        [MaxLength(255, ErrorMessage = "Máximo de {0} caracteres")]
        [DisplayName("Endereço")]
        [DataType(DataType.MultilineText)]
        public string Endereco { get; set; }

        [ScaffoldColumn(false)]
        public ValidationResult ValidationResult { get; set; }

        public virtual ICollection<UsuarioViewModel> Usuarios { get; set; }
    }
}