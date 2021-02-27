using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Desafio.Entidade
{
    public class ContaModel
    {
        public string Nome { get; set; }
        public decimal? ValorOriginal { get; set; }
        public int? QuantidadeDiasAtraso { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
    }
}
