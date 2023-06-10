using GraduationMVVM.MVVM.Models;
using GraduationMVVM.MVVM.ViewModels;

namespace GraduationMVVM.MVVM.Views;

public partial class WidgetSettingsView : ContentPage
{
    WidgetSettingsViewModel viewModel;
    public WidgetSettingsView(ButtonModel buttontoChange)
    {
        InitializeComponent();
        App.Pages.WidgetSettingsPage = this;
        viewModel = new WidgetSettingsViewModel(buttontoChange);
        BindingContext = viewModel;
    }
    public WidgetSettingsView(SwitchModel switchtoChange)
    {
        InitializeComponent();

        viewModel = new WidgetSettingsViewModel(switchtoChange);
        BindingContext = viewModel;

    }
    public WidgetSettingsView(GaugeModel gaugetoChange)
    {
        InitializeComponent();

        viewModel = new WidgetSettingsViewModel(gaugetoChange);
        BindingContext = viewModel;

    }
    public WidgetSettingsView(SliderModel slidertoChange)
    {
        InitializeComponent();

        viewModel = new WidgetSettingsViewModel(slidertoChange);
        BindingContext = viewModel;

    }

}