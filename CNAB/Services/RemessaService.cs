using System;
using System.Collections.Generic;
using System.Linq;
using CNAB.Hooks;
using CNAB.Models.Constantes;
using CNAB.Models.Entity;
using Microsoft.EntityFrameworkCore.Internal;

namespace CNAB.Services
{
    public class RemessaService
    {
        private readonly Empresa _empresa;
        private List<Pagamento> _pagamentos;

        public RemessaService(Empresa empresa)
        {
            _empresa = empresa;
        }

        public void AdicionarPagamentos(List<Pagamento> pagamentos)
        {
            _pagamentos = pagamentos;
        }

        public string GerarRemessa()
        {
            // REMESSA
            
            var remessa = new List<string>
            {
                string.Concat(
                    _empresa.BancoCodigo.LimiteCaracteresEsquerda(3, '0'),
                    "0000",
                    "0",
                    "         ",
                    _empresa.TipoInscricao.LimiteCaracteres(1),
                    _empresa.Inscricao.SomenteNumeros().LimiteCaracteresEsquerda(14, '0'),
                    "                    ",
                    _empresa.Agencia.LimiteCaracteresEsquerda(5, '0'),
                    _empresa.AgenciaDigito.LimiteCaracteres(1),
                    _empresa.ContaCorrente.LimiteCaracteresEsquerda(12, '0'),
                    _empresa.ContaCorrenteDigito.LimiteCaracteres(1),
                    " ",
                    _empresa.Nome.LimiteCaracteresDireita(30, ' '),
                    _empresa.BancoNome.LimiteCaracteresDireita(30, ' '),
                    "          ",
                    "1",
                    DateTime.Now.FormatarDataHora(),
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
                    _empresa.BancoCodigo.LimiteCaracteresEsquerda(3, '0'),
                    "0001",
                    "1",
                    "C",
                    TipoDeServico.PagamentoSalarios,
                    FormaDeLancamento.CreditoEmContaCorrente,
                    "043",
                    " ",
                    _empresa.TipoInscricao.LimiteCaracteres(1),
                    _empresa.Inscricao.SomenteNumeros().LimiteCaracteresEsquerda(14, '0'),
                    "                    ",
                    _empresa.Agencia.LimiteCaracteresEsquerda(5, '0'),
                    _empresa.AgenciaDigito.LimiteCaracteres(1),
                    _empresa.ContaCorrente.LimiteCaracteresEsquerda(12, '0'),
                    _empresa.ContaCorrenteDigito.LimiteCaracteres(1),
                    " ",
                    _empresa.Nome.LimiteCaracteresDireita(30, ' '),
                    "".LimiteCaracteresDireita(40, ' '),
                    _empresa.EnderecoLogradouro.LimiteCaracteresDireita(30, ' '),
                    _empresa.EnderecoNumero.LimiteCaracteresDireita(5, ' '),
                    _empresa.EnderecoComplemento.LimiteCaracteresDireita(15, ' '),
                    _empresa.EnderecoCidade.LimiteCaracteresDireita(20, ' '),
                    _empresa.EnderecoCep.LimiteCaracteres(8),
                    _empresa.EnderecoSiglaEstado.LimiteCaracteres(2),
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
                        _empresa.BancoCodigo.LimiteCaracteresEsquerda(3, '0'),
                        "0001",
                        "3",
                        i.ToString().LimiteCaracteresEsquerda(5, '0'),
                        "A",
                        "0", // tipo de movimento = inclusão
                        "00",
                        "000",
                        pagamento.BancoCodigo.LimiteCaracteresEsquerda(3, '0'),
                        pagamento.Agencia.LimiteCaracteresEsquerda(5, '0'),
                        pagamento.AgenciaDigito.LimiteCaracteres(1),
                        pagamento.ContaCorrente.LimiteCaracteresEsquerda(12, '0'),
                        pagamento.ContaCorrenteDigito.LimiteCaracteres(1),
                        " ",
                        pagamento.Nome.LimiteCaracteresDireita(30, ' '),
                        "                    ",
                        pagamento.DataPagamento.FormatarData(),
                        "BRL",
                        "000000000000000",
                        pagamento.Valor.FormatarValor(15, '0'),
                        "                    ",
                        pagamento.DataPagamento.FormatarData(),
                        pagamento.Valor.FormatarValor(15, '0'),
                        "".LimiteCaracteresDireita(40, ' '),
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
                        _empresa.BancoCodigo.LimiteCaracteresEsquerda(3, '0'),
                        "0001",
                        "3",
                        i.ToString().LimiteCaracteresEsquerda(5, '0'),
                        "B",
                        "   ",
                        pagamento.TipoInscricao.LimiteCaracteres(1),
                        pagamento.Inscricao.SomenteNumeros().LimiteCaracteresEsquerda(14, '0'),
                        pagamento.EnderecoLogradouro.LimiteCaracteresDireita(30, ' '),
                        pagamento.EnderecoNumero.LimiteCaracteresDireita(5, ' '),
                        pagamento.EnderecoComplemento.LimiteCaracteresDireita(15, ' '),
                        pagamento.EnderecoBairro.LimiteCaracteresDireita(15, ' '),
                        pagamento.EnderecoCidade.LimiteCaracteresDireita(20, ' '),
                        pagamento.EnderecoCep.LimiteCaracteres(8),
                        pagamento.EnderecoSiglaEstado.LimiteCaracteres(2),
                        pagamento.DataPagamento.FormatarData(),
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
                    _empresa.BancoCodigo.LimiteCaracteresEsquerda(3, '0'),
                    "0001",
                    "5",
                    "         ",
                    (lote.Count + 1).ToString().LimiteCaracteresEsquerda(6, '0'),
                    _pagamentos.Sum(x => x.Valor).FormatarValor(18, '0'),
                    "000000000000000000",
                    "      ",
                    "".LimiteCaracteresDireita(165, ' '),
                    "          "
                )
            );
            
            remessa.AddRange(lote);
            
            remessa.Add(string.Concat(
                _empresa.BancoCodigo.LimiteCaracteresEsquerda(3, '0'),
                "9999",
                "9",
                "         ",
                "000001",
                (remessa.Count + 1).ToString().LimiteCaracteresEsquerda(6, '0'),
                "000000",
                "".LimiteCaracteresDireita(205, ' ')
            ));

            return remessa.Join("\n");
        }
    }
}