using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using WebUI.Models;




namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        public ILogger<HomeController> _logger;
        public HomeController(ILogger<HomeController> logger) => _logger = logger;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult CoinPage()
        {
            return View(MakeRequest());
        }


        public List<Currency> MakeRequest()
        {
            var convert = "USD";
            string API_KEY = "657aa55c-7eaa-47e1-930e-3645320c970e";
            var URL = new UriBuilder("https://pro-api.coinmarketcap.com/v1/cryptocurrency/listings/latest");

            var client = new WebClient();
            client.Headers.Add("X-CMC_PRO_API_KEY", API_KEY);
            client.Headers.Add("Accepts", "application/json");

            var json = client.DownloadString(URL.ToString());
            var content = json.Replace(convert, "CurrenyPriceInfo");

            CoinmarketcapItemData result = JsonConvert.DeserializeObject<CoinmarketcapItemData>(content);

            List<Currency> currencyList = new List<Currency>();

            foreach (ItemData data in result.DataList)
            {
                Currency item = new Currency
                {
                    Id = data.id.ToString(),
                    Name = data.name,
                    Symbol = data.symbol,
                    Rank = data.cmc_rank.ToString(),
                    Price = data.quote.CurrenyPriceInfo.price ?? 0d,
                    Volume24hUsd = data.quote.CurrenyPriceInfo.volume_24h ?? 0,
                    MarketCapUsd = data.quote.CurrenyPriceInfo.volume_24h ?? 0,
                    PercentChange1h = Math.Round(data.quote.CurrenyPriceInfo.percent_change_1h, 2),
                    PercentChange24h = data.quote.CurrenyPriceInfo.percent_change_24h ?? 0,
                    PercentChange7d = data.quote.CurrenyPriceInfo.percent_change_7d ?? 0,
                    LastUpdated = data.quote.CurrenyPriceInfo.last_updated,
                    MarketCapConvert = data.quote.CurrenyPriceInfo.market_cap ?? 0d,
                    ConvertCurrency = convert
                };
                currencyList.Add(item);
            }
            return currencyList;
        }

    }

}

