using System;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace TodoREST
{
    public partial class TodoItemPage : ContentPage
    {
        bool isNewItem;

        public void Handle_doneChanged(object sender, EventArgs e)
        {
            if ((sender as Switch).IsToggled)
            {
                completedPicker.IsEnabled = true;
                if ((completedPicker.Items.Count > 0) && (completedPicker.SelectedItem == null))
                    completedPicker.Focus();
            }
            else
            {
                completedPicker.IsEnabled = false;
            }
        }


        public TodoItemPage(bool isNew = false)
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


        protected async override void OnAppearing()
        {
            base.OnAppearing();
            if (isNewItem)
                dueEntry.SetValue(DatePicker.MinimumDateProperty, DateTime.Now);

            var Personlist = await App.PersonManager.GetTasksAsync();
            var NameList = new System.Collections.Generic.List<String>();
            object _responsibleSelectedItem = null,
                   _completedSelectedItem = null;

            foreach (PersonItem p in Personlist)
            {
                NameList.Add(p.Name);
            }

            if (!isNewItem)
            {
                _responsibleSelectedItem = responsiblePicker.SelectedItem;
                _completedSelectedItem = completedPicker.SelectedItem;
            }

            // populate responsiblePicker
            responsiblePicker.ItemsSource = NameList;

            if (!isNewItem)
            {
                if (_responsibleSelectedItem == null)
                {
                    responsiblePicker.SelectedItem = null;
                    responsiblePicker.Title = "Select a Person";
                }
                else
                {
                    responsiblePicker.SelectedItem = _responsibleSelectedItem;
                    responsiblePicker.Title = _responsibleSelectedItem.ToString();
                }

            }

            // populate completedPicker
            completedPicker.ItemsSource = NameList;

            if (!isNewItem)
            {
                if (_completedSelectedItem == null)
                {
                    completedPicker.SelectedItem = null;
                    completedPicker.Title = "Select a Person";
                }
                else
                {
                    completedPicker.SelectedItem = _completedSelectedItem;
                    completedPicker.Title = _completedSelectedItem.ToString();
                }
            }

            if (isNewItem)
            {
                notesEntry.Focus();
            }

        }


        void Handle_CompletedByChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (completedPicker.Title.Length > 0)
            {
                doneSwitch.IsToggled = true;
            }
            else
            {
                doneSwitch.IsToggled = false;
            }
        }


        void Handle_NotesChanged(object sender, Xamarin.Forms.TextChangedEventArgs e)
        {
            if (notesEntry.Text.Length > 0)
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
            var todoItem = (TodoItem)BindingContext;

            todoItem.DttmLastUpdated = System.DateTime.Now.ToString();
            await App.TodoManager.SaveTaskAsync(todoItem, isNewItem);
            await Navigation.PopAsync();
        }


        async void OnDeleteActivated(object sender, EventArgs e)
        {
            var todoItem = (TodoItem)BindingContext;
            await App.TodoManager.DeleteTaskAsync(todoItem);
            await Navigation.PopAsync();
        }


        void OnCancelActivated(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }

    }
}
