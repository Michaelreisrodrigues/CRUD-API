using Exemplo_Api_Locadora.Interface;
using Exemplo_Api_Locadora.Models;
 using Microsoft.AspNetCore.Mvc;

namespace Exemplo_Api_Locadora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly IFilmeService _filmeService;
        public FilmesController(IFilmeService filmeService) { _filmeService = filmeService; }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filme>>> ObterFilmes() => Ok(await _filmeService.ObterFilmesAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult<Filme>> ObterFilme(int id)
        {
            var filme = await _filmeService.ObterFilmePorIdAsync(id);
            if (filme == null) return NotFound();
            return Ok(filme);
        }

        [HttpPost]
        public async Task<ActionResult<Filme>> CriarFilme(Filme filme)
        {
            var filmeCriado = await _filmeService.CriarFilmeAsync(filme);
            return CreatedAtAction(nameof(ObterFilme), new { id = filmeCriado.Id }, filmeCriado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> AtualizarFilme(int id, Filme filme)
        {
            var filmeAtualizado = await _filmeService.AtualizarFilmeAsync(id, filme);
            if (filmeAtualizado == null) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DesativarFilme(int id)
        {
            var desativado = await _filmeService.DesativarFilmeAsync(id);
            if (!desativado) return NotFound();
            return NoContent();
        }
    }
}
