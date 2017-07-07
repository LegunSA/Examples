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
    public class SaleLogRepository : IRepository<SaleLog, SaleLog>
    {
        protected FileTracer_DataBaseContext _dataContext;

        public void Create(SaleLog item)
        {
            _dataContext.SaleLogSet.Add(item.SaleLogToSaleLogSet());
        }

        public void Delete(SaleLog item)
        {
            var result = _dataContext.SaleLogSet.FirstOrDefault(x => x.Id == item.Id);
            _dataContext.SaleLogSet.Remove(result);
        }

        public void Edit(SaleLog item)
        {
            _dataContext.SaleLogSet.Attach(item.SaleLogToSaleLogSet()).State = EntityState.Modified;
        }

        public SaleLog Find(SaleLog searchObject)
        {
            SaleLog result = null;
            if (searchObject.Id != 0)
            {
                result = Find(x => x.Id == searchObject.Id);
            }
            if (searchObject.Report.Id != 0)
            {
                result = Find(x => x.ReportId == searchObject.Report.Id);
            }

            return result;
        }

        public ICollection<SaleLog> GetAll()
        {
            var saleLogs = _dataContext.SaleLogSet;
            var result = new List<SaleLog>();
            foreach (var item in saleLogs)
            {
                result.Add(item.SaleLogSetToSaleLog());
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

        private SaleLog Find(Func<SaleLogSet, bool> predicate)
        {
            var result = _dataContext.SaleLogSet.FirstOrDefault(predicate).SaleLogSetToSaleLog();
            return result;
        }

        public SaleLogRepository(FileTracer_DataBaseContext context)
        {
            _dataContext = context;
        }
    }
}
