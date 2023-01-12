using GraduationMVVM.MVVM.Models;
using GraduationMVVM.MVVM.ViewModels;

namespace GraduationMVVM.MVVM.Views;

public partial class AddDeviceView : ContentPage
{

    string server = "https://fra1.blynk.cloud/";
    string token = "o2PXXZIDPZLNGCK5HhSL02auSlXtNxio";
    public AddDeviceView()
    {
        InitializeComponent();
        BindingContext = new AddDeviceViewModel(this);

    }

    //private void EntrySave_Clicked(object sender, EventArgs e)
    //{
    //    AddDeviceViewModel.DeviceName = Entry_Name.Text;
    //    AddDeviceViewModel.DeviceToken = Entry_Token.Text;
    //    AddDeviceViewModel.DeviceServer = pickerServer.SelectedItem.ToString();
    //}

    public void Insertdevice()
    {
        if (Entry_Token.Text != null)
        {
            token = Entry_Token.Text ;
        }
        if (server == "Please Select a Server")
        {
            DisplayAlert("Warning", "Please Select A Server", "Ok");
        }
        else
        {
            server = "https://" + server + "/";
        }

        App.DevicesRepository.AddItem(new Models.DevicesModel
        {
            Name = Entry_Name.Text,
            Server = server,
            Token = token
        });

        
    }
}