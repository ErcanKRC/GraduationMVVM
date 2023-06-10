namespace GraduationMVVM.MVVM.Views;

using GraduationMVVM.MVVM.ViewModels;
using Microsoft.Maui.Controls;

public partial class DevicePageView : ContentPage
{
    public DevicePageViewModel viewModel = new DevicePageViewModel();

    public DevicePageView()
    {
        InitializeComponent();
        App.Pages.DevicePage = this;
        viewModel.DevicetoBind = App.SelectedDevice;
        BindingContext = viewModel;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.IsActiveRequest();
    }

}