namespace GraduationMVVM.MVVM.Views;

using Android.App;
using GraduationMVVM.MVVM.Models;
using GraduationMVVM.MVVM.ViewModels;
using Java.Net;
using Microsoft.Maui.Controls;
using Xamarin.Google.Crypto.Tink.Shaded.Protobuf;
using static Android.Bluetooth.BluetoothClass;

public partial class DevicePageView : ContentPage
{
    private DevicePageViewModel viewModel;
    private DevicesModel _device;

    private HttpClient client = new HttpClient();
    private HttpResponseMessage response= new HttpResponseMessage();

    public DevicePageView(DevicesModel device)
    {
        InitializeComponent();
        _device = device;

        viewModel = new DevicePageViewModel(this,_device);
        viewModel.Name = _device.Name;
        viewModel.Server = _device.Server;
        viewModel.Token= _device.Token;
        isActiveRequest();

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
    public async void AddSpecs()
    {
        await Navigation.PushAsync(new DeviceSpecsView());
    }
    public async void isActiveRequest()
    {
        try
        {
            client.BaseAddress = new Uri(_device.Server);
            response = await client.GetAsync("external/api/isHardwareConnected?token=" + _device.Token);
        }
        catch(Exception ex)
        {
           await DisplayAlert(Title,"Please Check Server Address","OK");
        }
        
        if(response.IsSuccessStatusCode)
        {
            string result = await response.Content.ReadAsStringAsync();
            if(result == "true")
            {
                viewModel.isActive = true;
            }
            else
            {
                viewModel.isActive = false;
            }
        }
        else
        {
            viewModel.isActive = false;
        }
    }
}