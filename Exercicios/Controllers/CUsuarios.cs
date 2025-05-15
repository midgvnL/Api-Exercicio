using Exercicios.Models;
using Exercicios.Repositorios.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Exercicios.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CUsuarios : ControllerBase
    {
        private readonly IUsuario _usuarioRepositorio;

        public CUsuarios(IUsuario usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<Usuario>>> BuscarTodos()
        {
            return Ok(await _usuarioRepositorio.BuscarTodos());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> BuscarPorId(int id)
        {
            return Ok(await _usuarioRepositorio.BuscarPorId(id));
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Adicionar([FromBody] Usuario usuario)
        {
            return Ok(await _usuarioRepositorio.Adicionar(usuario));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Usuario>> Atualizar(int id, [FromBody] Usuario usuario)
        {
            usuario.UId = id;
            return Ok(await _usuarioRepositorio.Atualizar(usuario, id));
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Apagar(int id)
        {
            return Ok(await _usuarioRepositorio.Apagar(id));
        }
    }
}
