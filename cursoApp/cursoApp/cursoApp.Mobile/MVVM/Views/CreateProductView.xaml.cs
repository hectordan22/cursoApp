using cursoApp.Mobile.MVVM.ViewModels;
using cursoApp.Mobile.Services;

namespace cursoApp.Mobile.MVVM.Views;

public partial class CreateProductView : ContentPage
{
	public CreateProductView()
	{
		InitializeComponent();
        var serviceProvaider = new ServiceCollection()
            .AddSingleton<IApiService, ApiService>()
            .BuildServiceProvider();
        var _apiService = serviceProvaider.GetRequiredService<IApiService>();
        BindingContext = new CreateProductViewModel(_apiService, this.Navigation);

    }
}