using GraduationMVVM.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduationMVVM.MVVM.Models
{
    public class DeviceSpecsModel : TableData
    {
        public int Button { get; set; }
        public int Gauge { get; set; }
        public int TrackBar { get; set; }
        public bool isActive { get; set; }
    }
}
