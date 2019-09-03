using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using CNAB.Models;
using CNAB.Models.Constantes;
using CNAB.Models.Entity;
using CNAB.Services;
using Microsoft.EntityFrameworkCore.Internal;

namespace CNAB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            var empresa = new Empresa
            {
                BancoCodigo = "077",
                BancoNome = "BANCO INTER",
                TipoInscricao = TipoDeInscricao.Cnpj,
                Inscricao = "07448163000180",
                Agencia = "0001",
                AgenciaDigito = "9",
                ContaCorrente = "1130865",
                ContaCorrenteDigito = "6",
                Nome = "INFOWHILE INFORMATICA E SERVICOS LTDA",
                EnderecoLogradouro = "AVENIDA ANTONIO ABRAHAO CARAM",
                EnderecoNumero = "664",
                EnderecoComplemento = "SALA 104",
                EnderecoCidade = "BELO HORIZONTE",
                EnderecoCep = "31275000",
                EnderecoSiglaEstado = "MG"
            };

            var pagamentos = new List<ServicoPagamento>
            {
                new ServicoPagamento
                {
                    TipoServico = TipoDeServico.PagamentoSalarios,
                    BancoCodigo = "077",
                    Agencia = "0001",
                    AgenciaDigito = "9",
                    ContaCorrente = "788371",
                    ContaCorrenteDigito = "4",
                    Nome = "CAIO HENRIQUE GALLI DOS SANTOS",
                    DataPagamento = DateTime.Now,
                    Valor = 100,
                    TipoInscricao = TipoDeInscricao.Cpf,
                    Inscricao = "08477372683",
                    EnderecoLogradouro = "AVENIDA ANTONIO ABRAHAO CARAM",
                    EnderecoNumero = "664",
                    EnderecoComplemento = "SALA 104",
                    EnderecoBairro = "OURO PRETO",
                    EnderecoCidade = "BELO HORIZONTE",
                    EnderecoCep = "31275000",
                    EnderecoSiglaEstado = "MG"
                }
            };

            var remessa = new RemessaService(empresa);
            remessa.AdicionarPagamentos(pagamentos);

            return View(model: remessa.GerarRemessa());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}