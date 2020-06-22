using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;

namespace FabricioStore.ViewModels
{
    public class CustomerViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Nome")]
        [StringLength(30, ErrorMessage = "Campos entre 30 e 2 caracteres", MinimumLength = 2)]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Sobrenome")]
        [StringLength(100, ErrorMessage = "Campos entre 30 e 2 caracteres", MinimumLength = 2)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("CPF")]
        [StringLength(15, ErrorMessage = "Campos entre 30 e 2 caracteres", MinimumLength = 2)]
        public string Document { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("E-mail")]
        [EmailAddress(ErrorMessage = "Email inválido")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Senha")]
        [StringLength(15, ErrorMessage = "Senha deve ter entre 15 e 10 caracteres", MinimumLength = 10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}