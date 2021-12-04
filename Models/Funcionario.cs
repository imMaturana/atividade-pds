using System;

namespace ds_atividade.Models
{
    class Funcionario
    {
        public uint Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public DateTime DataNascimento { get; set; }
        public string TelefoneFixo { get; set; }
        public string Email { get; set; }
        public string TelefoneCelular { get; set; }
        public string Funcao { get; set; }
        public double Salario { get; set; }
        public uint EnderecoId { get; set; }
        public uint SexoId { get; set; }
    }
}