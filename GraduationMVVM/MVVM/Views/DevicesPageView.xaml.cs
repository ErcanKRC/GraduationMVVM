using GraduationMVVM.MVVM.Models;
using GraduationMVVM.MVVM.ViewModels;

namespace GraduationMVVM.MVVM.Views;

public partial class DevicesPageView : ContentPage
{
    DevicesPageViewModel viewModel;
    public DevicesPageView()
    {
        InitializeComponent();
        App.Pages.DevicesPage = this;
        viewModel = new DevicesPageViewModel();
        BindingContext = viewModel;

    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        if (!App.DevicesRepository.isEmpty())
            Devices_List_View.ItemsSource = App.DevicesRepository.GetAll();
    }
    public void Refresh()
    {
        Devices_List_View.ItemsSource = App.DevicesRepository.GetAll();
    }

    private async void Devices_List_View_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var _device = (DevicesModel)e.SelectedItem;
        App.SelectedDevice.Name = _device.Name;
        App.SelectedDevice.Id = _device.Id;
        App.SelectedDevice.Token = _device.Token;
        App.SelectedDevice.Server = _device.Server;
        App.SelectedDevice.Buttons = App.ButtonRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id);
        App.SelectedDevice.Switchs = App.SwitchRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id);
        App.SelectedDevice.Gauges = App.GaugeRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id);
        App.SelectedDevice.TrackBars= App.SliderRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id);
        await viewModel.ToDevicePage();

    }
}