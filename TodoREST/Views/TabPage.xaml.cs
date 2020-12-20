using System;
using Xamarin.Forms;

namespace TodoREST
{
    public partial class TabPage : TabbedPage
    {
        // int activeTabIndex = -1;

        enum TabIndexes : int
        {
            iNone = -1,
            iTodoTab = 0,
            iPersonTab = 1,
            iCryptoTab = 2,
            iAssetTab = 3,
            iAboutTab = 9
        };

        TabIndexes activeTabIndex = TabIndexes.iNone;

        public TabPage()
        {
            InitializeComponent();
        }

        void OnAddItemClicked(object sender, EventArgs e)
        {
            switch (activeTabIndex)
            {
                case TabIndexes.iTodoTab:         // ToDo Tab ist aktiv -> neues Todo
                    var todoItem = new TodoItem()
                    {
                        ID = Guid.NewGuid().ToString(),
                        DttmCreated = System.DateTime.Now.ToString()
                    };
                    var todoPage = new TodoItemPage(true);
                    todoPage.BindingContext = todoItem;
                    Navigation.PushAsync(todoPage);
                    break;

                case TabIndexes.iPersonTab:         // PersonPage ist aktiv -> neue Person
                    var personItem = new PersonItem()
                    {
                        ID = Guid.NewGuid().ToString(),
                        DttmCreated = System.DateTime.Now.ToString()
                    };
                    var personPage = new PersonPage(true);
                    personPage.BindingContext = personItem;
                    Navigation.PushAsync(personPage);
                    break;

                case TabIndexes.iAssetTab:         // bei Tab "Crypto" und bei "Asset": "+" erzeugt neuen Asset
                case TabIndexes.iCryptoTab:
                    var asset = new Asset()
                    {
                        id = Guid.NewGuid().ToString(),
                        DttmCreated = System.DateTime.Now.ToString()
                    };
                    var assetPage = new AssetPage(true);
                    assetPage.BindingContext = asset;
                    Navigation.PushAsync(assetPage);
                    break;

                default:         // keine aktion bei Klick auf Plus bei "Über"
                    break;
            }
        }


        void Handle_Appearing_ToDoPage(object sender, System.EventArgs e)
        {
            activeTabIndex = TabIndexes.iTodoTab;
            Title = "Aufgaben";
        }


        void Handle_Appearing_PersonPage(object sender, System.EventArgs e)
        {
            activeTabIndex = TabIndexes.iPersonTab;
            Title = "Personen";
        }


        void Handle_Appearing_OtherPage(object sender, System.EventArgs e)
        {
            activeTabIndex = TabIndexes.iNone;
            Title = "Über";
        }


        void Handle_Appearing_CryptoPage(object sender, System.EventArgs e)
        {
            activeTabIndex = TabIndexes.iCryptoTab;
            Title = "Cryptos";
        }


        void Handle_Appearing_AssetPage(object sender, System.EventArgs e)
        {
            activeTabIndex = TabIndexes.iAssetTab;
            Title = "Assets";
        }

    }
}