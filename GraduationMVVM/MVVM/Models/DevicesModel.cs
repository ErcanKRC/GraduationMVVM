using GraduationMVVM.Abstract;

/* Unmerged change from project 'GraduationMVVM (net6.0-android)'
Before:
using System;
After:
using SQLite;
using System;
*/

/* Unmerged change from project 'GraduationMVVM (net6.0-ios)'
Before:
using System;
After:
using SQLite;
using System;
*/

/* Unmerged change from project 'GraduationMVVM (net6.0-windows10.0.19041.0)'
Before:
using System;
After:
using SQLite;
using System;
*/

/* Unmerged change from project 'GraduationMVVM (net6.0-android)'
Before:
using System.Threading.Tasks;
using SQLite;
After:
using System.Threading.Tasks;
*/

/* Unmerged change from project 'GraduationMVVM (net6.0-ios)'
Before:
using System.Threading.Tasks;
using SQLite;
After:
using System.Threading.Tasks;
*/

/* Unmerged change from project 'GraduationMVVM (net6.0-windows10.0.19041.0)'
Before:
using System.Threading.Tasks;
using SQLite;
After:
using System.Threading.Tasks;
*/


namespace GraduationMVVM.MVVM.Models
{
    public class DevicesModel : TableData
    {
        public string Name { get; set; }
        public string Token { get; set; }
        public string Server { get; set; }
    }

}
