using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DCWebAPI.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "O {0} é obrigatório")]
        [MinLength(2, ErrorMessage = "O {0} deve ter no minímo 2 caracteres")]
        [MaxLength(120, ErrorMessage = "O {0} deve ter no máximo 120 caracteres")]
        public string Name { get; set; }

        [DisplayName("Email")]
        [Required(ErrorMessage = "O {0} é obrigatório")]
        [MaxLength(120, ErrorMessage = "O {0} deve ter no máximo 120 caracteres")]
        [EmailAddress(ErrorMessage = "O {0} está em formato inválido")]
        public string Email { get; set; }
    }
}