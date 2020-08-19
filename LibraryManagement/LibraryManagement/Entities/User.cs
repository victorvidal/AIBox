using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Entities
{
    public class User
    {
        [Key]
        [Display(Name = "Id")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nome do Usuário")]
        [StringLength(100, ErrorMessage = "O nome deve ter entre 1 até 100 caracteres")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Telefone do Usuário")]
        [StringLength(100, ErrorMessage = "O telefone deve ter entre 1 até 100 caracteres")]
        public string Phone { get; set; }

        [Required]
        [Display(Name = "Endereço do Usuário")]
        [StringLength(100, ErrorMessage = "O endereço deve ter entre 1 até 100 caracteres")]
        public string Address { get; set; }
    }
}