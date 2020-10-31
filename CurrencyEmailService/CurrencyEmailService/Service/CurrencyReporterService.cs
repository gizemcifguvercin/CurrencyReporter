using CurrencyEmailService.Service.Concrete;
using CurrencyEmailService.Service.Contract;

namespace CurrencyEmailService.Service
{
    public class CurrencyReporterService
    {
        private ICurrencyService _currencyService;
        private IEmailService _emailService;


        public CurrencyReporterService()
        {
            _currencyService = new CurrencyService();
            _emailService = new EmailService();
        }

        public bool CurrencyReporter()
        { 
            var currencyList = _currencyService.GetAllCurrency(); 
            bool isSuccess = _emailService.SendReport(currencyList);
            return isSuccess;
        }
    }
}