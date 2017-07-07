using System;
using System.Collections.Generic;
using System.Text;

namespace WebManager.Interfaces
{
    interface ICRUDController<T>
    {
        ICollection<T> Index();
        T Details(int? id);
        void Create(T item);
        T Edit(int? id);
        void Edit(T item);
    }
}
