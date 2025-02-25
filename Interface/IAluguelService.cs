using Exemplo_Api_Locadora.Models;

namespace Exemplo_Api_Locadora.Interface
{
	public interface IAluguelService
	{
		Task<IEnumerable<Aluguel>> GetAlugueisAsync();
		Task<Aluguel?> GetAluguelByIdAsync(int id);
		Task<Aluguel> AddAluguelAsync(Aluguel aluguel);
		Task<bool> DevolverAluguelAsync(int id);
	}
}