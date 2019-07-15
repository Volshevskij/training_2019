using System.Collections.Generic;

namespace BusinessLogickLayer.Interfaces
{
    public interface IService<T>
        where T:class
    {
        IEnumerable<T> GetItemsList();
        T GetItemById(int id);
        void CreateItem(T item);
        void UpdateItem(T item);
        void DeleteItem(int id);
    }
}
