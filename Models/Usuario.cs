namespace ds_atividade.Models
{
    class Usuario
    {
        public uint Id { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
        public uint FuncionarioId { get; set; }
    }
}