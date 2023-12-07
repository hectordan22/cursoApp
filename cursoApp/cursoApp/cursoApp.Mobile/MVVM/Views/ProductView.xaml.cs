using cursoApp.Mobile.MVVM.ViewModels;
using cursoApp.Mobile.Services;

namespace cursoApp.Mobile.MVVM.Views;

public partial class ProductView : ContentPage
{
	public ProductView()
	{

        InitializeComponent();
        var serviceProvider = new ServiceCollection()
          .AddSingleton<IApiService, ApiService>()
          .BuildServiceProvider();

        var _apiService = serviceProvider.GetRequiredService<IApiService>();
        BindingContext = new ProductViewModel(this.Navigation, _apiService);
    }
}