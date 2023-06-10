using GraduationMVVM.MVVM.Models;
using SQLite;
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
            if (item.Id != 0) { Connection.Update(item); }
            else { Connection.Insert(item); }
        }

        public void GaugeValueUpdate(int GaugeId, int Value)
        {
            var gauge = Connection.Table<GaugeModel>().FirstOrDefault(x => x.Id == GaugeId);
            gauge.Value = Value;
            Connection.Update(gauge);
        }
        public void DeleteItem(T item)
        {
            Connection.Delete(item);
        }
        public void DeleteIDItem(int ID)
        {
            var entity = Connection.Table<T>().FirstOrDefault(x => x.Id == ID);
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
        public List<T> GetList(Expression<Func<T, bool>> filter)
        {
            var entity = Connection.Table<T>().Where(filter);

            return entity.ToList();
        }

        public bool IsEmpty()
        {
            if (Connection.Table<T>() == null) return true;
            else return false;
        }
    }

}

