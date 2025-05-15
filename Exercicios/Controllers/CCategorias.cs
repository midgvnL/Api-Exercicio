using Exercicios.Models;
using Exercicios.Repositorios.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Intrinsics.X86;

namespace Exercicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CCategorias : ControllerBase
    {
        private readonly ICategoria _categoriaRepositorio;

        public CCategorias(ICategoria categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Categoria>>> BuscarTodos()
        {
            return Ok(await _categoriaRepositorio.BuscarTodos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> BuscarPorId(int id)
        {
            return Ok(await _categoriaRepositorio.BuscarPorId(id));
        }

        [HttpPost]
        public async Task<ActionResult<Categoria>> Adicionar([FromBody] Categoria categoria)
        {
            return Ok(await _categoriaRepositorio.Adicionar(categoria));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Categoria>> Atualizar(int id, [FromBody] Categoria categoria)
        {
            categoria.Id = id;
            return Ok(await _categoriaRepositorio.Atualizar(categoria, id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            return Ok(await _categoriaRepositorio.Apagar(id));
        }
    }

}
