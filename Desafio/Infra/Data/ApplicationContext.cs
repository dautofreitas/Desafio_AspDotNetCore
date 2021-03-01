using Desafio.Entidade;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Dados
{

    public class ApplicationContext: DbContext
    {
       protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conta>( p => 
            {
                p.HasKey(p => p.Id);                
                p.Property(p => p.Nome).IsRequired();
                p.Property(p => p.QuantidadeDiasAtraso).IsRequired();
                p.Property(p => p.ValorOriginal).IsRequired();
                p.Property(p => p.ValorCorrigido).IsRequired();
                p.Property(p => p.DataVencimento).IsRequired();
                p.Property(p => p.DataPagamento).IsRequired();              
            });
        }
    }
}
