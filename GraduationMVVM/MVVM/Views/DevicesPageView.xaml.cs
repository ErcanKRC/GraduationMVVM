using GraduationMVVM.MVVM.Models;
using GraduationMVVM.MVVM.ViewModels;
using Microsoft.Maui.Controls;

namespace GraduationMVVM.MVVM.Views;

public partial class DevicesPageView : ContentPage
{
    public DevicesPageView()
    {
        InitializeComponent();

        BindingContext = new DevicesPageViewModel(this);
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        Devices_List_View.ItemsSource = App.DevicesRepository.GetAll();
        //ContentView_Devices.ItemsSource = App.DevicesRepository.GetAll();
    }
    public void Refresh()
    {
        Devices_List_View.ItemsSource = App.DevicesRepository.GetAll();
        //ContentView_Devices.ItemsSource = App.DevicesRepository.GetAll();
    }

}