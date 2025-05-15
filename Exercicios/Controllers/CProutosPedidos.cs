using Exercicios.Models;
using Exercicios.Repositorios.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CProutosPedidos : ControllerBase
    {
        private readonly IProdutosPedidos _produtosPedidosRepositorio;

        public CProutosPedidos(IProdutosPedidos produtosPedidosRepositorio)
        {
            _produtosPedidosRepositorio = produtosPedidosRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<PedidoProdutos>>> BuscarTodos()
        {
            return Ok(await _produtosPedidosRepositorio.BuscarTodos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PedidoProdutos>> BuscarPorId(int id)
        {
            return Ok(await _produtosPedidosRepositorio.BuscarPorId(id));
        }

        [HttpPost]
        public async Task<ActionResult<PedidoProdutos>> Adicionar([FromBody] PedidoProdutos pedidoProduto)
        {
            return Ok(await _produtosPedidosRepositorio.Adicionar(pedidoProduto));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PedidoProdutos>> Atualizar(int id, [FromBody] PedidoProdutos pedidoProduto)
        {
            pedidoProduto.Id = id;
            return Ok(await _produtosPedidosRepositorio.Atualizar(pedidoProduto, id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            return Ok(await _produtosPedidosRepositorio.Apagar(id));
        }
    }
}
