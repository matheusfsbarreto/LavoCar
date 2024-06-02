using LavoCar.Controllers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LavoCar.Models
{
    public class MarcaModelo
    {
        [Key]
        public long? MarcaModeloID { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Marca / Modelo")]
        public string DescMarcaModelo { get; set; }

        public virtual ICollection<Carro> Carros { get; set; }
    }
}
