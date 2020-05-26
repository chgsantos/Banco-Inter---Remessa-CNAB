using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
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
        private readonly DatabaseContext _databaseContext;

        public HomeController(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }
        
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Download()
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

            var remessa = new RemessaService(empresa);
            remessa.AdicionarPagamentos(_databaseContext.Pagamentos.Where(x => x.BancoCodigo == "77" && x.Ativado == 1).ToList());
            
            var content = new System.IO.MemoryStream(Encoding.ASCII.GetBytes(remessa.GerarRemessa()));
            var contentType = "text/plain";
            var fileName = $"remessa-{DateTime.Now:yyyyMMdd}.txt";
                
            return File(content, contentType, fileName);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}