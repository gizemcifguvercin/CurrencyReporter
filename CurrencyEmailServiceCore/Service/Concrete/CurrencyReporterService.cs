
using CurrencyEmailServiceCore.Service.Contract;

namespace CurrencyEmailServiceCore.Service.Concrete
{
    public class CurrencyReporterService : ICurrencyReporterService
    {
        private ICurrencyService _currencyService;
        private IEmailService _emailService;

        public CurrencyReporterService(ICurrencyService currencyService, IEmailService emailService)
        {
            _currencyService = currencyService;
            _emailService = emailService;
        }
        public bool CurrencyReporter()
        { 
            var currencyList = _currencyService.GetAllCurrency(); 
            bool isSuccess = _emailService.SendReport(currencyList);
            return isSuccess;
        }
 
    }
}