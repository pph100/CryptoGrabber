using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CryptoGrabber
{
    public class ComodityManager
    {
        IComodityService comodityService;

        public ComodityManager(IComodityService service)
        {
            comodityService = service;
        }

        public Task<List<Comodity>> Refresh()
        {
            return comodityService.RefreshData();
        }

        public Task<List<Comodity>> RefreshAsync()
        {
            return comodityService.RefreshDataAsync();
        }

        public Task SaveAssetValues(List<Comodity> comodityList)
        {
            return comodityService.SaveAssetValues(comodityList);
        }
    }
}
