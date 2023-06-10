using PropertyChanged;
using System.Collections.ObjectModel;

namespace GraduationMVVM.MVVM.Models
{
    public class SelectedDevice : DevicesModel
    {
        public ObservableCollection<ButtonModel> Buttons { get; set; }
        public ObservableCollection<SwitchModel> Switchs { get; set; }
        public ObservableCollection<GaugeModel> Gauges { get; set; }
        public ObservableCollection<SliderModel> Sliders { get; set; }
    }
}
