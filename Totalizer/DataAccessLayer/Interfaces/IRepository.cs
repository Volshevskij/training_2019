using System.Collections.Generic;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<T>
        where T:class
    {
        IEnumerable<T> GetItemsList();
        T GetItemById(int id);
        void CreateItem(T item);
        void UpdateItem(T item);
        void DeleteItem(int id);
    }
}
