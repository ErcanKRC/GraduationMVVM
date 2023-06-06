namespace GraduationMVVM.MVVM.Views;

using GraduationMVVM.MVVM.Models;
using GraduationMVVM.MVVM.ViewModels;
using Microsoft.Maui.Controls;
using System.Collections.Generic;

public partial class DevicePageView : ContentPage
{
    private DevicePageViewModel viewModel = new DevicePageViewModel();

    public DevicePageView()
    {
        InitializeComponent();
        App.Pages.DevicePage = this;
        BindingContext = viewModel;
    }

    protected async override void OnAppearing()
    {
        base.OnAppearing();
        await viewModel.isActiveRequest();

        if (!App.ButtonRepository.isEmpty())
            ButtonList.ItemsSource = App.ButtonRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id);
        if (!App.SwitchRepository.isEmpty())
            SwitchList.ItemsSource = App.SwitchRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id);
        if (!App.GaugeRepository.isEmpty())
            GaugeList.ItemsSource = App.GaugeRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id);
        if (!App.SliderRepository.isEmpty())
            SliderList.ItemsSource = App.SliderRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id);

    }

    public void RefreshGauges()
    {
        if (!App.GaugeRepository.isEmpty())
            GaugeList.ItemsSource = App.GaugeRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id);
    }

    public void SliderAnimate(int id, int value)
    {
        SliderModel slider = App.SliderRepository.Get(id - 1);
        slider.Value = value;

        
    }
    public void GaugeAnimate(int id, int value)
    {
        GaugeModel gauge = App.GaugeRepository.Get(id - 1);
        gauge.Value = value;


    }
}