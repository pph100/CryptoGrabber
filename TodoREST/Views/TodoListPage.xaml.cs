using System;
using System.Globalization;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TodoREST
{
    public partial class TodoListPage : ContentPage
    {

        public TodoListPage()
        {
            InitializeComponent();

            listView.RefreshCommand = new Command(async () =>
            {
                await RefreshData();
                listView.IsRefreshing = false;
            });
        }


        private async Task RefreshData()
        {
            var todoList = await App.TodoManager.GetTasksAsync();
            listView.ItemsSource = todoList;
        }


        protected async override void OnAppearing()
        {
            base.OnAppearing();

            await this.RefreshData();
        }


        void OnAddItemClicked(object sender, EventArgs e)
        {
            var todoItem = new TodoItem()
            {
                ID = Guid.NewGuid().ToString()
                ,
                DttmCreated = System.DateTime.Now.ToString("d", CultureInfo.CreateSpecificCulture("de-DE"))
            };
            var todoPage = new TodoItemPage(true);
            todoPage.BindingContext = todoItem;
            Navigation.PushAsync(todoPage);
        }


        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var todoItem = e.SelectedItem as TodoItem;
            var todoPage = new TodoItemPage();

            todoPage.BindingContext = todoItem;
            Navigation.PushAsync(todoPage);
        }


        public async void OnComplete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var todoItem = mi.BindingContext as TodoItem;
            todoItem.Done = !todoItem.Done;
            todoItem.DttmLastUpdated = System.DateTime.Now.ToString();
            await App.TodoManager.SaveTaskAsync(todoItem, false);
            await RefreshData();
        }


        public async void OnUrgent(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var todoItem = mi.BindingContext as TodoItem;
            todoItem.Urgent = !todoItem.Urgent;
            todoItem.DttmLastUpdated = System.DateTime.Now.ToString();
            await App.TodoManager.SaveTaskAsync(todoItem, false);
            await RefreshData();
        }


        public async void OnCancel(object sender, EventArgs e)
        {
            await RefreshData();
        }


        public async void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            var todoItem = mi.BindingContext as TodoItem;
            todoItem.DttmLastUpdated = System.DateTime.Now.ToString();
            await App.TodoManager.DeleteTaskAsync(todoItem);
            await RefreshData();
        }

    }
}