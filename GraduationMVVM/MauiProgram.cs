using CommunityToolkit.Maui;
using GraduationMVVM.Abstract;
using GraduationMVVM.MVVM.Models;
using Syncfusion.Maui.Core.Hosting;

namespace GraduationMVVM;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder.UseMauiCommunityToolkit();
        builder.ConfigureSyncfusionCore();
        builder.UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.Services.AddSingleton<BaseRepository<DevicesModel>>();
        builder.Services.AddSingleton<BaseRepository<SliderModel>>();
        builder.Services.AddSingleton<BaseRepository<ButtonModel>>();
        builder.Services.AddSingleton<BaseRepository<SwitchModel>>();
        builder.Services.AddSingleton<BaseRepository<GaugeModel>>();
        builder.Services.AddSingleton<SelectedDevice>();
        builder.Services.AddSingleton<Pages>();

        return builder.Build();
    }
}
