using GraduationMVVM.Abstract;
using GraduationMVVM.MVVM.Models;

namespace GraduationMVVM;

public partial class App : Application
{
    public static BaseRepository<DevicesModel> DevicesRepository { get; set; }
    public App(BaseRepository<DevicesModel> devicerepo)
    {
        InitializeComponent();

        MainPage = new AppShell();

        DevicesRepository = devicerepo;
    }
}
