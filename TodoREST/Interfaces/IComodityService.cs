using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoGrabber
{
    public interface IComodityService
    {
        Task<List<Comodity>> RefreshDataAsync();
        Task<List<Comodity>> RefreshData();
        Task SaveAssetValues(List<Comodity> comodityList);
    }
}