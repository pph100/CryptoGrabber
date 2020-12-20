using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TodoREST
{
    public partial class AssetListPage : ContentPage
    {

        public AssetListPage()
        {
            InitializeComponent();

            listView.RefreshCommand = new Command(async () =>
            {
                await RefreshDataAsync();
                listView.IsRefreshing = false;
            });
        }


        private async Task RefreshData()
        {
            var cryptoList = await App.AssetManager.Refresh();
            listView.ItemsSource = cryptoList;
        }


        private async Task RefreshDataAsync()
        {
            var cryptoList = await App.AssetManager.RefreshAsync();
            foreach (var _crypto in cryptoList)
            {
                _crypto.AssetValue = App.CryptoItemManager.getAssetPriceByTicker(_crypto.AssetTicker);
            }
            var newlist = cryptoList.OrderByDescending(x => x.AssetValue).ToList();
            listView.ItemsSource = newlist;
        }


        void OnAssetSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var asset = e.SelectedItem as Asset;
            var assetPage = new AssetPage();

            assetPage.BindingContext = asset;
            Navigation.PushAsync(assetPage);
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await RefreshDataAsync();
        }


        public async void OnCancel(object sender, EventArgs e)
        {
            await RefreshData();
        }


        public async void OnCopyToNew(object sender, EventArgs e)
        {
            await RefreshData();
        }

    }
}