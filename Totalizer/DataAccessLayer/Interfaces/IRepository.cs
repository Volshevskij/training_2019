using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
