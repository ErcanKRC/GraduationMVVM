using SQLite;
using System.Linq;
using System.Linq.Expressions;

namespace GraduationMVVM.Abstract
{
    public class BaseRepository<T> : IBaseRepository<T> where T : TableData, new()
    {

        SQLiteConnection Connection;
        public BaseRepository()
        {
            Connection = new SQLiteConnection(Constant.DBpath);
            Connection.CreateTable<T>();
        }
        public void AddorUpdateItem(T item)
        {
            if (item.ID != 0) { Connection.Update(item); }
            else { Connection.Insert(item); }
        }

        public void DeleteItem(T item)
        {
            Connection.Delete(item);
        }
        public void DeleteIDItem(int ID)
        {
            var entity = Connection.Table<T>().FirstOrDefault(x => x.ID == ID);
            Connection.Delete(entity);
        }

        public void Dispose()
        {
            Connection.Close();
        }

        public List<T> GetAll()
        {
            return Connection.Table<T>().ToList();
        }
        public T Get(Expression<Func<T, bool>> filter)
        {
            var entity = Connection.Table<T>().FirstOrDefault(filter);

            return entity;
        }

    }

}

