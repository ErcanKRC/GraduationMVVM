using GraduationMVVM.MVVM.Models;
using GraduationMVVM.MVVM.ViewModels;
using System.Collections.ObjectModel;

namespace GraduationMVVM.MVVM.Views;

public partial class SDWidgetsListView : ContentPage
{
    public SDWidgetsListViewModel viewModel = new SDWidgetsListViewModel();
    public SDWidgetsListView()
    {
        InitializeComponent();

        App.Pages.WidgetsListView = this;

        BindingContext = viewModel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
    }

    private async void ButtonListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var Button = (ButtonModel)e.SelectedItem;
        ButtonModel buttontoChange = App.ButtonRepository.Get(x => x.Id == Button.Id);
        await Shell.Current.Navigation.PushAsync(new WidgetSettingsView(buttontoChange));
    }

    private async void SwitchList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var Switch = (SwitchModel)e.SelectedItem;
        SwitchModel switchtoChange = App.SwitchRepository.Get(x => x.Id == Switch.Id);
        await Shell.Current.Navigation.PushAsync(new WidgetSettingsView(switchtoChange));
    }

    private async void GaugeList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var Gauge = (GaugeModel)e.SelectedItem;
        GaugeModel gaugetoChange = App.GaugeRepository.Get(x => x.Id == Gauge.Id);
        await Shell.Current.Navigation.PushAsync(new WidgetSettingsView(gaugetoChange));
    }

    private async void SliderList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        var Slider = (SliderModel)e.SelectedItem;
        SliderModel slidertoChange = App.SliderRepository.Get(x => x.Id == Slider.Id);
        await Shell.Current.Navigation.PushAsync(new WidgetSettingsView(slidertoChange));
    }
}