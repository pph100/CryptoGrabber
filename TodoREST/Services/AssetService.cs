using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using System.Net;
using System.Web;
using System.Globalization;

namespace CryptoGrabber
{
    public class AssetService : IAssetService
    {
        HttpClient assetClient;

        public List<Asset> Assets { get; private set; }

        public Asset _asset { get; private set; }


        public AssetService()
        {
            assetClient = new HttpClient();
            assetClient.MaxResponseContentBufferSize = 256000;
            Assets = new List<Asset>();
            _asset = new Asset();
        }


        public async Task<List<Asset>> RefreshData()
        {
            if (Assets == null || Assets.Count < 1)
            {
                Assets = await this.RefreshDataAsync();
            }
            return Assets;
        }


        public async Task<Asset> FindAssetByTicker(string tag)
        {
            if (Assets == null || Assets.Count < 1)
            {
                Assets = await this.RefreshDataAsync();
            }

            foreach (var asset in Assets)
            {
                if (asset.AssetTicker.Equals(tag))
                {
                    _asset = asset;
                    break;
                }

            }
            return _asset;
        }


        public async Task<List<Asset>> RefreshDataAsync()
        {
            var uri = new Uri(string.Format(Constants.AssetUrl, string.Empty));

            try
            {
                var response = await assetClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Assets = JsonConvert.DeserializeObject<List<Asset>>(content);

                    foreach (var __asset in Assets)
                    {
                        if (__asset.AssetValue == null)
                        {
                            __asset.prettyValue = "N/A";
                        }
                        else
                        {
                            var prettyPrice = (__asset.AssetClass == "Comodity") ? Double.Parse(__asset.AssetValue, new CultureInfo("de-DE")) : Double.Parse(__asset.AssetValue, new CultureInfo("en-US"));
                            __asset.prettyValue = prettyPrice > 2.0 ? prettyPrice.ToString("C2", new CultureInfo("de-DE")) : prettyPrice.ToString("C4", new CultureInfo("de-DE"));
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"               ERROR {0}", ex.Message);
                Debug.WriteLine(@"Unsuccessful connect to URI {0} at {1}", uri, System.DateTime.Now);
                Console.WriteLine("Connection to  " + uri + "@" + System.DateTime.Now + " revealed: " + ex.Message);
            }

            return Assets;
        }

    }

}

