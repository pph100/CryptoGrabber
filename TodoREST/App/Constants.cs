namespace CryptoGrabber
{
    public static class Constants
    {
        // Cryptonator API
        public static string CN_BaseURL = "https://de.cryptonator.com/api/ticker/{0}";

        // Coingecko API
        public static string CG_BaseURL = "https://api.coingecko.com/api/v3/simple/price?ids={0}&vs_currencies=eur&include_24hr_vol=true&include_24hr_change=true";

        // new remote base URL, will contain either of above at runtime
        public static string Remote_BaseURL = "";

        // my own Crypto-Rate API
        public static string BaseURL = "http://home.ulip.org";
        public static string UrlPathOrdered = "/api/todo_entry?_sort=Done,-Urgent,Duedate,Author";
        public static string UrlPathUnOrdered = "/api/todo_entry/{0}";
        public static string UrlPort = ":3000";
        public static string RestUrlOrdered = BaseURL + UrlPort + UrlPathOrdered;
        public static string RestUrlUnOrdered = BaseURL + UrlPort + UrlPathUnOrdered;
        public static string RestUrl = RestUrlUnOrdered;

        // Rate Api
        public static string RateURL = "http://home.ulip.org";
        public static string RateXAG = "/api/rates_view_silber/";
        public static string RateXAU = "/api/rates_view_gold/";
        public static string RatePort = ":3001";
        public static string GoldUrl = RateURL + RatePort + RateXAU;
        public static string SilberUrl = RateURL + RatePort + RateXAG;

        // public static string PersonUrl = "http://home.ulip.org:3000/api/person/{0}";
        public static string UrlPersonPath = "/api/person/{0}";
        public static string PersonUrl = BaseURL + UrlPort + UrlPersonPath;

        // Asset
        public static string UrlAssetPath = "/api/asset/{0}";
        public static string AssetUrl = BaseURL + UrlPort + UrlAssetPath;

        // Stock
        public static string UrlStockPath = "/api/stock/{0}";
        public static string StockUrl = BaseURL + UrlPort + UrlStockPath;

        // History
        public static string UrlHistoryPath = "/api/floating_value_100d?_where=(AssetTicker,eq,{0})&_size=300";
        public static string AssetHistoryUrl = BaseURL + UrlPort + UrlHistoryPath;

        // TotalHistory
        public static string UrlTotalHistoryPath = "/api/floating_TotalValue_100d?_size=300";
        public static string AssetTotalHistoryUrl = BaseURL + UrlPort + UrlTotalHistoryPath;
    }
}