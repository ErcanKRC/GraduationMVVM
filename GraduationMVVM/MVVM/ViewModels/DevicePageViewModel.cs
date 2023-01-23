using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GraduationMVVM.MVVM.Models;
using GraduationMVVM.MVVM.Views;
using PropertyChanged;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationMVVM.MVVM.ViewModels
{

    [AddINotifyPropertyChangedInterface]
    public partial class DevicePageViewModel : ObservableObject
    {

        private readonly DevicePageView _parent;
        private DevicesModel _device;
        public string Name { get; set; } 
        public string Server { get; set; }
        public string Token { get; set; }


        public DevicePageViewModel(DevicePageView parent,DevicesModel device)
        {
            _parent = parent;
            _device = device;
        }

        [RelayCommand]
        public void Settings()
        {
            _parent.Settings();
        }

    }
}
