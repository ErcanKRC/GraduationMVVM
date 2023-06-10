
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GraduationMVVM.MVVM.Models;
using GraduationMVVM.MVVM.Views;
using PropertyChanged;
using System.Collections.ObjectModel;

namespace GraduationMVVM.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public partial class DeviceSettingsPageViewModel : ObservableObject
    {

        public SelectedDevice DevicetoBind { get; set; }
        public int ButtonCount { get; set; }
        public int SwitchCount { get; set; }
        public int GaugeCount { get; set; }
        public int SliderCount { get; set; }

        private static bool isSaved = false;
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
                isSaved = true;
                App.SelectedDevice = DevicetoBind;
            }
            else
            {
                isSaved = false;
            }
            UpdateCheck(isSaved);
        }

        [RelayCommand]
        public static async Task WidgetPage()
        {
            await Shell.Current.Navigation.PushAsync(new AddWidgetPage());
        }

        public void RefreshWidgets()
        {
            App.SelectedDevice.Buttons = new ObservableCollection<ButtonModel>(App.ButtonRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id));
            App.SelectedDevice.Gauges = new ObservableCollection<GaugeModel>(App.GaugeRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id));
            App.SelectedDevice.Switchs = new ObservableCollection<SwitchModel>(App.SwitchRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id));
            App.SelectedDevice.Sliders = new ObservableCollection<SliderModel>(App.SliderRepository.GetList(x => x.DeviceId == App.SelectedDevice.Id));


            if (App.SelectedDevice.Buttons != null)
                ButtonCount = App.SelectedDevice.Buttons.Count;
            else ButtonCount = 0;
            if (App.SelectedDevice.Switchs != null)
                SwitchCount = App.SelectedDevice.Switchs.Count;
            else SwitchCount = 0;
            if (App.SelectedDevice.Gauges != null)
                GaugeCount = App.SelectedDevice.Gauges.Count;
            else GaugeCount = 0;
            if (App.SelectedDevice.Sliders != null)
                SliderCount = App.SelectedDevice.Sliders.Count;
            else SliderCount = 0;
        }
        public async void UpdateCheck(bool isSaved)
        {
            if (isSaved)
            {
                bool state = await Shell.Current.DisplayAlert("Success", "Device Updated", "OK", "Add Widgets");
                isSaved = false;
                if (state)
                {
                    App.SelectedDevice = DevicetoBind;
                    App.Pages.DevicePage.viewModel.DevicetoBind = App.SelectedDevice;
                    await Shell.Current.Navigation.PopAsync();
                }

            }
            else
            {
                await Shell.Current.DisplayAlert("Fail", "Device not Updated, Please check variables and try again", "OK");
            }
        }

        [RelayCommand]
        public async void DeleteDevice(int deviceId)
        {

            bool confirm = await Shell.Current.DisplayAlert("Device Deleting!", "Are you sure to delete this Device?", "Yes", "Cancel");
            if (confirm)
            {
                if (ButtonCount > 0)
                {
                    foreach (var button in DevicetoBind.Buttons)
                    {
                        App.ButtonRepository.DeleteItem(button);
                    }
                }
                if (SwitchCount > 0)
                {
                    foreach (var Switch in DevicetoBind.Switchs)
                    {
                        App.SwitchRepository.DeleteItem(Switch);
                    }
                }
                if (GaugeCount > 0)
                {
                    foreach (var Gauge in DevicetoBind.Gauges)
                    {
                        App.GaugeRepository.DeleteItem(Gauge);
                    }
                }
                if (SliderCount > 0)
                {
                    foreach (var Slider in DevicetoBind.Sliders)
                    {
                        App.SliderRepository.DeleteItem(Slider);
                    }
                }

                App.DevicesRepository.DeleteIDItem((int)deviceId);

                await Shell.Current.DisplayAlert("Success!", "Device deleted.", "OK");

                await Shell.Current.Navigation.PopToRootAsync();
            }
            else return;

        }

        [RelayCommand]
        public async void WidgetListPage()
        {
            await Shell.Current.Navigation.PushAsync(new SDWidgetsListView());
        }

    }
}
