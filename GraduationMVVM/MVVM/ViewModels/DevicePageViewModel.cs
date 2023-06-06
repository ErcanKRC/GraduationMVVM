using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GraduationMVVM.MVVM.Models;
using GraduationMVVM.MVVM.Views;
using GraduationMVVM.Services;
using PropertyChanged;
using System.Timers;

namespace GraduationMVVM.MVVM.ViewModels
{

    [AddINotifyPropertyChangedInterface]
    public partial class DevicePageViewModel : ObservableObject
    {
        public SelectedDevice DevicetoBind { get; set; }
        public bool isActive { get; set; }

        /*
        public List<ButtonModel> Buttons { get; set; }
        public List<SwitchModel> Switches { get; set; }
        public List<GaugeModel> Gauges { get; set; }
        public List<SliderModel> Sliders { get; set; }*/

        
        public DevicePageViewModel()
        {
            try
            {
                BlynkService.Instance.SetBaseAddress(App.SelectedDevice.Server);

                DevicetoBind = App.SelectedDevice;

                SetTimers();
                GaugeValueTimer.Start();
            }
            catch (Exception ex)
            {

            }
        }

        [RelayCommand]
        public async void Settings()
        {
            await Shell.Current.Navigation.PushAsync(new DeviceSettingsPageView(DevicetoBind));
        }
        public async Task isActiveRequest()
        {
            isActive = await BlynkService.Instance.GetDeviceStatus(App.SelectedDevice);
        }


        [RelayCommand]
        public async void onSwitchToggle(int SwitchId)
        {
            SwitchModel ToggledSwitch = App.SwitchRepository.Get(SwitchId - 1);


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
            ButtonModel button = App.ButtonRepository.Get(buttonid - 1);
            await BlynkService.Instance.UpdateDatastreamValue(DevicetoBind, button.StreamId, button.Value0);
        }


        private System.Timers.Timer GaugeValueTimer = new System.Timers.Timer(2000);
        private void SetTimers()
        {
            GaugeValueTimer.Elapsed += OnTimedEvent;
        }
        private async void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            if (DevicetoBind.Gauges.Count > 0)
                foreach (GaugeModel Gauge in App.SelectedDevice.Gauges)
                {

                    var result = await BlynkService.Instance.GetDataStreamValue(DevicetoBind, Gauge.StreamId);

                    MainThread.BeginInvokeOnMainThread(() =>
                    {
                        Gauge.Value = Convert.ToInt16(result);
                        App.GaugeRepository.AddorUpdateItem(Gauge);
                        App.Pages.DevicePage.RefreshGauges();
                       // App.Pages.DevicePage.GaugeAnimate();
                    });
                }
        }
        [RelayCommand]
        public void ButtonSettings(int buttonId)
        {
            ButtonModel button = App.ButtonRepository.Get(buttonId - 1);

        }
        [RelayCommand]
        public void SwitchSettings(int switchId)
        {
            SwitchModel switchtoChange = App.SwitchRepository.Get(switchId - 1);

        }
        [RelayCommand]
        public void SliderSettings(int Id)
        {

        }
        [RelayCommand]
        public void GaugeSettings(int Id)
        {

        }

    }

}
