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

    public void Insertdevice()
    {
        if (Entry_Token.Text != null)
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
            server = "https://" + pickerServer.SelectedItem.ToString() + "/";
            AddDeviceViewModel.DeviceServer = server;
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
    async public void InsertCheck(bool isSaved)
    {
        if (isSaved)
        {
            bool state = await DisplayAlert("Success", "Device Added", "OK", "Add More");
            AddDeviceViewModel.isSaved = false;
            if (state)
            OnSuccesfulInsert();
        }
        else
        {
            await DisplayAlert("Fail", "Device not Added", "OK");
        }
    }

    public async void OnSuccesfulInsert()
    {
        await Navigation.PopToRootAsync();
    }
}