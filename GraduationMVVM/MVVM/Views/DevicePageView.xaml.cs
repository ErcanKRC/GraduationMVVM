namespace GraduationMVVM.MVVM.Views;

using GraduationMVVM.MVVM.Models;
using GraduationMVVM.MVVM.ViewModels;
using Microsoft.Maui.Controls;

public partial class DevicePageView : ContentPage
{
   private DevicePageViewModel viewModel;
   private DevicesModel _device;
    public DevicePageView(DevicesModel device)
    {
        InitializeComponent();
        _device = device;

        viewModel = new DevicePageViewModel(this,_device);
        viewModel.Name = _device.Name;
        viewModel.Server = _device.Server;
        viewModel.Token= _device.Token;

        BindingContext = viewModel;
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

    }
    public async void Settings()
    {
        await Navigation.PushAsync(new DeviceSettingsPageView(_device));
    }
}