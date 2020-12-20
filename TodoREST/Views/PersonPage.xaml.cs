using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TodoREST
{
    public partial class PersonPage : ContentPage
    {

        bool isNewItem;

        public PersonPage()
        {
            InitializeComponent();
        }

        public PersonPage(bool isNew = false)
        {
            InitializeComponent();
            isNewItem = isNew;
            if (isNew)
            {
                DeleteButton.IsEnabled = false;
            }
            else
            {
                DeleteButton.IsEnabled = true;
            }
        }

        void Handle_NameChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (personEntry.Text.Length > 0)
            {
                SaveButton.IsEnabled = true;
            }
            else
            {
                SaveButton.IsEnabled = false;
            }
        }

        async void OnSaveActivated(object sender, EventArgs e)
        {
            var personItem = (PersonItem)BindingContext;

            personItem.DttmLastUpdated = System.DateTime.Now.ToString();
            await App.PersonManager.SaveTaskAsync(personItem, isNewItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteActivated(object sender, EventArgs e)
        {
            var personItem = (PersonItem)BindingContext;
            await App.PersonManager.DeleteTaskAsync(personItem);
            await Navigation.PopAsync();
        }

        void OnCancelActivated(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

    }
}
