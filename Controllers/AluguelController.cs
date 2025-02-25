using Exemplo_Api_Locadora.Interface;
using Exemplo_Api_Locadora.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exemplo_Api_Locadora.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AluguelController : ControllerBase
	{
		private readonly IAluguelService _aluguelService;

		public AluguelController(IAluguelService aluguelService)
		{
			_aluguelService = aluguelService;
		}

		// Obter todos os aluguéis
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Aluguel>>> ObterAlugueis()
			=> Ok(await _aluguelService.GetAlugueisAsync());

		// Obter aluguel por ID
		[HttpGet("{id}")]
		public async Task<ActionResult<Aluguel>> ObterAluguel(int id)
		{
			var aluguel = await _aluguelService.GetAluguelByIdAsync(id);
			if (aluguel == null) return NotFound();
			return Ok(aluguel);
		}

		// Criar novo aluguel
		[HttpPost]
		public async Task<ActionResult<Aluguel>> CriarAluguel(Aluguel aluguel)
		{
			var aluguelCriado = await _aluguelService.AddAluguelAsync(aluguel);
			return CreatedAtAction(nameof(ObterAluguel), new { id = aluguelCriado.Id }, aluguelCriado);
		}

		// Devolver aluguel
		[HttpPut("devolver/{id}")]
		public async Task<IActionResult> DevolverAluguel(int id)
		{
			var sucesso = await _aluguelService.DevolverAluguelAsync(id);
			if (!sucesso) return NotFound();
			return NoContent();
		}
	}
}
