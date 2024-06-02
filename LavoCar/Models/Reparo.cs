using LavoCar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LavoCar.Controllers
{
    public class Reparo
    {
        [Key]
        public long? ReparoID { get; set; }
        
        [Display(Name = "Data")]
        public DateTime DataReparo { get; set; }

        public long? CarroID { get; set; }
        public Carro Carro { get; set; }

        public long? TipoReparoID { get; set; }
        public  TipoReparo TipoReparo { get; set; }

        //public virtual ICollection<Recibo> Recibos { get; set; }
    }
}
