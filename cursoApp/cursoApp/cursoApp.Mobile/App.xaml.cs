using cursoApp.Mobile.MVVM.Views;

namespace cursoApp.Mobile;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new TabbedView());
    }

}    
