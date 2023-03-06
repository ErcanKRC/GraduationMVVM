using GraduationMVVM.MVVM.Models;
using GraduationMVVM.MVVM.ViewModels;
using Microsoft.Maui.Controls;

namespace GraduationMVVM.MVVM.Views;

public partial class DevicesPageView : ContentPage
{
    DevicesModel _device;
    public DevicesPageView()
    {
        InitializeComponent();

        BindingContext = new DevicesPageViewModel(this);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Devices_List_View.ItemsSource = App.DevicesRepository.GetAll();
    }
    public void Refresh()
    {
        Devices_List_View.ItemsSource = App.DevicesRepository.GetAll();
    }

    private async void Devices_List_View_ItemTapped(object sender, ItemTappedEventArgs e)
    {
        _device= (DevicesModel)e.Item; 
        await Navigation.PushAsync(new DevicePageView(_device));
    }
    public async void Settings()
    {
        await Navigation.PushAsync(new AddDeviceView());
    }
}