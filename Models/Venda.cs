using System;

namespace ds_atividade.Models
{
    class Venda
    {
        public uint Id { get; set; }
        public DateTime Data { get; set; }
        public string FormaPagamento { get; set; }
        public double Valor { get; set; }
        public uint FuncionarioId { get; set; }
        public uint ClienteId { get; set; }
    }
}