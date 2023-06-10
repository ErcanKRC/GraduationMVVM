using GraduationMVVM.MVVM.ViewModels;


namespace GraduationMVVM.MVVM.Views;

public partial class AddDeviceView : ContentPage
{

    string server = "https://fra1.blynk.cloud/";
    string token = "o2PXXZIDPZLNGCK5HhSL02auSlXtNxio";
    public AddDeviceView()
    {
        InitializeComponent();
        App.Pages.AddDevicePage = this;
        BindingContext = new AddDeviceViewModel();

    }

    public void Insertdevice()
    {
        if (Entry_Token.Text != null && Entry_Token.Text != "")
        {
            AddDeviceViewModel.DeviceToken = Entry_Token.Text;
        }
        else
        {
            AddDeviceViewModel.DeviceToken = token;
        }

        if (server == "Please Select a Server")
        {
            DisplayAlert("Warning", "Please Select A Server", "Ok");
        }
        else if (pickerServer.SelectedItem == null)
        {

            DisplayAlert("Warning", "Please Select A Server", "Ok");
        }
        else
        {
            AddDeviceViewModel.DeviceServer = pickerServer.SelectedItem.ToString();
        }

        if (Entry_Name.Text != null)
        {
            AddDeviceViewModel.DeviceName = Entry_Name.Text;
        }
        else
        {
            DisplayAlert("Warning", "Please Write a Name", "Ok");
        }

    }

}