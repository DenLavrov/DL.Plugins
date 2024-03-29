using Xamarin.Forms.Markup;
using Xamarin.Forms.Sample.BL.ViewModels;

namespace Xamarin.Forms.Sample.UI.Pages
{
    public class FilterPage: ContentPage
    {
        public FilterPage()
        {
            Title = "Filters";
            BindingContext = new FilterViewModel();
            Content = new ListView(ListViewCachingStrategy.RecycleElement)
            {
                SelectionMode = ListViewSelectionMode.None,
                Footer = new StackLayout
                {
                    Children =
                    {
                        new Button
                        {
                            Text = "Apply filter"
                        }.BindCommand(nameof(FilterViewModel.FilterCommand), parameterPath: null),
                        new Button
                        {
                            Text = "Unapply filter"
                        }.BindCommand(nameof(FilterViewModel.RemoveFilterCommand), parameterPath: null)
                    }
                }
            }.Bind(ListView.ItemsSourceProperty, "Persons.FilteredValue");
        }
    }
}