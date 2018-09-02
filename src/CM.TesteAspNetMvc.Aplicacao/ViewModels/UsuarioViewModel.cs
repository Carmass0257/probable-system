using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CM.TesteAspNetMvc.Aplicacao.ViewModels
{
    public class UsuarioViewModel
    {
        public UsuarioViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome não pode estar vazio!")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Sobrenome não pode estar vazio!")]
        [MaxLength(150, ErrorMessage = "Máximo {0} caracteres")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O E-mail não pode estar vazio!")]
        [MaxLength(100, ErrorMessage = "Máximo {0} caracteres")]
        [DisplayName("E-mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [ScaffoldColumn(false)]
        public Guid DetalheUsuarioId { get; set; }
    }
}