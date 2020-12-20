using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace CryptoGrabber
{
    public interface IAssetHistoryService
    {
        Task<ObservableCollection<AssetHistory>> RefreshDataAsync();
        Task<ObservableCollection<AssetHistory>> RefreshData();
        Task<ObservableCollection<AssetHistory>> setAssetHistoryTicker(string newTicker);
        Task<ObservableCollection<AssetHistory>> setAssetHistoryTicker();
        Task<ObservableCollection<AssetHistory>> getAssetHistory();
        bool setJustAssetTicker(string newTicker);
        Task<ObservableCollection<AssetTotalHistory>> getAssetTotalHistory();
    }
}