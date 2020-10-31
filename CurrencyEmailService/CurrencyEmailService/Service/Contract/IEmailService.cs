using System.Threading.Tasks;
using CurrencyEmailService.Model;

namespace CurrencyEmailService.Service.Contract
{
    public interface IEmailService
    {
         bool SendReport(Task<CurrencyModel.Root> currencyList);
    }
}