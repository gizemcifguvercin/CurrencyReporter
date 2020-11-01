using System.Threading.Tasks;
using CurrencyEmailServiceCore.Model;

namespace CurrencyEmailServiceCore.Service.Contract
{
    public interface IEmailService
    {
         bool SendReport(Task<CurrencyModel.Root> currencyList);
    }
}