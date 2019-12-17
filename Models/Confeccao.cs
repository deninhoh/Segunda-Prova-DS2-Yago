using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProvaDS2Denner.Models
{
    public class Confeccao
    {
        public Confeccao()
        {

        }
        public Confeccao(PecaDeRoupa pecaDeRoupa)
        {
            this.Data = DateTime.Now;
            this.PecaDeRoupa = pecaDeRoupa;
        }

        public int ConfeccaoId { get; set; }
        public int PecaDeRoupaId { get; set; }
        public PecaDeRoupa PecaDeRoupa { get; set; }
        public DateTime Data { get; set; }
     
    }
}
