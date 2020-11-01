using System.Threading.Tasks;
using CurrencyEmailServiceCore.Model;

namespace CurrencyEmailServiceCore.Service.Contract
{
    public interface ICurrencyService
    {
        Task<CurrencyModel.Root> GetAllCurrency(); 
    }
}