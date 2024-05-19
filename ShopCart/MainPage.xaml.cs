using ShopCart.ViewModel;

namespace ShopCart
{
    public partial class MainPage : ContentPage
    {
        private BuyingListViewModel vm;
        public MainPage()
        {
            InitializeComponent();
            BindingContext =vm= new BuyingListViewModel("Product",this.Navigation);
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            vm.GetBuyingOrderList();
        }
    }
}
