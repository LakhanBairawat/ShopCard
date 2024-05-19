using Controls.UserDialogs.Maui;
using ShopCart.Helpers;
using ShopCart.ViewModel;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ShopCart.Pages;

public partial class OrderSummaryView : ContentPage
{
    OrderSummaryViewModel vm;
    
    public OrderSummaryView(ObservableCollection<BuyingSellingProduct> cartItems)
    {
        InitializeComponent();
        BindingContext = vm = new OrderSummaryViewModel(this.Navigation, cartItems);
    }

    protected override void OnAppearing()
    {
        //if (vm.BuyingProduct.ShippingAddress != null)
        //{
        //    vm.FormattedAdd = Global.AddressFormatter(vm.BuyingProduct.ShippingAddress);
        //}
        base.OnAppearing();
    }

    private void SelectItem_Tapped(object sender, EventArgs e)
    {
        try
        {
            //var selectedProduct = ((BuyingSellingOrderItem)((TappedEventArgs)e).Parameter).Product;
            //if (selectedProduct != null)
            //{
            //    var item = JsonConvert.SerializeObject(selectedProduct);
            //    vm.navigation.PushAsync(new ItemDetailsPage(JsonConvert.DeserializeObject<Model.DashBoardModel>(item), true));
            //}
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }
}
