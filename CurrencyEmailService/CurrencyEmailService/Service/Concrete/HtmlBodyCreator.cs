using System.Collections.Generic;
using System.IO;
using CurrencyEmailService.Model;

namespace CurrencyEmailService.Service.Concrete
{
    public static class HtmlBodyCreator
    {
        public static  string CreateEmailBody(List<CurrencyModel.Result> list) 
        {   
            string body = string.Empty;  
            using(StreamReader reader = new StreamReader(System.IO.Path.GetFullPath("../../MailTemplate/ReportTemplate.html")))   
            {   
                body = reader.ReadToEnd(); 
            }

            string message = "";

            foreach (var curr in list) 
                message += "<b>Name: </b>" + curr.name + " <b>Code: </b>" + curr.code + " <b>Buying: </b>" + curr.buying + " <b>Selling: </b>" + curr.selling + "<br/><br/>";
         
            body = body.Replace("{message}", message);  
            return body;  
  
        }  
    }
}