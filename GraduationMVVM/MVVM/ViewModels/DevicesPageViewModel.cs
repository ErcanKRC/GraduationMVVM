
using CommunityToolkit.Mvvm.Input;
using GraduationMVVM.MVVM.Models;
using GraduationMVVM.MVVM.Views;
using PropertyChanged;
using System.ComponentModel;

namespace GraduationMVVM.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public partial class DevicesPageViewModel : INotifyPropertyChanged
    {

        private readonly DevicesPageView _parent;
        public DevicesPageViewModel(DevicesPageView parent)
        {
            _parent= parent;
        }

        [RelayCommand]
        public void Refresh()
        {
            _parent.Refresh();  
        }

        [RelayCommand]
        public void Delete(int ID)
        {
            App.DevicesRepository.DeleteIDItem((int)ID);
            _parent.Refresh();
        }
        [RelayCommand]
        public void Settings()
        {
            _parent.Settings();
        }
    }
}
