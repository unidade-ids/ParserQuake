using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Treinee.Quake.Infra.Context
{
    public class QuakeContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-FGIG7N0\UNIDADE_IDS;Initial Catalog=QUAKE;User Id=sa;Password=unidade;Integrated Security=True");
            }
        }
    }
}
