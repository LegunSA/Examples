using System;
using System.Collections.Generic;

namespace DTO.Interfaces
{
    public interface IRepository<TModel, TRequest>:IDisposable where TModel : class
    {        
        void Create(TModel item);
        void Delete(TModel item);
        void Edit(TModel item);
        TModel Find(TRequest searchobject);
        ICollection<TModel> GetAll();
       // ICollection<T> GetList(Func<T, bool> predicate);      
        void Save();
    }
}
