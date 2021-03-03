using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace RestAPI.Models
{
    public partial class ContasApagar
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal ValorOriginal { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime DataVencimento { get; set; }

        [JsonConverter(typeof(CustomDateTimeConverter))]
        public DateTime? DataPagamento { get; set; }
        public int? DiasEmAtraso { get; set; }
        public decimal? ValorCorrigido { get; set; }
        public int Idfornecedor { get; set; }

        public virtual Fornecedore fornecedor { get; set; }
    }
}
