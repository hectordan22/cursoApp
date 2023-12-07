using cursoApp.Mobile.MVVM.ViewModels;
using cursoApp.Mobile.Services;

namespace cursoApp.Mobile.MVVM.Views;

public partial class CreatePersonView : ContentPage
{
	public CreatePersonView()
	{
		InitializeComponent();
       var serviceProvaider = new ServiceCollection()
           .AddSingleton<IApiService, ApiService>()
            .BuildServiceProvider();
       var _apiService = serviceProvaider.GetRequiredService<IApiService>();
        BindingContext = new CreatePersonViewModel(_apiService, this.Navigation);
	}
}