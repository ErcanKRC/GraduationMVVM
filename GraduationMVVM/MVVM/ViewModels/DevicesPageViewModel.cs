
using CommunityToolkit.Mvvm.Input;
using GraduationMVVM.MVVM.Views;
using PropertyChanged;
using System.ComponentModel;

namespace GraduationMVVM.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public partial class DevicesPageViewModel : INotifyPropertyChanged
    {
        public DevicesPageViewModel()
        {

        }

        [RelayCommand]
        public void Refresh()
        {
            App.Pages.DevicesPage.Refresh();
        }

        [RelayCommand]
        public void Delete(int ID)
        {
            App.DevicesRepository.DeleteIDItem((int)ID);
            App.Pages.DevicesPage.Refresh();
        }
        [RelayCommand]
        public async void Settings()
        {
            await Shell.Current.Navigation.PushAsync(new AddDeviceView());
        }

        public async Task ToDevicePage()
        {
            await Shell.Current.Navigation.PushAsync(new DevicePageView());
        }
    }
}
