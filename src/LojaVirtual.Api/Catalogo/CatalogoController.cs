using LojaVirtual.Catalogo.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace LojaVirtual.Api.Catalogo
{
    [ApiController]
    [Route("[controller]")]
    public class CatalogoController : ControllerBase
    {
        private static int produtoId = 1;

        private static readonly List<ProdutoDto> produtos = new List<ProdutoDto> {
            new ProdutoDto {
                Id = produtoId++, Nome = "iPhone XS Max", Imagem = "assets/produtos/iphone.webp",
                Preco = 9999.99M, Ativo = false
            },
            new ProdutoDto {
                Id = produtoId++, Nome = "Galaxy Note 10", Imagem = "assets/produtos/galaxy.webp",
                Preco = 4999.99M, Ativo = true
            }
        };

        [HttpPost("produtos")]
        public ActionResult<ProdutoDto> CadastrarProduto(CriarProdutoDto dto)
        {
            var produto = new ProdutoDto
            {
                Id = Interlocked.Increment(ref produtoId),
                Nome = dto.Nome,
                Imagem = dto.Imagem,
                Preco = dto.Preco,
                Ativo = dto.Ativo
            };

            produtos.Add(produto);

            return Ok(produto);
        }

        [HttpGet("departamentos")]
        public ActionResult<DepartamentoDto[]> GetDepartamentos()
        {
            var items = new DepartamentoDto[] {
                new DepartamentoDto { Id = 1, Nome = "Celulares", Ativo = true },
                new DepartamentoDto { Id = 2, Nome = "Notebooks", Ativo = false }
            };

            return Ok(items);
        }

        [HttpGet("produtos")]
        public ActionResult<ProdutoDto[]> GetProdutos()
        {
            return Ok(produtos.ToArray());
        }

        [HttpGet("produtos/{id:int}")]
        public ActionResult<ProdutoDto> GetProdutoPorId(int id)
        {
            var produto = produtos.FirstOrDefault(x => x.Id == id);

            if (produto == null)
            {
                // 204
                // return NoContent(); 

                // 404
                return NotFound();
            }

            return Ok(produto);
        }

        [HttpPost("produtos/{id:int}")]
        public ActionResult<ProdutoDto> AtualizarProduto(EditarProdutoDto dto)
        {
            var produto = produtos.FirstOrDefault(x => x.Id == dto.Id);

            if (produto == null)
            {
                return NotFound();
            }

            produto.Nome = dto.Nome;
            produto.Preco = dto.Preco;
            produto.Imagem = dto.Imagem;
            produto.Ativo = dto.Ativo;

            return Ok(produto);
        }
    }
}