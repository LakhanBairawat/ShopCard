using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ShopCart.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region Constructor
        public BaseViewModel()
        {
        }
        #endregion

        #region INotifyPropertyChanged
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            try
            {
                var changed = PropertyChanged;
                if (changed == null)
                    return;

                changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion

        #region Properties
        private INavigation _navigation = null;
        public INavigation navigation
        {
            get { return _navigation; }
            set { _navigation = value; OnPropertyChanged("navigation"); }
        }


       
        private bool _IsBusy = false;
        public bool IsBusy
        {
            get { return _IsBusy; }
            set { _IsBusy = value; OnPropertyChanged("IsBusy"); }
        }

        private bool _IsTap = false;
        public bool IsTap
        {
            get { return _IsTap; }
            set { _IsTap = value; OnPropertyChanged("IsTap"); }
        }

        private double _RowHeight = 300;
        public double RowHeight
        {
            get { return _RowHeight; }
            set { _RowHeight = value; OnPropertyChanged("RowHeight"); }
        }

        private bool _IsNoData = false;
        public bool IsNoData
        {
            get { return _IsNoData; }
            set { _IsNoData = value; OnPropertyChanged("IsNoData"); }
        }

        private bool _IsShowFilter = false;
        public bool IsShowFilter
        {
            get { return _IsShowFilter; }
            set { _IsShowFilter = value; OnPropertyChanged("IsShowFilter"); }
        }

        private Color _ThemeColor = Colors.Orange;
        public Color ThemeColor
        {
            get { return _ThemeColor; }
            set { _ThemeColor = value; OnPropertyChanged("ThemeColor"); }
        }

        
        #endregion

        #region Commands
        private Command _LoginBackCommand;
        public Command LoginBackCommand
        {
            get
            {
                return _LoginBackCommand ?? (_LoginBackCommand = new Command(async () =>
                {
                    if (navigation != null)
                    {
                        try
                        {                           

                            await navigation.PopAsync(true);
                        }
                        catch (Exception ex)
                        {
                            IsTap = false;
                        }

                    }
                }
             ));
            }
        }
        
        #endregion

        #region Method

           

        #endregion
    }

    public class BaseViewModelWithoutProperty : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged
        protected bool SetProperty<T>(ref T backingStore, T value,
            [CallerMemberName] string propertyName = "",
            Action onChanged = null)
        {
            if (EqualityComparer<T>.Default.Equals(backingStore, value))
                return false;

            backingStore = value;
            onChanged?.Invoke();
            OnPropertyChanged(propertyName);
            return true;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            try
            {
                var changed = PropertyChanged;
                if (changed == null)
                    return;

                changed.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        private Color _ThemeColor = Colors.Orange;
        public Color ThemeColor
        {
            get { return _ThemeColor; }
            set { _ThemeColor = value; OnPropertyChanged("ThemeColor"); }
        }
        #endregion
    }
}
