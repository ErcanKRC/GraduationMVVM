using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PropertyChanged;

namespace GraduationMVVM.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public partial class AddDeviceViewModel : ObservableObject
    {
        public static string DeviceServer { get; set; }
        public static string DeviceName { get; set; }
        public static string DeviceToken { get; set; }

        public static bool isSaved = false;

        public AddDeviceViewModel()
        {

        }

        [RelayCommand]
        void Insert()
        {
            App.Pages.AddDevicePage.Insertdevice();

            if (DeviceName != null && DeviceServer != null && DeviceToken != null)
            {
                App.DevicesRepository.AddorUpdateItem(new Models.DevicesModel
                {
                    Name = DeviceName,
                    Server = DeviceServer,
                    Token = DeviceToken
                });

                isSaved = true;
            }
            else
            {
                isSaved = false;
            }

            App.Pages.AddDevicePage.InsertCheck(isSaved);
        }
    }
}
