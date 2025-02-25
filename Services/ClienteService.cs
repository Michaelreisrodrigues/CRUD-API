using Exemplo_Api_Locadora.Data;
using Exemplo_Api_Locadora.Interface;
using Exemplo_Api_Locadora.Models;
using Microsoft.EntityFrameworkCore;

namespace Exemplo_Api_Locadora.Services
{
    public class ClienteService : IClienteService
    {
        private readonly AplicacaoDbContexto _contexto;

        public ClienteService(AplicacaoDbContexto contexto)
        {
            _contexto = contexto;
        }

        // Obter todos os clientes
        public async Task<IEnumerable<Cliente>> GetClientesAsync()
            => await _contexto.Clientes.ToListAsync();

        // Obter um cliente específico pelo ID
        public async Task<Cliente?> GetClienteByIdAsync(int id)
            => await _contexto.Clientes.FirstOrDefaultAsync(c => c.Id == id);

        // Adicionar um novo cliente
        public async Task<Cliente> AddClienteAsync(Cliente cliente)
        {
            _contexto.Clientes.Add(cliente);
            await _contexto.SaveChangesAsync();
            return cliente;
        }

        // Atualizar um cliente existente
        public async Task<Cliente?> UpdateClienteAsync(int id, Cliente cliente)
        {
            var clienteExistente = await _contexto.Clientes.FindAsync(id);
            if (clienteExistente == null) return null;

            clienteExistente.Nome = cliente.Nome;
            clienteExistente.Email = cliente.Email;
            // Adicione outros campos conforme necessário

            await _contexto.SaveChangesAsync();
            return clienteExistente;
        }

        // Deletar um cliente
        public async Task<bool> DeleteClienteAsync(int id)
        {
            var cliente = await _contexto.Clientes.FindAsync(id);
            if (cliente == null) return false;

            _contexto.Clientes.Remove(cliente);
            await _contexto.SaveChangesAsync();
            return true;
        }
    }
}