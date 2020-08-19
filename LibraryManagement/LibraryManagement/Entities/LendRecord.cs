using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Entities
{
    public class LendRecord
    {
        [Key]
        [Required]
        [Display(Name = "Id")]
        public int IdLend { get; set; }

        [Required]
        [Display(Name = "Id")]
        public int IdUser { get; set; }

        [Required]
        [Display(Name = "Id")]
        public int IdBook { get; set; }

        [Required]
        [Display(Name = "Data do empréstimo")]
        [StringLength(100, ErrorMessage = "A data deve ter entre 1 até 100 caracteres")]
        public string LendDate { get; set; }
    }
}