using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GraduationMVVM.MVVM.Models;
using GraduationMVVM.MVVM.Views;
using GraduationMVVM.Services;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Timers;

namespace GraduationMVVM.MVVM.ViewModels
{

    [AddINotifyPropertyChangedInterface]
    public partial class DevicePageViewModel : ObservableObject
    {
        public SelectedDevice DevicetoBind { get; set; }
        public bool IsActive { get; set; }
        public DevicePageViewModel()
        {
            DevicetoBind = App.SelectedDevice;

            try
            {
                BlynkService.Instance.SetBaseAddress(App.SelectedDevice.Server);

                SetTimers();
                GaugeValueTimer.Start();
                SwitchValueTimer.Start();
                SliderValueTimer.Start();
                isActiveTimer.Start();
            }
            catch (Exception _)
            {

            }
        }

        [RelayCommand]
        public static async void DeviceSettings()
        {
            await Shell.Current.Navigation.PushAsync(new DeviceSettingsPageView());
        }
        public async Task IsActiveRequest()
        {
            isActiveTimer.Stop();
                    try
                    {
                        var result = await BlynkService.Instance.GetDeviceStatus(App.SelectedDevice);
                        if(result)
                        IsActive = true;
                        else
                        IsActive = false;
                    }
                    catch (Exception ex)
                    {
                        isActiveTimer.Start();
                        return;
                    }
            isActiveTimer.Start();
        }

        [RelayCommand]
        public async void OnSwitchToggle(int SwitchId)
        {
            SwitchModel ToggledSwitch = App.SwitchRepository.Get(x => x.Id == SwitchId);


            if (ToggledSwitch.IsEnabled == true)
            {
                await BlynkService.Instance.UpdateDatastreamValue(DevicetoBind, ToggledSwitch.StreamId, ToggledSwitch.Value0);

                ToggledSwitch.IsEnabled = false;
                App.SwitchRepository.AddorUpdateItem(ToggledSwitch);
            }
            else
            {
                await BlynkService.Instance.UpdateDatastreamValue(DevicetoBind, ToggledSwitch.StreamId, ToggledSwitch.Value1);

                ToggledSwitch.IsEnabled = true;
                App.SwitchRepository.AddorUpdateItem(ToggledSwitch);
            }
        }


        [RelayCommand]
        public async Task ButtonClicked(int buttonid)
        {
            ButtonModel button = App.ButtonRepository.Get(x => x.Id == buttonid);
            await BlynkService.Instance.UpdateDatastreamValue(DevicetoBind, button.StreamId, button.Value0);
        }


        private readonly System.Timers.Timer GaugeValueTimer = new System.Timers.Timer(100);
        private readonly System.Timers.Timer SliderValueTimer = new System.Timers.Timer(500);
        private readonly System.Timers.Timer SwitchValueTimer = new System.Timers.Timer(3000);
        private readonly System.Timers.Timer isActiveTimer = new System.Timers.Timer(5000);

        private void SetTimers()
        {
            GaugeValueTimer.Elapsed += GaugeValueOnTimedEvent;
            SliderValueTimer.Elapsed += SliderValueOnTimed;
            SwitchValueTimer.Elapsed += SwitchValueOnTimed;
            isActiveTimer.Elapsed += IsActiveTimer_Elapsed;
        }

        private async void IsActiveTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            await IsActiveRequest();
        }

        private async void SliderValueOnTimed(object sender, ElapsedEventArgs e)
        {
            SliderValueTimer.Stop();
            var slidercount = DevicetoBind.Sliders.Count;
            if (slidercount > 0)
            {
                foreach (var Slider in DevicetoBind.Sliders)
                {
                    try
                    {
                        var result = await BlynkService.Instance.GetDataStreamValue(App.SelectedDevice, Slider.StreamId);
                        var SliderValue = Convert.ToInt16(result);
                        if (SliderValue != Slider.Value)
                        {
                            Slider.Value = SliderValue;
                        }
                    }
                    catch (Exception ex)
                    {
                        SliderValueTimer.Start();
                        return;
                    }
                }
            }
            SliderValueTimer.Start();
        }

        private async void SwitchValueOnTimed(object sender, ElapsedEventArgs e)
        {
            SwitchValueTimer.Stop();
            var switchcount = App.SelectedDevice.Switchs.Count;
            if (switchcount > 0)
            {
                foreach (var Switchtochek in DevicetoBind.Switchs)
                {
                    try
                    {
                        var result = await BlynkService.Instance.GetDataStreamValue(App.SelectedDevice, Switchtochek.StreamId);
                        var SwitchValue = Convert.ToInt16(result);
                        if (SwitchValue == 1 && Switchtochek.IsEnabled == false)
                        {
                            Switchtochek.IsEnabled = true;
                        }
                        else if(Switchtochek.IsEnabled && SwitchValue == 0) 
                        { 
                            Switchtochek.IsEnabled = false;
                        }
                    }
                    catch (Exception ex)
                    {
                        SwitchValueTimer.Start();
                        return;
                    }
                }
            }
            SwitchValueTimer.Start();
        }

        private async void GaugeValueOnTimedEvent(Object source, ElapsedEventArgs e)
        {
            GaugeValueTimer.Stop();

            var count = App.SelectedDevice.Gauges.Count;
            if (count > 0)
            {
                for (int i = 0; i <= count - 1; i++)
                {
                    try
                    {
                        var Gauge = App.SelectedDevice.Gauges[i];
                        var result = await BlynkService.Instance.GetDataStreamValue(App.SelectedDevice, Gauge.StreamId);
                        var Value = Convert.ToInt16(result);
                        if (Value != Gauge.Value)
                        {
                            Gauge.Value = Value;
                        }
                    }
                    catch (Exception ex)
                    {
                        GaugeValueTimer.Start();
                        return;
                    }
                }
            }
            GaugeValueTimer.Start();
        }
        [RelayCommand]
        public async void SliderValueChanged(int SliderId)
        {
            var slider = DevicetoBind.Sliders.FirstOrDefault(x => x.Id == SliderId);
            await BlynkService.Instance.UpdateDatastreamValue(DevicetoBind, slider.StreamId, slider.Value);
            App.SliderRepository.AddorUpdateItem(slider);
        }



    }

}
