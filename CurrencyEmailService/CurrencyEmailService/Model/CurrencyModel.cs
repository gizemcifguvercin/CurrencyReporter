using System.Collections.Generic;

namespace CurrencyEmailService.Model
{
    public class CurrencyModel
    {
        public class Result{
            public string name { get; set; } 
            public string code { get; set; } 
            public double buying { get; set; } 
            public double selling { get; set; } 
        }

        public class Root{
            public List<Result> result { get; set; } 
        }

    }
}