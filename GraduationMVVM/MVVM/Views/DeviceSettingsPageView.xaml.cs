using GraduationMVVM.MVVM.ViewModels;

namespace GraduationMVVM.MVVM.Views;

public partial class DeviceSettingsPageView : ContentPage
{

    private DeviceSettingsPageViewModel viewModel;
    private Models.SelectedDevice _device;
    public DeviceSettingsPageView(Models.SelectedDevice device)
    {
        InitializeComponent();

        _device = device;
        App.Pages.DeviceSettingsPage = this;
        viewModel = new DeviceSettingsPageViewModel();

        BindingContext = viewModel;
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();

        viewModel.RefreshWidgets();
    }
    public void Update()
    {
        if (Entry_Token.Text != null)
        {
            viewModel.DevicetoBind.Token = Entry_Token.Text;
        }
        else
        {
            DisplayAlert("Warning", "Please Select A Server", "Ok");
        }

        if (pickerServer.SelectedItem == null)
        {
            DisplayAlert("Warning", "Please Select A Server", "Ok");
        }
        else
        {
            viewModel.DevicetoBind.Server = "https://" + pickerServer.SelectedItem.ToString() + "/";
        }

        if (Entry_Name.Text != null)
        {
            viewModel.DevicetoBind.Name = Entry_Name.Text;
        }
        else
        {
            DisplayAlert("Warning", "Please Write a Name", "Ok");
        }


    }
}