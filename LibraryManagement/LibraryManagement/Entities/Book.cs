using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Entities
{
    public class Book
    {
        [Key]
        [Display(Name = "Id")]
        public int IdBook { get; set; }

        [Required]
        [Display(Name = "Título do Livro")]
        [StringLength(100, ErrorMessage = "O título deve ter entre 1 até 100 caracteres")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Nome do Autor")]
        [StringLength(100, ErrorMessage = "O nome deve ter entre 1 até 100 caracteres")]
        public string Author { get; set; }

        [Required]
        [Display(Name = "Estoque")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Valor deve ser maior ou igual a 0")]
        public int Amount { get; set; }
    }
}