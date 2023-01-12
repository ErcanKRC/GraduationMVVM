using System.Linq.Expressions;

namespace GraduationMVVM.Abstract
{
    public interface IBaseRepository<T> : IDisposable where T : TableData, new()
    {
        List<T> GetAll();

        void AddItem(T item);
        void DeleteItem(T item);
        public void DeleteIDItem(int ID);
        public T Get(Expression<Func<T, bool>> filter);
    }
}
