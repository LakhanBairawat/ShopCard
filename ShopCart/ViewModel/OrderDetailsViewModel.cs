using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.ViewModel
{
    internal class OrderDetailsViewModel
    {
        public OrderDetailsViewModel(INavigation navigation, BuyingSellingProduct selectedOrderItem)
        {
            try
            {
                Navigation = navigation;
                Productlist = [selectedOrderItem];

            }
            catch (Exception ex)
            {

            }
           
        }

        public INavigation Navigation { get; }
        public ObservableCollection<BuyingSellingProduct> Productlist { get; }
    }
}
