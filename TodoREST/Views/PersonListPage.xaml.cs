using System;
using Xamarin.Forms;

namespace TodoREST
{
    public partial class PersonListPage : ContentPage
    {
        public PersonListPage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            personListView.ItemsSource = await App.PersonManager.GetTasksAsync();
        }

        void OnAddItemClicked(object sender, EventArgs e)
        {
            var PersonItem = new PersonItem()
            {
                ID = Guid.NewGuid().ToString(),
                DttmCreated = System.DateTime.Now.ToString()
            };
            var personPage = new PersonPage(true);
            personPage.BindingContext = PersonItem;
            Navigation.PushAsync(personPage);
        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var personItem = e.SelectedItem as PersonItem;
            var personPage = new PersonPage();

            personPage.BindingContext = personItem;
            Navigation.PushAsync(personPage);
        }

    }
}