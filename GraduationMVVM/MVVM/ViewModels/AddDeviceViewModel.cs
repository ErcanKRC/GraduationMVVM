using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GraduationMVVM.MVVM.Views;
using PropertyChanged;

namespace GraduationMVVM.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public partial class AddDeviceViewModel : ObservableObject
    {
        public static string DeviceServer { get; set; }
        public static string DeviceName { get; set; }
        public static string DeviceToken { get; set; }

        public readonly AddDeviceView _parent;
        public AddDeviceViewModel(AddDeviceView parent) 
        {
            _parent = parent;
        }

        [RelayCommand]
        void Insert()
        {
            _parent.Insertdevice();
        }
    }
}
