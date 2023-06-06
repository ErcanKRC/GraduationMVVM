using GraduationMVVM.Abstract;

namespace GraduationMVVM.MVVM.Models
{
    public class GaugeModel : TableData
    {
        public int DeviceId { get; set; }
        public string GaugeName { get; set; }
        public int StreamId { get; set; }
        public int Value { get; set; }
        public int Value0 { get; set; }
        public int Value1 { get; set; }


    }
}
