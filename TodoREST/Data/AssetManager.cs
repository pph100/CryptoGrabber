using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoGrabber
{
    public class AssetManager
    {
        IAssetService assetService;

        public AssetManager(IAssetService service)
        {
            assetService = service;
        }

        public Task<List<Asset>> Refresh()
        {
            return assetService.RefreshData();
        }

        public Task<List<Asset>> RefreshAsync()
        {
            return assetService.RefreshDataAsync();
        }

        public Task<Asset> FindAssetByTicker(string ticker)
        {
            return assetService.FindAssetByTicker(ticker);
        }

    }
}
