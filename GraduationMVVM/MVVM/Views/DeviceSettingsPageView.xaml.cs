using GraduationMVVM.MVVM.Models;
using GraduationMVVM.MVVM.ViewModels;
using Microsoft.Maui.Controls;

namespace GraduationMVVM.MVVM.Views;

public partial class DeviceSettingsPageView : ContentPage
{

    private DeviceSettingsPageViewModel viewModel;
    private DevicesModel _device;
    public DeviceSettingsPageView(DevicesModel device)
	{
		InitializeComponent();
        
        _device = device;
        viewModel = new DeviceSettingsPageViewModel(this , _device);

        BindingContext = viewModel;

        Entry_Name.Text = _device.Name;
        Entry_Token.Text = _device.Token;
        pickerServer.SelectedItem = _device.Server; 
    }

    public void Update()
    {
        if (Entry_Token.Text != null)
        {
            DeviceSettingsPageViewModel.DeviceToken = Entry_Token.Text;
        }
        
        if (pickerServer.SelectedItem == null)
        {
            DisplayAlert("Warning", "Please Select A Server", "Ok");
        }
        else
        {
            DeviceSettingsPageViewModel.DeviceServer ="https://" + pickerServer.SelectedItem.ToString() + "/";
        }

        if (Entry_Name.Text != null)
        {
            DeviceSettingsPageViewModel.DeviceName = Entry_Name.Text;
        }
        else
        {
            DisplayAlert("Warning", "Please Write a Name", "Ok");
        }


    }
}