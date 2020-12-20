using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TodoREST
{
    public partial class AssetPage : ContentPage
    {

        bool isNewItem;

        public AssetPage()
        {
            InitializeComponent();
        }

        public AssetPage(bool isNew = false)
        {
            InitializeComponent();
            isNewItem = isNew;
        }


        void OnCancelActivated(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }


        async void OnSaveActivated(object sender, EventArgs e)
        {
            var asset = (Asset)BindingContext;

            asset.DttmLastUpdated = System.DateTime.Now.ToString("dd.MM.yy HH:mm:ss");
            await App.CryptoItemManager.SaveAssetAsync(asset, isNewItem);
            await Navigation.PopAsync();
        }

    }
}
