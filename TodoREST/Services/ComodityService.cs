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
    public class ComodityService : IComodityService
    {
        HttpClient comodityClient;

        public List<Comodity> Comodities { get; private set; }

        public Comodity _comodity { get; private set; }


        public ComodityService()
        {
            comodityClient = new HttpClient();
            comodityClient.MaxResponseContentBufferSize = 256000;
            Comodities = new List<Comodity>();
            _comodity = new Comodity();
        }


        public async Task<List<Comodity>> RefreshData()
        {
            if (Comodities == null || Comodities.Count < 1)
            {
                Comodities = await this.RefreshDataAsync();
            }
            return Comodities;
        }


        public async Task<List<Comodity>> RefreshDataAsync()
        {

            // Gold: XAU
            var uri = new Uri(string.Format(Constants.GoldUrl, string.Empty));
            try
            {
                var response = await comodityClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    Comodities = JsonConvert.DeserializeObject<List<Comodity>>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"               ERROR {0}", ex.Message);
                Debug.WriteLine(@"Unsuccessful connect to URI {0} at {1}", uri, System.DateTime.Now);
                Console.WriteLine("Connection to  " + uri + "@" + System.DateTime.Now + " revealed: " + ex.Message);
            }

            // Silber: XAG
            uri = new Uri(string.Format(Constants.SilberUrl, string.Empty));
            try
            {
                var response = await comodityClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var _comodities = JsonConvert.DeserializeObject<List<Comodity>>(content);
                    foreach (var _c in _comodities)
                    {
                        Comodities.Add(_c);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(@"               ERROR {0}", ex.Message);
                Debug.WriteLine(@"Unsuccessful connect to URI {0} at {1}", uri, System.DateTime.Now);
                Console.WriteLine("Connection to  " + uri + "@" + System.DateTime.Now + " revealed: " + ex.Message);
            }

            return Comodities;
        }

        /*
        Task<List<Comodity>> IComodityService.RefreshDataAsync()
        {
            throw new NotImplementedException();
        }

        Task<List<Comodity>> IComodityService.RefreshData()
        {
            throw new NotImplementedException();
        }
        */

        public Task SaveAssetValues(List<Comodity> comodityList)
        {
            throw new NotImplementedException();
        }
    }

}

