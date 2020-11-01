using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using CurrencyEmailServiceCore.Model;
using CurrencyEmailServiceCore.Service.Contract;
using Newtonsoft.Json;

namespace CurrencyEmailServiceCore.Service.Concrete
{
    public class CurrencyService : ICurrencyService
    {
        public CurrencyService() { } 
        public async Task<CurrencyModel.Root> GetAllCurrency()
        {
            using (var client = new HttpClient())
            { 
                try
                {
                    var requestMessage =
                        new HttpRequestMessage(HttpMethod.Get,
                            "https://api.collectapi.com/economy/allCurrency?base=TR");

                    requestMessage.Headers.Add("Authorization", "apikey ***");
                    // account açıp api key alınmalı, api'ya subscribe olunmalı.
                    // https://collectapi.com/tr/api/economy/altin-doviz-ve-borsa-api/borsaIstanbul

                    var result = client.SendAsync(requestMessage);

                    if (result.Result.StatusCode != HttpStatusCode.OK)
                        throw new Exception(result.Result.RequestMessage.ToString());

                    if (result.Result.Content is object &&
                        result.Result.Content.Headers.ContentType.MediaType == "application/json")
                    {
                        var contentStream = await result.Result.Content.ReadAsStreamAsync();
                        var streamReader = new StreamReader(contentStream);
                        var jsonReader = new JsonTextReader(streamReader);

                        JsonSerializer serializer = new JsonSerializer();

                        try
                        {
                            var list = serializer.Deserialize<CurrencyModel.Root>(jsonReader);
                            return list; 
                        }
                        catch (JsonReaderException e)
                        {
                            throw new Exception(e.Message); 
                        }
                    } 
                    throw new Exception("Content/MediaType error");  
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);

                }
            }
        }
    }
}