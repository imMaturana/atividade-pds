namespace ds_atividade.Models
{
    class VendaItens
    {
        public uint Id { get; set; }
        public uint Quantidade { get; set; }
        public double Valor { get; set; }
        public double ValorTotal { get; set; }
        public uint ProdutoId { get; set; }
        public uint VendaId { get; set; }
    }
}