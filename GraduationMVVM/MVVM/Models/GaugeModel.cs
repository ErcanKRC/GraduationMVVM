using GraduationMVVM.Abstract;
using Microsoft.Maui.Graphics;
using PropertyChanged;

namespace GraduationMVVM.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class GaugeModel : TableData
    {
        public int DeviceId { get; set; }
        public string GaugeName { get; set; }
        public int StreamId { get; set; }
        public int Value { get; set; }
        public int Value0 { get; set; }
        public int Value1 { get; set; }
        /*
        public Color maxTrackColor { get; set; }
        public Color minTrackColor { get; set; }
        public Color trackColor { get; set; }
        */

    }
}
