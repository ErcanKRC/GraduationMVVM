using GraduationMVVM.MVVM.ViewModels;

namespace GraduationMVVM.MVVM.Views;

public partial class DeviceSettingsPageView : ContentPage
{

    private DeviceSettingsPageViewModel viewModel;
    public DeviceSettingsPageView()
    {
        InitializeComponent();

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
            viewModel.DevicetoBind.Server = pickerServer.SelectedItem.ToString();
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