namespace Exemplo_Api_Locadora.Models
{
    public class Aluguel
    {
        public int Id { get; set; }
        public int FilmeId { get; set; }
        public Filme Filme { get; set; }
        public int ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime DataAluguel { get; set; }
        public DateTime? DataDevolucao { get; set; }
    }
}
