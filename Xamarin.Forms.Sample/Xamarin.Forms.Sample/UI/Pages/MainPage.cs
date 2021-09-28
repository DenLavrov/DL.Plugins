using Xamarin.Forms.Sample.BL.ViewModels;

namespace Xamarin.Forms.Sample.UI.Pages
{
    public class MainPage: TabbedPage
    {
        public MainPage()
        {
            BindingContext = new MainViewModel();
            Children.Add(new ValidationPage());
            Children.Add(new FilterPage());
        }
    }
}