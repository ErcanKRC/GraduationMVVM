
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GraduationMVVM.MVVM.Models;
using GraduationMVVM.MVVM.Views;
using PropertyChanged;

namespace GraduationMVVM.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public partial class DeviceSettingsPageViewModel : ObservableObject
    {

        public SelectedDevice DevicetoBind { get; set; }
        public int ButtonCount { get; set; }
        public int SwitchCount { get; set; }
        public int GaugeCount { get; set; }
        public int TrackBarCount { get; set; }
        public DeviceSettingsPageViewModel()
        {
            RefreshWidgets();
            DevicetoBind = App.SelectedDevice;
        }

        [RelayCommand]
        public void Update()
        {
            App.Pages.DeviceSettingsPage.Update();

            if (DevicetoBind.Name != null && DevicetoBind.Server != null && DevicetoBind.Token != null && DevicetoBind.Id != 0)
            {
                App.DevicesRepository.AddorUpdateItem(new Models.DevicesModel
                {
                    Id = DevicetoBind.Id,
                    Name = DevicetoBind.Name,
                    Server = DevicetoBind.Server,
                    Token = DevicetoBind.Token
                });

            }
        }

        [RelayCommand]
        public async Task WidgetPage()
        {
            await Shell.Current.Navigation.PushAsync(new AddWidgetPage());
        }

        public void RefreshWidgets()
        {
            App.SelectedDevice.Buttons = App.ButtonRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id);
            App.SelectedDevice.Gauges = App.GaugeRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id);
            App.SelectedDevice.Switchs = App.SwitchRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id);
            App.SelectedDevice.TrackBars = App.SliderRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id);


            if (App.SelectedDevice.Buttons != null)
                ButtonCount = App.SelectedDevice.Buttons.Count;
            else ButtonCount = 0;
            if (App.SelectedDevice.Switchs != null)
                SwitchCount = App.SelectedDevice.Switchs.Count;
            else SwitchCount = 0;
            if (App.SelectedDevice.Gauges != null)
                GaugeCount = App.SelectedDevice.Gauges.Count;
            else GaugeCount = 0;
            if (App.SelectedDevice.TrackBars != null)
                TrackBarCount = App.SelectedDevice.TrackBars.Count;
            else TrackBarCount = 0;
        }

    }
}
