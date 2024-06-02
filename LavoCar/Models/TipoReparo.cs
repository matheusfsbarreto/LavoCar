using LavoCar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LavoCar.Controllers
{
    public class TipoReparo
    {
        [Key]
        public long? TipoReparoID { get; set; }

        [Display(Name ="Descrição")]
        public string DescTipoReparo { get; set; }

        [Display(Name = "Preço")]
        public double PrecoTipoReparo { get; set; }

        public virtual ICollection<Reparo> Reparos { get; set; }
        //public virtual ICollection<Recibo> Recibos { get; set; }
    }
}
