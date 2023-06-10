
using GraduationMVVM.Abstract;
using PropertyChanged;

namespace GraduationMVVM.MVVM.Models
{
    [AddINotifyPropertyChangedInterface]
    public class SliderModel : TableData
    {
        public int DeviceId { get; set; }
        public string SliderName { get; set; }
        public int StreamId { get; set; }
        public int Value { get; set; }
        public int Value0 { get; set; }
        public int Value1 { get; set; }


    }
}
