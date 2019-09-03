using System;
using System.Collections.Generic;
using System.Linq;
using CNAB.Models.Constantes;
using CNAB.Models.Entity;
using Microsoft.EntityFrameworkCore.Internal;

namespace CNAB.Services
{
    public class RemessaService
    {
        private readonly Empresa _empresa;
        private List<ServicoPagamento> _pagamentos;

        public RemessaService(Empresa empresa)
        {
            _empresa = empresa;
        }

        public void AdicionarPagamentos(List<ServicoPagamento> pagamentos)
        {
            _pagamentos = pagamentos;
        }

        public string GerarRemessa()
        {
            // REMESSA
            
            var remessa = new List<string>
            {
                string.Concat(
                    _empresa.BancoCodigo.PadLeft(3, '0'),
                    "0000",
                    "0",
                    "         ",
                    _empresa.TipoInscricao,
                    _empresa.Inscricao.PadLeft(14, '0'),
                    "                    ",
                    _empresa.Agencia.PadLeft(5, '0'),
                    _empresa.AgenciaDigito,
                    _empresa.ContaCorrente.PadLeft(12, '0'),
                    _empresa.ContaCorrenteDigito,
                    " ",
                    _empresa.Nome
                        .Substring(0, _empresa.Nome.Length > 30 ? 30 : _empresa.Nome.Length)
                        .PadRight(30, ' '),
                    _empresa.BancoNome
                        .Substring(0, _empresa.BancoNome.Length > 30 ? 30 : _empresa.BancoNome.Length)
                        .PadRight(30, ' '),
                    "          ",
                    "1",
                    DateTime.Now.ToString("ddMMyyyyHHmmss"),
                    "000001",
                    "084",
                    "00000",
                    "                    ",
                    "                    ",
                    "                             "
                )
            };
            
            // PAGAMENTOS

            var lote = new List<string>
            {
                string.Concat(
                    _empresa.BancoCodigo.PadLeft(3, '0'),
                    "0001",
                    "1",
                    "C",
                    TipoDeServico.PagamentoSalarios,
                    FormaDeLancamento.CreditoEmContaCorrente,
                    "043",
                    " ",
                    _empresa.TipoInscricao,
                    _empresa.Inscricao.PadLeft(14, '0'),
                    "                    ",
                    _empresa.Agencia.PadLeft(5, '0'),
                    _empresa.AgenciaDigito,
                    _empresa.ContaCorrente.PadLeft(12, '0'),
                    _empresa.ContaCorrenteDigito,
                    " ",
                    _empresa.Nome
                        .Substring(0, _empresa.Nome.Length > 30 ? 30 : _empresa.Nome.Length)
                        .PadRight(30, ' '),
                    "".PadRight(40, ' '),
                    _empresa.EnderecoLogradouro
                        .Substring(0, _empresa.EnderecoLogradouro.Length > 30 ? 30 : _empresa.EnderecoLogradouro.Length)
                        .PadRight(30, ' '),
                    _empresa.EnderecoNumero
                        .Substring(0, _empresa.EnderecoNumero.Length > 5 ? 5 : _empresa.EnderecoNumero.Length)
                        .PadRight(5, ' '),
                    _empresa.EnderecoComplemento
                        .Substring(0, _empresa.EnderecoComplemento.Length > 15 ? 15 : _empresa.EnderecoComplemento.Length)
                        .PadRight(15, ' '),
                    _empresa.EnderecoCidade
                        .Substring(0, _empresa.EnderecoCidade.Length > 20 ? 20 : _empresa.EnderecoCidade.Length)
                        .PadRight(20, ' '),
                    _empresa.EnderecoCep,
                    _empresa.EnderecoSiglaEstado,
                    "        ",
                    "          "
                )
            };

            var i = 0;
            foreach (var pagamento in _pagamentos)
            {
                i++;
                lote.Add(
                    string.Concat(
                        _empresa.BancoCodigo.PadLeft(3, '0'),
                        "0001",
                        "3",
                        i.ToString().PadLeft(5, '0'),
                        "A",
                        "0", // tipo de movimento = inclusão
                        "00",
                        "000",
                        pagamento.BancoCodigo.PadLeft(3, '0'),
                        pagamento.Agencia.PadLeft(5, '0'),
                        pagamento.AgenciaDigito,
                        pagamento.ContaCorrente.PadLeft(12, '0'),
                        pagamento.ContaCorrenteDigito,
                        " ",
                        pagamento.Nome
                            .Substring(0, pagamento.Nome.Length > 30 ? 30 : pagamento.Nome.Length)
                            .PadRight(30, ' '),
                        "                    ",
                        pagamento.DataPagamento.ToString("ddMMyyyy"),
                        "BRL",
                        "000000000000000",
                        $"{(pagamento.Valor * 100):0}".PadLeft(15, '0'),
                        "                    ",
                        pagamento.DataPagamento.ToString("ddMMyyyy"),
                        $"{(pagamento.Valor * 100):0}".PadLeft(15, '0'),
                        "".PadRight(40, ' '),
                        "  ",
                        "     ",
                        "  ",
                        "   ",
                        "0",
                        "          "
                    )
                );

                i++;
                lote.Add(
                    string.Concat(
                        _empresa.BancoCodigo.PadLeft(3, '0'),
                        "0001",
                        "3",
                        i.ToString().PadLeft(5, '0'),
                        "B",
                        "   ",
                        pagamento.TipoInscricao,
                        pagamento.Inscricao.PadLeft(14, '0'),
                        pagamento.EnderecoLogradouro
                            .Substring(0, pagamento.EnderecoLogradouro.Length > 30 ? 30 : pagamento.EnderecoLogradouro.Length)
                            .PadRight(30, ' '),
                        pagamento.EnderecoNumero
                            .Substring(0, pagamento.EnderecoNumero.Length > 5 ? 5 : pagamento.EnderecoNumero.Length)
                            .PadRight(5, ' '),
                        pagamento.EnderecoComplemento
                            .Substring(0, pagamento.EnderecoComplemento.Length > 15 ? 15 : pagamento.EnderecoComplemento.Length)
                            .PadRight(15, ' '),
                        pagamento.EnderecoBairro
                            .Substring(0, pagamento.EnderecoBairro.Length > 15 ? 15 : pagamento.EnderecoBairro.Length)
                            .PadRight(15, ' '),
                        pagamento.EnderecoCidade
                            .Substring(0, pagamento.EnderecoCidade.Length > 20 ? 20 : pagamento.EnderecoCidade.Length)
                            .PadRight(20, ' '),
                        pagamento.EnderecoCep,
                        pagamento.EnderecoSiglaEstado,
                        pagamento.DataPagamento.ToString("ddMMyyyy"),
                        "               ",
                        "               ",
                        "               ",
                        "               ",
                        "               ",
                        "               ",
                        " ",
                        "      ",
                        "        "
                    )
                );
            }
            
            lote.Add(
                string.Concat(
                    _empresa.BancoCodigo.Substring(0, 3).PadLeft(3, '0'),
                    "0001",
                    "5",
                    "         ",
                    (lote.Count + 1).ToString().PadLeft(6, '0'),
                    $"{(_pagamentos.Sum(x => x.Valor) * 100):0}".PadLeft(18, '0'),
                    "000000000000000000",
                    "      ",
                    "".PadRight(165, ' '),
                    "          "
                )
            );
            
            remessa.AddRange(lote);
            
            remessa.Add(string.Concat(
                _empresa.BancoCodigo.Substring(0, 3).PadLeft(3, '0'),
                "9999",
                "9",
                "         ",
                "000001",
                (remessa.Count + 1).ToString().PadLeft(6, '0'),
                "000000",
                "".PadRight(205, ' ')
            ));

            return remessa.Join("\n");
        }
    }
}