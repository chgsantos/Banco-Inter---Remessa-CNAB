using System;
using CNAB.Models.Constantes;
using CNAB.Models.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CNAB.Models.EntityConfiguration
{
    public class PagamentoConfiguration : IEntityTypeConfiguration<Pagamento>
    {
        public void Configure(EntityTypeBuilder<Pagamento> e)
        {
            e.HasKey(m => m.Id);
            
            e.Property(m => m.Id)
                .ValueGeneratedOnAdd();

            e.HasData(new Pagamento
            {
                Id = 1,
                Inscricao = "999.999.999-99",
                TipoInscricao = TipoDeInscricao.Cpf,
                BancoCodigo = "77",
                Agencia = "1",
                AgenciaDigito = "9",
                ContaCorrente = "999999",
                ContaCorrenteDigito = "9",
                Nome = "JOAO SILVA",
                DataPagamento = DateTime.Now,
                Valor = new Decimal(1000.00),
                EnderecoLogradouro = "AVENIDA PRINCIPAL",
                EnderecoNumero = "99",
                EnderecoComplemento = "SALA 9",
                EnderecoBairro = "CENTRO",
                EnderecoCidade = "BELO HORIZONTE",
                EnderecoSiglaEstado = "MG",
                EnderecoCep = "31275000",
                Ativado = 1,
            });
        }
    }
}