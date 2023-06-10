using GraduationMVVM.Abstract;
using PropertyChanged;

namespace GraduationMVVM.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class SwitchModel : TableData
    {
        public int DeviceId { get; set; }
        public string SwName { get; set; }
        public int StreamId { get; set; }
        public int Value0 { get; set; }
        public int Value1 { get; set; }
        public bool IsEnabled { get; set; }
    }
}