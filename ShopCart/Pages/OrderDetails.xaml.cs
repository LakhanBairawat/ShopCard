using Controls.UserDialogs.Maui;
using ShopCart.ViewModel;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ShopCart.Pages;

public partial class OrderDetails : ContentPage
{
    ObservableCollection<BuyingSellingProduct> list;
    OrderDetailsViewModel vm;
    public OrderDetails(BuyingSellingProduct selectedOrderItem)
    {
        try
        {
            InitializeComponent();
            BindingContext =vm= new OrderDetailsViewModel(this.Navigation, selectedOrderItem);
            list = new ObservableCollection<BuyingSellingProduct>
            {
              selectedOrderItem
            };
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }

    }

    private void AddTocard_Clicked(object sender, EventArgs e)
    {
        try
        {
            App.CartItems.Add(list.FirstOrDefault() as BuyingSellingProduct);

        }
        catch (Exception ex)
        {

        }
    }

    private void Checkout_Clicked(object sender, EventArgs e)
    {
        try
        {
            if (App.CartItems != null || App.CartItems.Count > 0)
            {
                Navigation.PushAsync(new OrderSummaryView(App.CartItems));
            }
            else
            {
                UserDialogs.Instance.ShowToast("Please add Item in Your cart");
            }

        }
        catch (Exception ex)
        {

        }
    }
}