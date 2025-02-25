namespace Exemplo_Api_Locadora.Models
{
    public class Filme
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Genero { get; set; }
        public int Ano { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
