using DTO.Interfaces;
using DataBase.Models;
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using DTO.Mapping;
using DTO.PresentationModels;

namespace DTO.Repositories
{
    public class ClientRepository : IRepository<Client, Client>
    {
        protected FileTracer_DataBaseContext _dataContext;

        public void Create(Client item)
        {
            if (item != null)
            {
                _dataContext.ClientSet.Add(item.ClientToClientSet());
            }
        }

        public void Delete(Client item)
        {
            ClientSet result =null;
            if (item != null)
            {
                result = _dataContext.ClientSet.FirstOrDefault(x => x.Id == item.Id);
            }
            if (result != null)
            {
                _dataContext.ClientSet.Remove(result);
            }
        }

        public void Edit(Client item)
        {
            if (item != null)
            {
                _dataContext.ClientSet.Attach(item.ClientToClientSet()).State = EntityState.Modified;
            }
        }

        public Client Find(Client searchObject)
        {
            Client result = null;
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

        public ICollection<Client> GetAll()
        {
            var clients = _dataContext.ClientSet;
            var result = new List<Client>();
            if (clients != null)
            {
                foreach (var item in clients)
                {
                    result.Add(item.ClientSetToClient());
                }
            }
            return result;
        }

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

        private Client Find(Func<ClientSet, bool> predicate)
        {
            var result = _dataContext.ClientSet.FirstOrDefault(predicate).ClientSetToClient();
            return result;
        }

        public ClientRepository(FileTracer_DataBaseContext context)
        {
            _dataContext = context;
        }
    }
}
