
using CommunityToolkit.Mvvm.Input;
using GraduationMVVM.MVVM.Models;
using GraduationMVVM.MVVM.Views;
using PropertyChanged;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace GraduationMVVM.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public partial class DevicesPageViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<DevicesModel> DevicestoList { get; set; }
        public DevicesPageViewModel()
        {
            if (!App.DevicesRepository.IsEmpty())
                DevicestoList = new ObservableCollection<DevicesModel>(App.DevicesRepository.GetAll());
        }

        [RelayCommand]
        public async void Settings()
        {
            await Shell.Current.Navigation.PushAsync(new AddDeviceView());
        }

    }
}
