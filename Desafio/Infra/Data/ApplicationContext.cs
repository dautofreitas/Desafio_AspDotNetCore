using Desafio.Entidade;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Dados
{

    public class ApplicationContext: DbContext
    {
      
       public ApplicationContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Conta>( p => 
            {
                p.HasKey(p => p.Id);                
                p.Property(p => p.Nome).IsRequired();
                p.Property(p => p.QuantidadeDiasAtraso).IsRequired();
                p.Property(p => p.ValorOriginal).HasPrecision(18, 2).IsRequired();
                p.Property(p => p.ValorCorrigido).HasPrecision(18, 2);
                p.Property(p => p.PorcentagemMulta).HasPrecision(10, 2);
                p.Property(p => p.PorcentagemJurosDia).HasPrecision(10, 2);
                p.Property(p => p.DataVencimento).IsRequired();
                p.Property(p => p.DataPagamento).IsRequired();                
            });
        }
    }
}
