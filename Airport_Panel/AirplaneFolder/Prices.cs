using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airport_Panel
{
    public class Prices
    {
        public double PriceEco { get; set; }
        public double PriceComfort { get; set; }
        public double PriceComfortPlus { get; set; }
        public double PriceBusiness { get; set; }
        public Prices(double priceEco, double priceComfort, double priceComfortPlus, double priceBusiness)
        {
            PriceEco = priceEco;
            PriceComfort = priceComfort;
            PriceComfortPlus = priceComfortPlus;
            PriceBusiness = priceBusiness;
        }
        public override string ToString()
        {
            return $"\n\tPrice econom : {PriceEco}\n\tPrice comfort : {PriceComfort}\n\t" +
                $"Price comfort plus : {PriceComfortPlus}\n\tPrice business : {PriceBusiness}";
        }
    }
}
