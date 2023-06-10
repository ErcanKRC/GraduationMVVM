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
    public partial class SDWidgetsListViewModel:ObservableObject
    {
        public SelectedDevice DevicetoBind { get; set; }

        public SDWidgetsListViewModel()
        {
            DevicetoBind = App.SelectedDevice;
        }


    }
}
