using cursoApp.Mobile.MVVM.Models;
using cursoApp.Mobile.MVVM.Views;
using cursoApp.Mobile.Responses;
using cursoApp.Mobile.Services;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace cursoApp.Mobile.MVVM.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        private INavigation _navigation;
        private ObservableCollection<Product> _product;
        private readonly IApiService _apiService;
        private static ProductViewModel _instance;

        public event PropertyChangedEventHandler PropertyChanged;

        public ProductViewModel(INavigation navigation, IApiService apiService)
        {
            _instance = this;
            _navigation = navigation;
            _apiService = apiService;
            LoadProductAsync();
        }

        public ObservableCollection<Product> Product
        {
            get { return _product; }
            set
            {
                if (_product != value)
                {
                    _product = value;
                    OnPropertyChanged(nameof(Product));
                }
            }
        }

        public ICommand NewProductCommand => new Command(async () => await ExecuteNewProductCommand());

        public static ProductViewModel GetInstance()
        {
            return _instance;
        }
        private async Task ExecuteNewProductCommand()
        {
            await _navigation.PushAsync(new CreateProductView());
        }
        public async void LoadProductAsync()
        {
            if (Connectivity.NetworkAccess != NetworkAccess.Internet)
            {
                await App.Current.MainPage.DisplayAlert("Error", "No tiene internet", "Aceptar");
                return;
            }

            string url = App.Current.Resources["UrlAPI"].ToString();
            Response response = await _apiService.GetListAsync<Product>(url, "/api", "/products");
            await Task.Delay(2000);


            if (!response.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Aceptar");
                return;
            }

            Product = new ObservableCollection<Product>((List<Product>)response.Result);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}