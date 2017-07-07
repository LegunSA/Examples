using DTO.Interfaces;
using DataBase.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using DTO.Mapping;
using DTO.PresentationModels;

namespace DTO.Repositories
{
    public class ManagerRepository : IRepository<Manager, Manager>
    {
        protected FileTracer_DataBaseContext _dataContext;

        public void Create(Manager item)
        {
            _dataContext.ManagerSet.Add(item.ManagerToManagerSet());
        }

        public void Delete(Manager item)
        {
            var result = _dataContext.ManagerSet.FirstOrDefault(x => x.Id == item.Id);
            _dataContext.ManagerSet.Remove(result);
        }

        public void Edit(Manager item)
        {
            _dataContext.ManagerSet.Attach(item.ManagerToManagerSet()).State = EntityState.Modified;
        }

        public Manager Find(Manager searchObject)
        {
            Manager result = null;
            if (searchObject.Id != 0)
            {
                result = Find(x => x.Id == searchObject.Id);
            }
            if (!string.IsNullOrEmpty(searchObject.Name))
            {
                result = Find(x => x.Name == searchObject.Name);
            }

            return result;
        }

        public ICollection<Manager> GetAll()
        {
            var managers = _dataContext.ManagerSet;
            var result = new List<Manager>();
            foreach (var item in managers)
            {
                result.Add(item.ManagerSetToManager());
            }
            return result;
        }

        /* public ICollection<IManagerSet> GetList(Func<ManagerSet, bool> predicate)
         {
             return _dataContext.ManagerSet.Where(predicate).ToList();
         }*/

        public void Save()
        {
            _dataContext.SaveChanges();
        }

        public void Dispose()
        {
            if (_dataContext != null)
            {
                _dataContext.Dispose();
                _dataContext = null;
            }
        }

        private Manager Find(Func<ManagerSet, bool> predicate)
        {
            var result = _dataContext.ManagerSet.FirstOrDefault(predicate).ManagerSetToManager();
            return result;
        }

        public ManagerRepository(FileTracer_DataBaseContext context)
        {
            _dataContext = context;
        }
    }
}
