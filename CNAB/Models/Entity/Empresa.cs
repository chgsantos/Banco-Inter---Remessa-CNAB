namespace CNAB.Models.Entity
{
    public class Empresa
    {
        public string BancoCodigo { get; set; }
        public string BancoNome { get; set; }
        public string TipoInscricao { get; set; }
        public string Inscricao { get; set; }
        public string Agencia { get; set; }
        public string AgenciaDigito { get; set; }
        public string ContaCorrente { get; set; }
        public string ContaCorrenteDigito { get; set; }
        public string Nome { get; set; }
        public string EnderecoLogradouro { get; set; }
        public string EnderecoNumero { get; set; }
        public string EnderecoComplemento { get; set; }
        public string EnderecoCidade { get; set; }
        public string EnderecoCep { get; set; }
        public string EnderecoSiglaEstado { get; set; }
    }
}