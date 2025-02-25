using Exemplo_Api_Locadora.Interface;
using Exemplo_Api_Locadora.Models;
using Microsoft.AspNetCore.Mvc;

namespace Exemplo_Api_Locadora.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClienteController : ControllerBase
	{
		private readonly IClienteService _clienteService;

		public ClienteController(IClienteService clienteService)
		{
			_clienteService = clienteService;
		}

		// Obter todos os clientes
		[HttpGet]
		public async Task<ActionResult<IEnumerable<Cliente>>> ObterClientes()
			=> Ok(await _clienteService.GetClientesAsync());

		// Obter um cliente por ID
		[HttpGet("{id}")]
		public async Task<ActionResult<Cliente>> ObterCliente(int id)
		{
			var cliente = await _clienteService.GetClienteByIdAsync(id);
			if (cliente == null) return NotFound();
			return Ok(cliente);
		}

		// Criar um novo cliente
		[HttpPost]
		public async Task<ActionResult<Cliente>> CriarCliente(Cliente cliente)
		{
			var clienteCriado = await _clienteService.AddClienteAsync(cliente);
			return CreatedAtAction(nameof(ObterCliente), new { id = clienteCriado.Id }, clienteCriado);
		}

		// Atualizar cliente
		[HttpPut("{id}")]
		public async Task<IActionResult> AtualizarCliente(int id, Cliente cliente)
		{
			var clienteAtualizado = await _clienteService.UpdateClienteAsync(id, cliente);
			if (clienteAtualizado == null) return NotFound();
			return NoContent();
		}

		// Deletar cliente
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeletarCliente(int id)
		{
			var deletado = await _clienteService.DeleteClienteAsync(id);
			if (!deletado) return NotFound();
			return NoContent();
		}
	}
}