using Controls.UserDialogs.Maui;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopCart.ViewModel
{
    public class OrderSummaryViewModel : BaseViewModel
    {
        public OrderSummaryViewModel(INavigation nav, ObservableCollection<BuyingSellingProduct> buyingProduct)
        {
            navigation = nav;
            BuyingProduct = buyingProduct;
            RemoveItemCommand = new Command<BuyingSellingProduct>(RemoveItem);

        }
        public ICommand RemoveItemCommand { get; }

        private Command _BackCommand;
        public Command BackCommand
        {
            get
            {
                return _BackCommand ?? (_BackCommand = new Command(async () =>
                {
                    try
                    {
                        IsTap = false;
                        await navigation.PopAsync(true);
                    }
                    catch (Exception ex)
                    {

                    }
                }
             ));
            }
        }
                  

        private ObservableCollection<BuyingSellingProduct> buyingproduct =new();
        public ObservableCollection<BuyingSellingProduct> BuyingProduct
        {
            get
            {
                return buyingproduct;
            }
            set
            {
                buyingproduct = value;
                OnPropertyChanged("BuyingProduct");
                OnPropertyChanged("TotalItemPrice");
                OnPropertyChanged("TotalPrice");
            }
        }

        public decimal TotalItemPrice
        {
            get
            {
                if (App.CartItems != null)
                {
                        var totalPrice = App.CartItems.ToList().Sum(p => Convert.ToDecimal(p.Price));
                        return totalPrice;
                }
                return Convert.ToDecimal("0.00");
            }
        }

       

        public decimal TotalPrice
        {
            get
            {
                return TotalItemPrice;
            }
        }


        private ViewModel.BuyingSellingProduct _SelectedOrder;
        public ViewModel.BuyingSellingProduct SelectedOrder
        {
            get
            {
                return _SelectedOrder;
            }
            set
            {
                _SelectedOrder = value;
                OnPropertyChanged("SelectedOrder");
            }
        }
        private void RemoveItem(BuyingSellingProduct product)
        {
            if (product != null && BuyingProduct.Contains(product))
            {
                BuyingProduct.Remove(product);
                App.CartItems.Remove(product);
            }
        }


    }

}
