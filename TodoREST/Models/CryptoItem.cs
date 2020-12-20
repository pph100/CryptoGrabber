using System;
using Xamarin.Forms;

namespace CryptoGrabber
{

    // for CryptoNator API
    public class TickerItem
    {
        public string @base { get; set; }           // 
        public string cryptoCode { get; set; }      // code, like "BTC" or "ETH"
        public string target { get; set; }          // e.g. "EUR" or "USD". here: eur
        public string price { get; set; }
        public string volume { get; set; }
        public string change { get; set; }


        // added w/CoinGecko
        // public string SearchString { get; set; }
        // public string eur { get; set; }
        // public string eur_24h_vol { get; set; }
        // public string eur_24h_change { get; set; }
    }

    // for CoinGecko API
    public class CoinGeckoItem
    {
        public string SearchString { get; set; }
        public string eur { get; set; }
        public string eur_24h_vol { get; set; }
        public string eur_24h_change { get; set; }
    }

    public class CryptoItem
    {
        public TickerItem ticker { get; set; }
        public CoinGeckoItem CoinGeckoItem { get; set; }
        public int timestamp { get; set; }
        public bool success { get; set; }
        public string error { get; set; }
        // added by me
        public string stock { get; set; }           // float
        public string value { get; set; }           // float
        public Double valueAsDouble { get; set; }           // float
        public string prettyPrice { get; set; }           // float
        public Double priceAsDouble { get; set; }           // float
        public Double stockAsDouble { get; set; }           // float
        public Double lastPrice { get; set; }           // float
        public bool increased { get; set; }           // yes or no
        public bool decreased { get; set; }           // yes or no
        public bool stayedFlat { get; set; }           // yes or no
        public string cryptoName { get; set; }      // "Bitcoin" or "Ethereum"
        public string searchString { get; set; }    // @cryptoCode + "-" + @target, e.g. "BTC-EUR"
        public string DttmLastUpdated { get; set; }
    }
}
