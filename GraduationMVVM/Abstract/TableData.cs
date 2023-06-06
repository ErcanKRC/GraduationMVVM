using SQLite;

namespace GraduationMVVM.Abstract
{
    public abstract class TableData
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
