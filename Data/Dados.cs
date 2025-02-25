using Exemplo_Api_Locadora.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Exemplo_Api_Locadora.Data
{

    public class AplicacaoDbContexto : DbContext
    {
        public AplicacaoDbContexto(DbContextOptions<AplicacaoDbContexto> options) : base(options) { }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Aluguel> Alugueis { get; set; }
    }
}

