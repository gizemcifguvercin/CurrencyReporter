using System.Threading.Tasks;
using CurrencyEmailService.Model;

namespace CurrencyEmailService.Service.Contract
{
    public interface ICurrencyService
    {
        Task<CurrencyModel.Root> GetAllCurrency(); 
    }
}