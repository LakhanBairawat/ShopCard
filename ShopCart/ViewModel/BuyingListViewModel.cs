using Controls.UserDialogs.Maui;
using ShopCart.Helpers;
using ShopCart.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.ViewModel
{
    public class BuyingListViewModel : BaseViewModel
    {
        public int PageNumber = 1;

        public string Title;
        public BuyingListViewModel(string title, INavigation _nav)
        {                                                                                      
            navigation = _nav;
            Title = title;
        }



        #region Properties
        private ObservableCollection<BuyingSellingProduct> _SellByProductList = new ObservableCollection<BuyingSellingProduct>();
        public ObservableCollection<BuyingSellingProduct> SellByProductList
        {
            get { return _SellByProductList; }
            set { _SellByProductList = value; OnPropertyChanged("SellByProductList"); }
        }



        private ObservableCollection<BuyingSellingProduct> _tempSellByProductList = new ObservableCollection<BuyingSellingProduct>();
        public ObservableCollection<BuyingSellingProduct> TempSellByProductList
        {
            get { return _tempSellByProductList; }
            set
            {
                _tempSellByProductList = value;
                OnPropertyChanged("TempSellByProductList");
                if (TempSellByProductList.Count == 0)
                    IsNoData = true;
                else
                    IsNoData = false;
            }
        }

        private BuyingSellingProduct _SelectedOrderItem;
        public BuyingSellingProduct SelectedOrderItem
        {
            get { return _SelectedOrderItem; }
            set
            {
                _SelectedOrderItem = value;
                OnPropertyChanged("SelectedOrderItem");
                if (_SelectedOrderItem != null)
                {
                    NavigateToOrderSummary();

                }
            }
        }

        private async void NavigateToOrderSummary()
        {
            if (SelectedOrderItem != null)
            {
                await navigation.PushAsync(new OrderDetails(SelectedOrderItem));
                SelectedOrderItem = null;
            }
        }



        private string _SearchedString;
        public string SearchedString
        {
            get { return _SearchedString; }
            set
            {
                _SearchedString = value;
                OnPropertyChanged("SearchedString");
                try
                {

                    if (!string.IsNullOrEmpty(_SearchedString))
                    {
                        var searchList = SellByProductList.Where(p => p.ProductName.ToLower().Contains(_SearchedString.ToLower()) || p.ProductName.ToLower().StartsWith(_SearchedString.ToLower()));
                        TempSellByProductList = new ObservableCollection<BuyingSellingProduct>(searchList);
                    }
                    else
                    {
                        TempSellByProductList = new ObservableCollection<BuyingSellingProduct>(SellByProductList.ToList());
                    }

                }
                catch (Exception ex)
                {

                }
            }
        }


        #endregion

        #region Method


        public async void GetBuyingOrderList()
        {
            try
            {
                if (!App.HasNoInternet)
                {
                    UserDialogs.Instance.ShowToast("Internet not available");
                    IsTap = false;
                    return;
                }
                UserDialogs.Instance.ShowLoading("Loading, please wait...");
                await Task.Delay(50);
                var ProductList = new List<BuyingSellingProduct>
  {
    new BuyingSellingProduct
    {
        ProductName = "Sneaker",
        Price = "1499",
        Size="L",
        Brand="Zara",
        ProductImage = "photo7",
                        Description="The style you want and the feel you need all rolled into this shirt."

    },
    new BuyingSellingProduct
    {
        ProductName = "Suits",
        Price = "1349", 
        Size="L",
        Brand="Zara",
        ProductImage = "photo8",
                        Description="Premium quality Full sleeves Plain Shirt direct from the manufacturer with very affordable Price which gives you perfect fit."

    },
    new BuyingSellingProduct
    {
        ProductName = "Top",
        Price = "1699", 
        Size="L",
        Brand="Zara",
        ProductImage = "photo9",
                        Description="Premium quality Full sleeves Plain Shirt direct from the manufacturer with very affordable Price which gives you perfect fit. The style you want and the feel you need all rolled into this shirt."

    },
    new BuyingSellingProduct
    {
        ProductName = "green Top",
        Price = "1299", 
        Size="L",
        Brand="Levis",
        ProductImage = "photo10",
                Description="Premium quality Full sleeves Plain Shirt direct from the manufacturer with very affordable Price which gives you perfect fit. The style you want and the feel you need all rolled into this shirt."

    },
    new BuyingSellingProduct
    {
        ProductName = "Bag",
        Price = "1999",
         Size="L",
        Brand="Zara",
        ProductImage = "photo7",
                Description="Premium quality Full sleeves Plain Shirt direct from the manufacturer with very affordable Price which gives you perfect fit, comfort feeling with handsome look.Our product is made with such design which is wearable at All the Occations Like Formal Wear, Office wear, Weekend even Some of light colors at Beach also Wear it with some slacks to the office and throw on some jeans at night for drinks with the guys. The style you want and the feel you need all rolled into this shirt."

    },
    new BuyingSellingProduct
    {
        ProductName = "Bag",
        Price = "1999",
         Size="L",
        Brand="Zara",
        ProductImage = "photo8",
                Description="Premium quality Full sleeves Plain Shirt direct from the manufacturer with very affordable Price which gives you perfect fit, comfort feeling with handsome look.Our product is made with such design which is wearable at All the Occations Like Formal Wear, Office wear, Weekend even Some of light colors at Beach also Wear it with some slacks to the office and throw on some jeans at night for drinks with the guys. The style you want and the feel you need all rolled into this shirt."

    }, 
    new BuyingSellingProduct
    {
        ProductName = "Cap",
        Price = "1999",
         Size="L",
        Brand="Spyker",
        ProductImage = "photo9",
                Description="Premium quality Full sleeves Plain Shirt direct from the manufacturer with very affordable Price which gives you perfect fit, comfort feeling with handsome look.Our product is made with such design which is wearable at All the Occations Like Formal Wear, Office wear, Weekend even Some of light colors at Beach also Wear it with some slacks to the office and throw on some jeans at night for drinks with the guys. The style you want and the feel you need all rolled into this shirt."

    }, 
    new BuyingSellingProduct
    {
        ProductName = "Jacket Black",
        Price = "1999",
         Size="L",
        Brand="Jack&Johns",
        ProductImage = "photo8",
                Description="Premium quality Full sleeves Plain Shirt direct from the manufacturer with very affordable Price which gives you perfect fit, comfort feeling with handsome look.Our product is made with such design which is wearable at All the Occations Like Formal Wear, Office wear, Weekend even Some of light colors at Beach also Wear it with some slacks to the office and throw on some jeans at night for drinks with the guys. The style you want and the feel you need all rolled into this shirt."

    },  
    new BuyingSellingProduct
    {
        ProductName = "Scarf",
        Price = "1999",
         Size="L",
        Brand="Zara",
        ProductImage = "photo9",
                Description="Premium quality Full sleeves Plain Shirt direct from the manufacturer with very affordable Price which gives you perfect fit, comfort feeling with handsome look.Our product is made with such design which is wearable at All the Occations Like Formal Wear, Office wear, Weekend even Some of light colors at Beach also Wear it with some slacks to the office and throw on some jeans at night for drinks with the guys. The style you want and the feel you need all rolled into this shirt."

    }, 
    new BuyingSellingProduct
    {
        ProductName = "Jacket",
        Price = "4999",
         Size="L",
        Brand="Zara",
        ProductImage = "photo10",
                Description="Premium quality Full sleeves Plain Shirt direct from the manufacturer with very affordable Price which gives you perfect fit, comfort feeling with handsome look.Our product is made with such design which is wearable at All the Occations Like Formal Wear, Office wear, Weekend even Some of light colors at Beach also Wear it with some slacks to the office and throw on some jeans at night for drinks with the guys. The style you want and the feel you need all rolled into this shirt."

    }, 
    new BuyingSellingProduct
    {
        ProductName = "Shirt",
        Price = "1999",
        Size="L",
        Brand="Zara",
        ProductImage = "photo7",
        Description="Premium quality Full sleeves Plain Shirt direct from the manufacturer with very affordable Price which gives you perfect fit, comfort feeling with handsome look.Our product is made with such design which is wearable at All the Occations Like Formal Wear, Office wear, Weekend even Some of light colors at Beach also Wear it with some slacks to the office and throw on some jeans at night for drinks with the guys. The style you want and the feel you need all rolled into this shirt."
    },
};

                _SellByProductList = new ObservableCollection<BuyingSellingProduct>(ProductList);
                SellByProductList = _SellByProductList;
                var temp = SellByProductList.ToList();
                TempSellByProductList = new ObservableCollection<BuyingSellingProduct>(temp);
                UserDialogs.Instance.HideHud();

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                UserDialogs.Instance.Alert(ex.Message);
                UserDialogs.Instance.HideHud();
            }
            finally
            {

            }
        }




        #endregion
    }
    public class BuyingSellingProduct
    {
        public int Id { get; set; }
        public string UserFirstName { get; set; }
        public int UserId { get; set; }
        public string UserProfile { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string Source { get; set; }
        public string ProductName { get; set; }
        public string Size { get; set; }
        public string ProductRating { get; set; }
        public string ProductCondition { get; set; }
        public string ProductColor { get; set; }
        public string ProductCategory { get; set; }
        public string ParentCategory { get; set; }
        public string Brand { get; set; }
        public string StoreType { get; set; }
        public string Quantity { get; set; }
        public string Availability { get; set; }
        public string TagImage { get; set; }
        public string Description { get; set; }
        public bool IsLike { get; set; }

        public int? LikeCount { get; set; }
        public string ProductImage { get; set; }
        public string Gender { get; set; }
        public List<string> otherImages { get; set; }
        public string Price { get; set; }
        public string ProdDetails
        {
            get
            {
                return Global.ProdDetailsFormatter(Price, Size, Brand);
            }

        }

        public string ShippingPrice { get; set; }

        public string EarningPrice
        {
            get
            {

                var twentyPercent = Convert.ToDouble(Price?.Replace("$", "")) * 20 / 100;
                return Convert.ToString(Convert.ToDouble(Price?.Replace("$", "")) - twentyPercent);
            }
        }

    }

    public class ShippingAddress
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public int ShippingAddressId { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public bool IsDefault { get; set; }
        public string Country { get; set; }
        public bool IsBilling { get; set; }
        public bool IsBillingShippingSame { get; set; }
    }

}
