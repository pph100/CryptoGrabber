using System;
using System.Collections.Generic;
using Xamarin.Essentials;
using Xamarin.Forms;
using Syncfusion.SfChart.XForms;
using System.Globalization;
using System.Collections.ObjectModel;

namespace TodoREST
{
    public partial class AssetHistoryPage : ContentPage
    {

        enum CallToBeMade
        {
            noCall = 0,
            callSingleValue = 1,
            callTotalValue = 2,
            callTotalSum = 3
        };

        CallToBeMade callType = CallToBeMade.noCall;
        // private bool singleValue = true; // true: display chart with single Values per item per day
        // false: display chart with Total Values per item per day

        public AssetHistoryPage()
        {
            InitializeComponent();
            callType = CallToBeMade.callSingleValue;
        }


        public AssetHistoryPage(bool SingleOrTotal)
        {
            InitializeComponent();
            if (SingleOrTotal == true)
            {
                callType = CallToBeMade.callSingleValue;
            }
            else
            {
                callType = CallToBeMade.callTotalValue;
            }

        }


        public AssetHistoryPage(int CallType)
        {
            InitializeComponent();
            callType = (CallToBeMade)CallType;
        }


        protected async override void OnAppearing()
        {
            // var newItemsSource = await App.AssetHistoryManager.getAssetHistory();
            ObservableCollection<AssetTotalHistory> newItemsTotalSource; // = await App.AssetHistoryManager.getAssetHistory();
            ObservableCollection<AssetHistory> newItemsSource;

            // myLineSeries.ItemsSource = newItemsSource;

            NumericalAxis secondaryAxis = new NumericalAxis();
            secondaryAxis.LabelCreated += SecondaryAxis_LabelCreated;       // set CallBack function, see below
            mySfChart.SecondaryAxis = secondaryAxis;

            myLineSeries.ItemsSource = null;

            switch (callType)
            {
                case CallToBeMade.callSingleValue:
                    newItemsSource = await App.AssetHistoryManager.getAssetHistory();
                    myLineSeries.ItemsSource = newItemsSource;
                    mySfChart.Title.Text = "Value History for " + newItemsSource[0].AssetName;
                    myLineSeries.YBindingPath = "daily_avg";
                    // myLineSeries.YBindingPath = "avg_NK_4";
                    myLineSeries.XBindingPath = "DT_DMY";
                    break;

                case CallToBeMade.callTotalValue:
                    newItemsSource = await App.AssetHistoryManager.getAssetHistory();
                    myLineSeries.ItemsSource = newItemsSource;
                    mySfChart.Title.Text = "Total value History for " + newItemsSource[0].AssetName;
                    // myLineSeries.YBindingPath = "daily_value";
                    myLineSeries.YBindingPath = "daily_value_formatted";
                    myLineSeries.XBindingPath = "DT_DMY";
                    break;

                case CallToBeMade.callTotalSum:
                    newItemsTotalSource = await App.AssetHistoryManager.getAssetTotalHistory();
                    myLineSeries.ItemsSource = newItemsTotalSource;
                    mySfChart.Title.Text = "Total overall Value History";
                    myLineSeries.YBindingPath = "daily_total";
                    myLineSeries.XBindingPath = "DT_DMY";
                    break;
            }

            base.OnAppearing();
        }


        private void SecondaryAxis_LabelCreated(object sender, Syncfusion.SfChart.XForms.ChartAxisLabelEventArgs e)
        {

            var yVal = Convert.ToDouble(e.LabelContent, new CultureInfo("de-DE"));

            if (yVal > 999.9)
                e.LabelContent = yVal.ToString("C0", new CultureInfo("de-DE"));
            else
                e.LabelContent = yVal > 2.0 ? yVal.ToString("C2", new CultureInfo("de-DE")) : yVal.ToString("C4", new CultureInfo("de-DE"));
        }


    }
}
