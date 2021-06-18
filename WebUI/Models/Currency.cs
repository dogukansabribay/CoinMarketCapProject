using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebUI.Models
{
    public class Currency
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Symbol { get; set; }
        public string Rank { get; set; }

        [DisplayFormat(DataFormatString = "{0:N2}")]
        [Display(Name ="Price(USD)")]
        public double Price { get; set; }

        [Display(Name = "Volume(24h)")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double Volume24hUsd { get; set; }

        [Display(Name = "MarketCap(USD)")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double MarketCapUsd { get; set; }

        [Display(Name ="1h %")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public decimal PercentChange1h { get; set; }

        [Display(Name = "24h %")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double PercentChange24h { get; set; }

        [Display(Name = "7d %")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public double PercentChange7d { get; set; }
        [DataType(DataType.Date)]

        [Display(Name = "Last Update")]
        public DateTime LastUpdated { get; set; }

        [Display(Name = "Market Cap")]
        [DisplayFormat(DataFormatString = "{0:N2}")]
        public Double MarketCapConvert { get; set; }

        [Display(Name = "Currency")]
        public string ConvertCurrency { get; set; }

    }
}
