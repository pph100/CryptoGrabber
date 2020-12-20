
namespace CryptoGrabber
{

    // for CryptoNator API
    public class Asset
    {
        public string id { get; set; }
        public string AssetTicker { get; set; }     // code, like "BTC" or "ETH", "XAU", "XAG" etc
        public string AssetName { get; set; }       // name, like "Bitcoin" or "Ethereum", "Silbermünzen", "Goldbarren" etc.
        public string AssetStock { get; set; }
        public string SearchString { get; set; }
        // added w/CoinGecko
        public string SearchString2 { get; set; }
        public string Source { get; set; }
        // added end
        public string AssetClass { get; set; }      // e.g. "Crypto" or "Comodity"
        public string AssetValue { get; set; }      // float: price of asset per piece
        public string prettyValue { get; set; }      // float: price of asset per piece
        public string AssetValueDttm { get; set; }      // float: price of asset per piece
        public bool   IncludeInList { get; set; }     // flag: include this asset in list?
        public string DttmCreated { get; set; }
        public string DttmLastUpdated { get; set; }
    }

    public class Stock
    {
        public string id { get; set; }
        public string AssetName { get; set; }       // name, like above
        public string AssetValue { get; set; }      // float: price of asset per piece
        public string AssetStock { get; set; }      // float: number of items per asset in Stock
        public string AssetTotalValue { get; set; } // float: number * price
        public string DttmCreated { get; set; }
        public string DttmLastUpdated { get; set; }
    }
}
