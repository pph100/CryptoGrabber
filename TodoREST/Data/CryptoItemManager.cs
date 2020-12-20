using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoGrabber
{
    public class CryptoItemManager
    {
        ICryptoService cryptoService;


        public CryptoItemManager(ICryptoService service)
        {
            cryptoService = service;
        }


        public Task<List<CryptoItem>> Refresh()
        {
            return cryptoService.RefreshData();
        }


        public Task<List<CryptoItem>> RefreshAsync()
        {
            return cryptoService.RefreshDataAsync();
        }


        public Task SaveAssetAsync(Asset item, bool isNewItem)
        {
            return cryptoService.SaveAssetAsync(item, isNewItem);
        }


        public Asset FindAssetByTicker(string ticker)
        {
            return cryptoService.FindAssetByTicker(ticker);
        }


        public Task SaveAssetValues(List<CryptoItem> cryptoList)
        {
            return cryptoService.SaveAssetValues(cryptoList);
        }

        public string getTotalValue()
        {
            return cryptoService.getTotalValue();
        }


        public int getNumberOfCryptoItems()
        {
            return cryptoService.getNumberOfCryptoItems();
        }


        public int getNumberOfAssetItems()
        {
            return cryptoService.getNumberOfAssetItems();
        }


        public string getAssetPriceByTicker(string ticker)
        {
            return cryptoService.GetAssetPriceByTicker(ticker);
        }

    }
}
