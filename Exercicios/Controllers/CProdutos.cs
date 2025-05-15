using Exercicios.Models;
using Exercicios.Repositorios.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CProdutos : ControllerBase
    {
        private readonly IProduto _produtoRepositorio;

        public CProdutos(IProduto produtoRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Produtos>>> BuscarTodos()
        {
            return Ok(await _produtoRepositorio.BuscarTodos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Produtos>> BuscarPorId(int id)
        {
            return Ok(await _produtoRepositorio.BuscarPorId(id));
        }

        [HttpPost]
        public async Task<ActionResult<Produtos>> Adicionar([FromBody] Produtos produto)
        {
            return Ok(await _produtoRepositorio.Adicionar(produto));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Produtos>> Atualizar(int id, [FromBody] Produtos produto)
        {
            produto.Id = id;
            return Ok(await _produtoRepositorio.Atualizar(produto, id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            return Ok(await _produtoRepositorio.Apagar(id));
        }
    }
}
