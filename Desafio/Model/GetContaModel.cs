using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Desafio.Model
{
    public class GetContaModel
    {
        public string Nome { get; set; }
        public decimal? ValorOriginal { get; set; }
        public decimal? ValorCorrigido { get; set; }
        public int? QuantidadeDiasAtraso { get; set; }      
        public DateTime DataPagamento { get; set; }
    }
}
