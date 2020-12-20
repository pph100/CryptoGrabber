using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoGrabber
{
    public interface ICryptoService
    {
        Task<List<CryptoItem>> RefreshDataAsync();
        Task<List<CryptoItem>> RefreshData();
        Task<List<Asset>> RefreshAssetsAsync();
        Task<List<Asset>> RefreshAssets();
        Asset FindAssetByTicker(string tag);
        Task SaveAssetAsync(Asset item, bool isNewItem);
        Task SaveAssetValues(List<CryptoItem> cryptoList);
        string getTotalValue();
        int getNumberOfCryptoItems();
        int getNumberOfAssetItems();
        string GetAssetPriceByTicker(string ticker);
    }
}