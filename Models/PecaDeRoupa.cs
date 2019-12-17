using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaDS2Denner.Models
{
    public class PecaDeRoupa
    {
        [Key]
        public int PecaDeRoupaId { get; set; }
        public string TipoDeRoupa { get; set; }
        public int Quantidade { get; set; }
    }
}
