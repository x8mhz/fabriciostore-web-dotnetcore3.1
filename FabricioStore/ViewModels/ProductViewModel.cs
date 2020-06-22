using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace FabricioStore.ViewModels
{
    public class ProductViewModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Título")]
        [StringLength(50, ErrorMessage = "Campos entre 30 e 2 caracteres", MinimumLength = 2)]
        public string Title { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Categoria")]
        [StringLength(30, ErrorMessage = "Campos entre 30 e 2 caracteres", MinimumLength = 2)]
        public string Category { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Marca")]
        [StringLength(30, ErrorMessage = "Campos entre 30 e 2 caracteres", MinimumLength = 2)]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [DisplayName("Preço")]
        public decimal Price { get; private set; }
    }
}