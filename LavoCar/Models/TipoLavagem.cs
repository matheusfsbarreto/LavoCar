using LavoCar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LavoCar.Controllers
{
    public class TipoLavagem
    {
        [Key]
        public long? TipoLavID { get; set; }

        [Display(Name ="Descrição")]
        public string DescTipoLav { get; set; }

        [Display(Name = "Preço")]
        public double PrecoTipoLav { get; set; }

        public virtual ICollection<Lavagem> Lavagens { get; set; }
        //public virtual ICollection<Recibo> Recibos { get; set; }
    }
}
