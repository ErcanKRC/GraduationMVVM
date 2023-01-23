
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GraduationMVVM.MVVM.Models;
using GraduationMVVM.MVVM.Views;
using PropertyChanged;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationMVVM.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public partial class DeviceSettingsPageViewModel : ObservableObject
    {

        public DeviceSettingsPageView _parent;
        public DevicesModel _device;
        public static string DeviceName { get; set; }
        public static string DeviceServer { get; set; }
        public static string DeviceToken { get; set; }

        public DeviceSettingsPageViewModel(DeviceSettingsPageView parent, DevicesModel device)
        {
            _parent = parent;
            _device = device;
        }

        [RelayCommand]
        public void Update( )
        {
            _parent.Update( );

            if (DeviceName != null && DeviceServer != null && DeviceToken != null && _device.ID != 0 )
            {
                App.DevicesRepository.AddorUpdateItem(new Models.DevicesModel
                {
                    ID = _device.ID,
                    Name = DeviceName,
                    Server = DeviceServer,
                    Token = DeviceToken
                });

            }
        }

    }
}
