using Exemplo_Api_Locadora.Data;
using Exemplo_Api_Locadora.Interface;
using Exemplo_Api_Locadora.Models;
using Microsoft.EntityFrameworkCore;

namespace Exemplo_Api_Locadora.Services
{
    public class FilmeService : IFilmeService
    {
        private readonly AplicacaoDbContexto _contexto;
        public FilmeService(AplicacaoDbContexto contexto) { _contexto = contexto; }

        public async Task<IEnumerable<Filme>> ObterFilmesAsync() => await _contexto.Filmes.Where(f => f.Ativo).ToListAsync();
        public async Task<Filme> ObterFilmePorIdAsync(int id) => await _contexto.Filmes.FirstOrDefaultAsync(f => f.Id == id && f.Ativo);
        public async Task<Filme> CriarFilmeAsync(Filme filme)
        {
            _contexto.Filmes.Add(filme);
            await _contexto.SaveChangesAsync();
            return filme;
        }
        public async Task<Filme> AtualizarFilmeAsync(int id, Filme filme)
        {
            var filmeExistente = await _contexto.Filmes.FindAsync(id);
            if (filmeExistente == null || !filmeExistente.Ativo) return null;
            filmeExistente.Titulo = filme.Titulo;
            filmeExistente.Genero = filme.Genero;
            filmeExistente.Ano = filme.Ano;
            await _contexto.SaveChangesAsync();
            return filmeExistente;
        }
        public async Task<bool> DesativarFilmeAsync(int id)
        {
            var filme = await _contexto.Filmes.FindAsync(id);
            if (filme == null || !filme.Ativo) return false;
            filme.Ativo = false;
            await _contexto.SaveChangesAsync();
            return true;
        }

    }
}