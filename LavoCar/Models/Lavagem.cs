using LavoCar.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LavoCar.Controllers
{
    public class Lavagem
    {
        [Key]
        public long? LavID { get; set; }
        
        [Display(Name = "Data")]
        public DateTime DataLav { get; set; }

        public long? CarroID { get; set; }
        public Carro Carro { get; set; }

        public long? TipoLavagemID { get; set; }
        public  TipoLavagem TipoLavagem { get; set; }

        public long? FuncionarioID { get; set; }
        public Funcionario Funcionario { get; set; }

        //public virtual ICollection<Recibo> Recibos { get; set; }
    }
}
