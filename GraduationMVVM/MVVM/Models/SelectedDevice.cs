namespace GraduationMVVM.MVVM.Models
{
    public class SelectedDevice : DevicesModel
    {
        public List<ButtonModel> Buttons { get; set; }
        public List<SwitchModel> Switchs { get; set; }
        public List<GaugeModel> Gauges { get; set; }
        public List<SliderModel> TrackBars { get; set; }
    }
}
