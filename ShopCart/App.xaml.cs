using Controls.UserDialogs.Maui;
using ShopCart.ViewModel;
using System.Collections.ObjectModel;

namespace ShopCart
{
    public partial class App : Application
    {
        public static bool HasNoInternet { get; set; }    //Used for check Internet Connection
         public static ObservableCollection<BuyingSellingProduct> CartItems {  get; set; }=new ();
        public App()
        {
            InitializeComponent();
            HasNoInternet = Connectivity.NetworkAccess == NetworkAccess.Internet;
            Connectivity.ConnectivityChanged += Connectivity_ConnectivityChanged;//Method Check Interner Connection
                                                                                 // Start checking for internet connectivity
            MainPage = new MainPage();
        }

        #region Internet Connection

        #region check internet Connectivity Changed
        private async void Connectivity_ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
        {
            try
            {
                var newNetworkAccess = e.NetworkAccess;
                if (newNetworkAccess == NetworkAccess.Internet)
                {
                    // Internet connectivity is restored
                    HasNoInternet = true;
                }
                else
                {
                    // Internet connectivity is lost
                    HasNoInternet = false;

                    await UserDialogs.Instance.AlertAsync("No Internet available");
                }
            }
            catch (Exception ex)
            {
            }
        }
        #endregion

        #region Check Internet Connection function
        public static async Task<bool> Internetstate()
        {
            try
            {
                if (App.HasNoInternet)
                {
                    return HasNoInternet;
                }
                else
                {
                    if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                    {
                        HasNoInternet = true;
                        return true;
                    }
                    else
                    {
                        var Duration = DateTime.Now.AddSeconds(10);

                        while (Duration > DateTime.Now)
                        {
                            await Task.Delay(100);
                            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
                            {
                                HasNoInternet = true;
                                return true;
                            }
                            else
                            {
                                HasNoInternet = false;
                            }

                        }
                    }
                    return HasNoInternet;
                }
            }
            catch (Exception ex)
            {
                return HasNoInternet;
            }
        }
        #endregion

        #endregion

    }
}
