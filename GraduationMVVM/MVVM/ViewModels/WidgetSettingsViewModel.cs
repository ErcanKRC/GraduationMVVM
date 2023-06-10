using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GraduationMVVM.MVVM.Models;
using PropertyChanged;

namespace GraduationMVVM.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public partial class WidgetSettingsViewModel : ObservableObject
    {
        public string WidgetType { get; set; }
        public int DeviceId { get; set; }
        public string WidgetName { get; set; }
        public int StreamId { get; set; }
        public int Value0 { get; set; }
        public int Value1 { get; set; }


        public ButtonModel ButtontoChange { get; set; }
        public SwitchModel SwitchtoChange { get; set; }
        public GaugeModel GaugetoChange { get; set; }
        public SliderModel SlidertoChange { get; set; }
        public WidgetSettingsViewModel(ButtonModel buttontoChange)
        {

            ButtontoChange = buttontoChange;

            WidgetType = "Button";
            DeviceId = buttontoChange.DeviceId;
            WidgetName = buttontoChange.ButName;
            StreamId = buttontoChange.StreamId;
            Value0 = buttontoChange.Value0;
            Value1 = buttontoChange.Value1;
        }
        public WidgetSettingsViewModel(SwitchModel switchtoChange)
        {
            SwitchtoChange = switchtoChange;

            WidgetType = "Switch";
            DeviceId = switchtoChange.DeviceId;
            WidgetName = switchtoChange.SwName;
            StreamId = switchtoChange.StreamId;
            Value0 = switchtoChange.Value0;
            Value1 = switchtoChange.Value1;
        }
        public WidgetSettingsViewModel(GaugeModel gaugetoChange)
        {
            GaugetoChange = gaugetoChange;

            WidgetType = "Gauge";
            DeviceId = gaugetoChange.DeviceId;
            WidgetName = gaugetoChange.GaugeName;
            StreamId = gaugetoChange.StreamId;
            Value0 = gaugetoChange.Value0;
            Value1 = gaugetoChange.Value1;
        }
        public WidgetSettingsViewModel(SliderModel slidertoChange)
        {
            SlidertoChange = slidertoChange;

            WidgetType = "Slider";
            DeviceId = slidertoChange.DeviceId;
            WidgetName = slidertoChange.SliderName;
            StreamId = slidertoChange.StreamId;
            Value0 = slidertoChange.Value0;
            Value1 = slidertoChange.Value1;
        }

        [RelayCommand]
        public void UpdateWidget()
        {
            if (WidgetType != null && WidgetType != "" && WidgetType != "Type of Widget")
            {
                switch (WidgetType)
                {
                    case "Button":
                        bool isSaved;
                        if (WidgetName != null && WidgetName != "" && WidgetName != "Name of Widget")
                        {
                            ButtontoChange.ButName = WidgetName;
                            ButtontoChange.StreamId = StreamId;
                            ButtontoChange.Value0 = Value0;
                            ButtontoChange.Value1 = Value1;

                            App.ButtonRepository.AddorUpdateItem(ButtontoChange);
                            isSaved = true;
                            App.SelectedDevice.Buttons = new System.Collections.ObjectModel.ObservableCollection<ButtonModel>(App.ButtonRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id));
                        }
                        else
                        {
                            isSaved = false;
                        }

                        UpdateCheck(isSaved);
                        break;


                    case "Switch":
                        if (WidgetName != null && WidgetName != "" && WidgetName != "Name of Widget")
                        {
                            SwitchtoChange.SwName = WidgetName;
                            SwitchtoChange.StreamId = StreamId;
                            SwitchtoChange.Value0 = Value0;
                            SwitchtoChange.Value1 = Value1;

                            App.SwitchRepository.AddorUpdateItem(SwitchtoChange);
                            isSaved = true;
                            App.SelectedDevice.Switchs = new System.Collections.ObjectModel.ObservableCollection<SwitchModel>(App.SwitchRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id));
                        }
                        else
                        {
                            isSaved = false;
                        }

                        UpdateCheck(isSaved);
                        break;


                    case "Gauge":
                        if (WidgetName != null && WidgetName != "" && WidgetName != "Name of Widget")
                        {
                            GaugetoChange.GaugeName = WidgetName;
                            GaugetoChange.StreamId = StreamId;
                            GaugetoChange.Value0 = Value0;
                            GaugetoChange.Value1 = Value1;

                            App.GaugeRepository.AddorUpdateItem(GaugetoChange);
                            isSaved = true;
                            App.SelectedDevice.Gauges = new System.Collections.ObjectModel.ObservableCollection<GaugeModel>(App.GaugeRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id));
                        }
                        else
                        {
                            isSaved = false;
                        }
                        UpdateCheck(isSaved);
                        break;


                    case "Slider":
                        if (WidgetName != null && WidgetName != "" && WidgetName != "Name of Widget")
                        {
                            SlidertoChange.SliderName = WidgetName;
                            SlidertoChange.StreamId = StreamId;
                            SlidertoChange.Value0 = Value0;
                            SlidertoChange.Value1 = Value1;

                            App.SliderRepository.AddorUpdateItem(SlidertoChange);
                            isSaved = true;
                            App.SelectedDevice.Sliders = new System.Collections.ObjectModel.ObservableCollection<SliderModel>(App.SliderRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id));
                        }
                        else
                        {
                            isSaved = false;
                        }
                        UpdateCheck(isSaved);
                        break;
                }
            }
        }

        public static async void UpdateCheck(bool isSaved)
        {

            if (isSaved)
            {
                bool state = await Shell.Current.DisplayAlert("Success", "Widget Updated", "OK", "Change Widget");
                isSaved = false;
                if (state)
                {
                    await Shell.Current.Navigation.PopAsync();
                }
                else return;
            }
            else
            {
                await Shell.Current.DisplayAlert("Fail", "Device not Updated, Please check variables and try again", "OK");
            }


        }

        [RelayCommand]
        public async void DeleteWidget()
        {
            bool confirm = await Shell.Current.DisplayAlert("Widget Deleting!", "Are you sure to delete this widget?", "Yes", "Cancel");
            if (confirm)
            {
                switch (WidgetType)
                {
                    case "Button":
                        App.ButtonRepository.DeleteItem(ButtontoChange);
                        App.SelectedDevice.Buttons = new System.Collections.ObjectModel.ObservableCollection<ButtonModel>(App.ButtonRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id));
                        break;

                    case "Switch":
                        App.SwitchRepository.DeleteItem(SwitchtoChange);
                        App.SelectedDevice.Switchs = new System.Collections.ObjectModel.ObservableCollection<SwitchModel>(App.SwitchRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id));
                        break;

                    case "Gauge":
                        App.GaugeRepository.DeleteItem(GaugetoChange);
                        App.SelectedDevice.Gauges = new System.Collections.ObjectModel.ObservableCollection<GaugeModel>(App.GaugeRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id));
                        break;

                    case "Slider":
                        App.SliderRepository.DeleteItem(SlidertoChange);
                        App.SelectedDevice.Sliders = new System.Collections.ObjectModel.ObservableCollection<SliderModel>(App.SliderRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id));
                        break;
                }

                await Shell.Current.DisplayAlert("Success!", "Widget deleted.", "OK");
                await Shell.Current.Navigation.PopAsync(true);
            }
            else return;


        }
    }
}
