using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GraduationMVVM.MVVM.Models;
using PropertyChanged;

namespace GraduationMVVM.MVVM.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public partial class AddWidgetPageViewModel : ObservableObject
    {
        public string WidgetType { get; set; }
        public string WidgetName { get; set; }
        public int StreamId { get; set; }
        public int Value0 { get; set; }
        public int Value1 { get; set; }

        public AddWidgetPageViewModel()
        {
            WidgetName = string.Empty;
        }


        [RelayCommand]
        public void AddWidget()
        {
            switch (WidgetType)
            {
                case "Button":
                    App.ButtonRepository.AddorUpdateItem(new ButtonModel
                    {
                        ButName = WidgetName,
                        DeviceId = App.SelectedDevice.Id,
                        StreamId = StreamId,
                        Value0 = Value0,
                        Value1 = Value1,
                    });
                    break;
                case "Switch":
                    App.SwitchRepository.AddorUpdateItem(new SwitchModel
                    {
                        SwName = WidgetName,
                        DeviceId = App.SelectedDevice.Id,
                        StreamId = StreamId,
                        Value0 = Value0,
                        Value1 = Value1,
                    });
                    break;
                case "Gauge":
                    App.GaugeRepository.AddorUpdateItem(new GaugeModel
                    {
                        GaugeName = WidgetName,
                        DeviceId = App.SelectedDevice.Id,
                        StreamId = StreamId,
                        Value0 = Value0,
                        Value1 = Value1,
                    });
                    break;
                case "TrackBar":
                    App.SliderRepository.AddorUpdateItem(new SliderModel
                    {
                        TbName = WidgetName,
                        DeviceId = App.SelectedDevice.Id,
                        StreamId = StreamId,
                        Value0 = Value0,
                        Value1 = Value1

                    });
                    break;
            };
        }

    }
}
