using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Desafio.Model
{
    public class PostContaModel
    {
        public string Nome { get; set; }
        public decimal? ValorOriginal { get; set; }       
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
    }
}
