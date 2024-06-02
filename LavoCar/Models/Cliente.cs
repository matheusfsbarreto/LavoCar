using LavoCar.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LavoCar.Models
{
    public class Cliente
    {
        [Key]
        public long? ClienteID { get; set; }

        [Required]
        [Display(Name = "Nome")]
        public string NomeCliente { get; set; }

        [MaxLength(100)]
        [Display(Name = "Endereço")]
        public string EndCliente {get;set;}

        [MaxLength(11)]
        [Display(Name = "Telefone" )]
        public string FoneCliente { get; set; }

        public virtual ICollection<Carro> Carros { get; set; }
        //public virtual ICollection<Recibo> Recibos { get; set; }
    }
}
