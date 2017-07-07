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
    public class ProductRepository : IRepository<Product, Product>
    {
        protected FileTracer_DataBaseContext _dataContext;

        public void Create(Product item)
        {
            _dataContext.ProductSet.Add(item.ProductToProductSet());
        }

        public void Delete(Product item)
        {
            var result = _dataContext.ProductSet.FirstOrDefault(x => x.Id == item.Id);
            _dataContext.ProductSet.Remove(result);
        }

        public void Edit(Product item)
        {
            _dataContext.ProductSet.Attach(item.ProductToProductSet()).State = EntityState.Modified;
        }

        public Product Find(Product searchObject)
        {
            Product result = null;
            if (searchObject.Id != 0)
            {
                result = Find(x => x.Id == searchObject.Id);
            }
            if (!string.IsNullOrEmpty(searchObject.ProductName))
            {
                result = Find(x => x.ProductName == searchObject.ProductName);
            }

            return result;
        }

        public ICollection<Product> GetAll()
        {
            var products = _dataContext.ProductSet;
            var result = new List<Product>();
            foreach (var item in products)
            {
                result.Add(item.ProductSetToProduct());
            }
            return result;
        }

        public ICollection<Product> GetList(Func<ProductSet, bool> predicate)
        {
            var products = _dataContext.ProductSet;
            var result = new List<Product>();
            foreach (var item in products)
            {
                result.Add(item.ProductSetToProduct());
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

        private Product Find(Func<ProductSet, bool> predicate)
        {
            var result = _dataContext.ProductSet.FirstOrDefault(predicate).ProductSetToProduct();
            return result;
        }

        public ProductRepository(FileTracer_DataBaseContext context)
        {
            _dataContext = context;
        }
    }
}
