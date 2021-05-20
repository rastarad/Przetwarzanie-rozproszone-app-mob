using PeopleStorageApp.DataContracts;
using Xamarin.Forms;

namespace PeopleStorageApp
{
    public partial class App : Application
    {
        public App()
        {
            var client = RestEase.RestClient.For<IPeopleClient>("http://192.168.1.4:6001/api");

            InitializeComponent();

            MainPage = new MainPage(client);
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}