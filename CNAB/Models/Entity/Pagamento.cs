using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace CNAB.Models.Entity
{
    [Table("Pagamento")]
    public class Pagamento
    {
        public const string TipoRegistro = "1";
        public const string TipoOperacao = "C";
        
        public int Id { get; set; }
        public string TipoServico { get; set; }
        public string BancoCodigo { get; set; }
        public string Agencia { get; set; }
        public string AgenciaDigito { get; set; }
        public string ContaCorrente { get; set; }
        public string ContaCorrenteDigito { get; set; }
        public string Nome { get; set; }
        public DateTime DataPagamento { get; set; }
        public Decimal Valor { get; set; }
        public string TipoInscricao { get; set; }
        public string Inscricao { get; set; }
        public string EnderecoLogradouro { get; set; }
        public string EnderecoNumero { get; set; }
        public string EnderecoComplemento { get; set; }
        public string EnderecoBairro { get; set; }
        public string EnderecoCidade { get; set; }
        public string EnderecoCep { get; set; }
        public string EnderecoSiglaEstado { get; set; }
    }
}