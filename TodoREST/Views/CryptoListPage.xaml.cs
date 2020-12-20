using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CryptoGrabber
{
    public partial class CryptoListPage : ContentPage
    {

        enum ViewSortOrder : int
        {
            unsorted = 0,
            sortByName = 1,
            sortByStock = 2,
            sortByPrice = 3,
            sortByValue = 4
        };

        bool sortDescending = true;

        ViewSortOrder sortOrder = ViewSortOrder.unsorted;

        public CryptoListPage()
        {
            InitializeComponent();
            sortOrder = ViewSortOrder.sortByValue;
            xValueLabel.Text = "Value ▾";
            sortDescending = true;

            listView.RefreshCommand = new Command(async () =>
            {
                App._debug("CryptoListPage:RefreshCommand()", "function called");
                await RefreshDataAsync();
                listView.IsRefreshing = false;
                App._debug("CryptoListPage:RefreshCommand()", "function ended");
            });

        }


        private async Task _refresh(List<CryptoItem> cryptoList)
        {
            App._debug("CryptoListPage:_refresh()", "function called");
            var totalValue = App.CryptoItemManager.getTotalValue();
            var newlist = cryptoList;

            if (sortDescending)
            {
                switch (sortOrder)
                {
                    case ViewSortOrder.sortByName:
                        newlist = newlist.OrderByDescending(x => x.cryptoName).ToList();
                        xNameLabel.Text = "Name ▾";
                        xPriceLabel.Text = "Price";
                        xStockLabel.Text = "Stock";
                        xValueLabel.Text = "Value";
                        break;
                    case ViewSortOrder.sortByPrice:
                        newlist = newlist.OrderByDescending(x => x.priceAsDouble).ToList();
                        xPriceLabel.Text = "Price ▾";
                        xNameLabel.Text = "Name";
                        xStockLabel.Text = "Stock";
                        xValueLabel.Text = "Value";
                        break;
                    case ViewSortOrder.sortByStock:
                        newlist = newlist.OrderByDescending(x => x.stockAsDouble).ToList();
                        xNameLabel.Text = "Name";
                        xPriceLabel.Text = "Price";
                        xStockLabel.Text = "Stock ▾";
                        xValueLabel.Text = "Value";
                        break;
                    case ViewSortOrder.sortByValue:
                        newlist = newlist.OrderByDescending(x => x.valueAsDouble).ToList();
                        xNameLabel.Text = "Name";
                        xPriceLabel.Text = "Price";
                        xStockLabel.Text = "Stock";
                        xValueLabel.Text = "Value ▾";
                        break;
                    default:
                        break;
                }
            }
            else
            {
                switch (sortOrder)
                {
                    case ViewSortOrder.sortByName:
                        newlist = newlist.OrderBy(x => x.cryptoName).ToList();
                        xNameLabel.Text = "Name ▴";
                        xPriceLabel.Text = "Price";
                        xStockLabel.Text = "Stock";
                        xValueLabel.Text = "Value";
                        break;
                    case ViewSortOrder.sortByPrice:
                        newlist = newlist.OrderBy(x => x.priceAsDouble).ToList();
                        xPriceLabel.Text = "Price ▴";
                        xNameLabel.Text = "Name";
                        xStockLabel.Text = "Stock";
                        xValueLabel.Text = "Value";
                        break;
                    case ViewSortOrder.sortByStock:
                        newlist = newlist.OrderBy(x => x.stock).ToList();
                        xPriceLabel.Text = "Price";
                        xNameLabel.Text = "Name";
                        xStockLabel.Text = "Stock ▴";
                        xValueLabel.Text = "Value";
                        break;
                    case ViewSortOrder.sortByValue:
                        newlist = newlist.OrderBy(x => x.valueAsDouble).ToList();
                        xPriceLabel.Text = "Price";
                        xNameLabel.Text = "Name";
                        xStockLabel.Text = "Stock";
                        xValueLabel.Text = "Value ▴";
                        break;
                    default:
                        break;
                }

            }
            listView.ItemsSource = newlist;
            xTotal.Text = totalValue;
            xSum.Text = "Total:";
            // await App.CryptoItemManager.SaveAssetValues(newlist);
            App._debug("CryptoListPage:_refresh()", "function ended");
        }


        private async Task RefreshData()
        {
            App._debug("CryptoListPage:RefreshData()", "function called");
            var cryptoList = await App.CryptoItemManager.Refresh();

            await this._refresh(cryptoList);
            App._debug("CryptoListPage:RefreshData()", "function ended");
        }


        private async Task RefreshDataAsync()
        {
            App._debug("CryptoListPage:RefreshDataAsync()", "function called, calling RefreshAsync now");
            listView.IsRefreshing = true;
            var cryptoList = await App.CryptoItemManager.RefreshAsync();
            // listView.IsRefreshing = false;
            await this._refresh(cryptoList);
            App._debug("CryptoListPage:RefreshDataAsync()", "about to call function SaveAssetValues");
            Debug.WriteLine("Achtung: Call SaveAssetValues() aus CryptoListPage.xaml.cs!");
            await App.CryptoItemManager.SaveAssetValues(cryptoList);
            listView.IsRefreshing = false;
            App._debug("CryptoListPage:RefreshDataAsync()", "function ended");
        }


        async void OnAssetSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var cryptoItem = e.SelectedItem as CryptoItem;
            //
            // asset-Chart anzeigen:
            //
            var assetHistoryPage = new AssetHistoryPage(true);
            var assetHistory = await App.AssetHistoryManager.setAssetHistoryTicker(cryptoItem.ticker.cryptoCode);
            await Navigation.PushAsync(assetHistoryPage);
        }


        async void OnAssetSelectedEdit(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var cryptoItem = mi.BindingContext as CryptoItem;
            var asset = App.CryptoItemManager.FindAssetByTicker(cryptoItem.ticker.cryptoCode);
            var assetPage = new AssetPage();

            assetPage.BindingContext = asset;
            await Navigation.PushAsync(assetPage);
        }


        async void OnAssetSelectedValue(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var cryptoItem = mi.BindingContext as CryptoItem;
            //
            // asset-Chart anzeigen:
            //
            var assetHistoryPage = new AssetHistoryPage(true);


            App._debug("CryptoListPage:OnAssetSelectedValue()", "function called, about to call setAssetHistoryTicker(" + cryptoItem.ticker.cryptoCode + ")");
            // rausnehmen: funktioniert das?
            var assetHistory = await App.AssetHistoryManager.setAssetHistoryTicker(cryptoItem.ticker.cryptoCode);
            await Navigation.PushAsync(assetHistoryPage);
        }


        async void OnAssetSelectedTotalValue(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var cryptoItem = mi.BindingContext as CryptoItem;
            //
            // asset-Chart anzeigen:
            //
            var assetHistoryPage = new AssetHistoryPage(false);
            var assetHistory = await App.AssetHistoryManager.setAssetHistoryTicker(cryptoItem.ticker.cryptoCode);
            await Navigation.PushAsync(assetHistoryPage);
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            listView.IsRefreshing = true;
            // test: schneller?
            // await RefreshDataAsync();
            App._debug("CryptoListPage:OnAppearing()", "function called, about to call RefreshData()");
            await RefreshData();
            listView.IsRefreshing = false;
        }


        public async void OnCancel(object sender, EventArgs e)
        {
            App._debug("CryptoListPage:OnCancel()", "function called, about to call RefreshData()");
            await RefreshData();
        }


        private async void NameTapped(object sender, EventArgs e)
        {
            var _label = sender as Label;
            switch (sortOrder)
            {
                case ViewSortOrder.sortByName:
                    sortDescending = !sortDescending;
                    await this.RefreshData();
                    break;

                default:
                    sortDescending = true;
                    sortOrder = ViewSortOrder.sortByName;
                    await this.RefreshData();
                    break;
            }
        }


        private async void PriceTapped(object sender, EventArgs e)
        {
            var _label = sender as Label;
            switch (sortOrder)
            {
                case ViewSortOrder.sortByPrice:
                    sortDescending = !sortDescending;
                    await this.RefreshData();
                    break;

                default:
                    sortDescending = true;
                    sortOrder = ViewSortOrder.sortByPrice;
                    await this.RefreshData();
                    break;
            }
        }


        private async void StockTapped(object sender, EventArgs e)
        {
            var _label = sender as Label;
            switch (sortOrder)
            {
                case ViewSortOrder.sortByStock:
                    sortDescending = !sortDescending;
                    await this.RefreshData();
                    break;

                default:
                    sortDescending = true;
                    sortOrder = ViewSortOrder.sortByStock;
                    await this.RefreshData();
                    break;
            }
        }


        private async void ValueTapped(object sender, EventArgs e)
        {
            var _label = sender as Label;
            switch (sortOrder)
            {
                case ViewSortOrder.sortByValue:
                    sortDescending = !sortDescending;
                    await this.RefreshData();
                    break;

                default:
                    sortDescending = true;
                    sortOrder = ViewSortOrder.sortByValue;
                    await this.RefreshData();
                    break;
            }
        }


        private async void TotalValueTapped(object sender, EventArgs e)
        {
            var _label = sender as Label;
            var assetHistoryPage = new AssetHistoryPage(3);
            // var assetHistory = await App.AssetHistoryManager.getAssetTotalHistory();
            await Navigation.PushAsync(assetHistoryPage);
        }
    }
}