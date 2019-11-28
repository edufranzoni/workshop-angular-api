using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LojaVirtual.Api.Catalogo.Dtos;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LojaVirtual.Api.Catalogo
{
    [Route("[controller]")]
    [ApiController]
    public class CatalogoController : ControllerBase
    {
        [EnableCors]
        [HttpGet("departamentos")]
        public ActionResult<DepartamentoDto[]> GetDepartamentos()
        {
            var departamentos = new DepartamentoDto[]
            {
                new DepartamentoDto {Id = 1, Nome = "Celulares", Ativo = true},
                new DepartamentoDto {Id = 1, Nome = "Notebooks", Ativo = false}
            };

            return Ok(departamentos);
        }

        [EnableCors]
        [HttpPost("produtos")]
        public ActionResult CadastrarProduto(CriarProdutoDto produto)
        { 
            return Ok();
        }

        [EnableCors]
        [HttpGet("produtos")]
        public ActionResult<ProdutoDto[]> GetProdutos()
        {
           var departamentos = new ProdutoDto[]
           {
                new ProdutoDto {Id = 1, Nome = "Iphone XS Max", Ativo = false, Preco = 9999.99M, Imagem = "assets/produtos/iphone.webp"},
                new ProdutoDto {Id = 1, Nome = "Galaxy Note 10", Ativo = true, Preco = 9999.99M, Imagem = "assets/produtos/galaxy.webp"}
           };

           return Ok(departamentos);
        }
    }
}