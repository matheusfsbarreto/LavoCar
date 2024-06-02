using LavoCar.Controllers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LavoCar.Models
{
    public class Funcionario
    {
        [Key]
        public long? FuncionarioID { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string NomeFuncionario { get; set; }

        [MaxLength(100)]
        [Display(Name = "Endereço")]
        public string EndFuncionario { get; set; }

        [MaxLength(11)]
        [Display(Name = "Telefone")]
        public string FoneFuncionario { get; set; }

        public virtual ICollection<Lavagem> Lavagens { get; set; }
    }
}
