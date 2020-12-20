using System;
using System.Collections.Generic;
using System.Threading.Tasks;
//using System.Diagnostics;
// using System.Runtime.CompilerServices;
//using Xamarin.Forms;
// using Xamarin.Forms.Xaml;

namespace CryptoGrabber
{
    class Program
    {

        public static CryptoItemManager cryptoItemManager { get; private set; }
        public static ComodityManager comodityManager { get; private set; }
        // public static AssetManager AssetManager { get; private set; }
        // public static AssetHistoryManager AssetHistoryManager { get; private set; }

        // public static List<AssetHistory> AssetHistoryList;
        // public static List<Asset> AssetList;
        public static List<CryptoItem> CryptoList;
        public static List<Comodity> ComodityList;

        [Obsolete]
        private async static Task Main(string[] args)
        // private static void Main(string[] args)
        {
            cryptoItemManager = new CryptoItemManager(new CryptoService());

            CryptoList = await cryptoItemManager.RefreshAsync();

        }
    }
}

