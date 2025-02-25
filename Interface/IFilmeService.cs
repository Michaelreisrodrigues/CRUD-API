
using Exemplo_Api_Locadora.Models;

namespace Exemplo_Api_Locadora.Interface
{

    public interface IFilmeService
    {
        Task<IEnumerable<Filme>> ObterFilmesAsync();
        Task<Filme> ObterFilmePorIdAsync(int id);
        Task<Filme> CriarFilmeAsync(Filme filme);
        Task<Filme> AtualizarFilmeAsync(int id, Filme filme);
        Task<bool> DesativarFilmeAsync(int id);
    }
}
