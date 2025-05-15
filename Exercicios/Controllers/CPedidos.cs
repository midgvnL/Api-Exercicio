using Exercicios.Models;
using Exercicios.Repositorios.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CPedidos : ControllerBase
    {
        private readonly IPedido _pedidoRepositorio;

        public CPedidos(IPedido pedidoRepositorio)
        {
            _pedidoRepositorio = pedidoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Pedido>>> BuscarTodos()
        {
            return Ok(await _pedidoRepositorio.BuscarTodos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> BuscarPorId(int id)
        {
            return Ok(await _pedidoRepositorio.BuscarPorId(id));
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> Adicionar([FromBody] Pedido pedido)
        {
            return Ok(await _pedidoRepositorio.Adicionar(pedido));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Pedido>> Atualizar(int id, [FromBody] Pedido pedido)
        {
            pedido.UId = id;
            return Ok(await _pedidoRepositorio.Atualizar(pedido, id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            return Ok(await _pedidoRepositorio.Apagar(id));
        }
    }
}
