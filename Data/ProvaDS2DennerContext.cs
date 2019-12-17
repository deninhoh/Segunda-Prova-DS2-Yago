using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProvaDS2Denner.Models;

namespace ProvaDS2Denner.Data
{
    public class ProvaDS2DennerContext : DbContext
    {
        public ProvaDS2DennerContext (DbContextOptions<ProvaDS2DennerContext> options)
            : base(options)
        {
        }

        public DbSet<ProvaDS2Denner.Models.Confeccao> Confeccao { get; set; }

        public DbSet<ProvaDS2Denner.Models.PecaDeRoupa> PecaDeRoupa { get; set; }
    }
}
