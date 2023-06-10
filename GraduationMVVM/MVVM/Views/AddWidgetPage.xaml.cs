using GraduationMVVM.MVVM.ViewModels;

namespace GraduationMVVM.MVVM.Views;

public partial class AddWidgetPage : ContentPage
{
    AddWidgetPageViewModel viewModel = new AddWidgetPageViewModel();
    public AddWidgetPage()
    {
        InitializeComponent();

        App.Pages.AddWidgetPage = this;
        BindingContext = viewModel;
    }

    private void WidgetTypePicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        switch (WidgetTypePicker.SelectedItem.ToString())
        {
            case "Button":
                viewModel.WidgetType = "Button";
                break;
            case "Switch":
                viewModel.WidgetType = "Switch";
                break;
            case "Gauge":
                viewModel.WidgetType = "Gauge";
                break;
            case "Slider":
                viewModel.WidgetType = "Slider";
                break;
        };

    }
}