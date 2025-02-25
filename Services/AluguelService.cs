using Exemplo_Api_Locadora.Data;
using Exemplo_Api_Locadora.Interface;
using Exemplo_Api_Locadora.Models;
using Microsoft.EntityFrameworkCore;

namespace Exemplo_Api_Locadora.Services
{
    public class AluguelService : IAluguelService
    {
        private readonly AplicacaoDbContexto _contexto;

        public AluguelService(AplicacaoDbContexto contexto)
        {
            _contexto = contexto;
        }

        // Obter todos os alugu�is
        public async Task<IEnumerable<Aluguel>> GetAlugueisAsync()
            => await _contexto.Alugueis.Include(a => a.Cliente).Include(a => a.Filme).ToListAsync();

        // Obter um aluguel espec�fico pelo ID
        public async Task<Aluguel?> GetAluguelByIdAsync(int id)
            => await _contexto.Alugueis.Include(a => a.Cliente).Include(a => a.Filme).FirstOrDefaultAsync(a => a.Id == id);

        // Criar um novo aluguel
        public async Task<Aluguel> AddAluguelAsync(Aluguel aluguel)
        {
            _contexto.Alugueis.Add(aluguel);
            await _contexto.SaveChangesAsync();
            return aluguel;
        }

        // Registrar devolu��o do aluguel
        public async Task<bool> DevolverAluguelAsync(int id)
        {
            var aluguel = await _contexto.Alugueis.FindAsync(id);
            if (aluguel == null) return false;

            aluguel.DataDevolucao = DateTime.UtcNow;
            await _contexto.SaveChangesAsync();
            return true;
        }
    }
}