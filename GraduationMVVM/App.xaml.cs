using GraduationMVVM.Abstract;
using GraduationMVVM.MVVM.Models;

namespace GraduationMVVM;

public partial class App : Application
{
    public static BaseRepository<DevicesModel> DevicesRepository { get; set; }
    public static BaseRepository<ButtonModel> ButtonRepository { get; set; }
    public static BaseRepository<SwitchModel> SwitchRepository { get; set; }
    public static BaseRepository<SliderModel> SliderRepository { get; set; }
    public static BaseRepository<GaugeModel> GaugeRepository { get; set; }
    public static SelectedDevice SelectedDevice { get; set; }
    public static Pages Pages { get; set; }
    public App(BaseRepository<DevicesModel> devicerepo, BaseRepository<ButtonModel> buttonrepo, BaseRepository<SwitchModel> switchrepo, BaseRepository<SliderModel> trackbatrepo, BaseRepository<GaugeModel> gaugerepo, SelectedDevice device, Pages pages)
    {
        InitializeComponent();

        MainPage = new AppShell();

        DevicesRepository = devicerepo;
        ButtonRepository = buttonrepo;
        SwitchRepository = switchrepo;
        SliderRepository = trackbatrepo;
        GaugeRepository = gaugerepo;
        SelectedDevice = device;
        Pages = pages;
    }
}
