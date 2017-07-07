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
    public class ReportRepository : IRepository<Report, Report>
    {
        protected FileTracer_DataBaseContext _dataContext;

        public void Create(Report item)
        {
            _dataContext.ReportSet.Add(item.ReportToIReport());
        }

        public void Delete(Report item)
        {
            var result = _dataContext.ReportSet.FirstOrDefault(x => x.Id == item.Id);

            _dataContext.ReportSet.Remove(result);
        }

        public void Edit(Report item)
        {
            _dataContext.ReportSet.Attach(item.ReportToIReport()).State = EntityState.Modified;
        }

        public Report Find(Report searchObject)
        {
            Report result = null;
            if (searchObject.Id != 0)
            {
                result = Find(x => x.Id == searchObject.Id);
            }

            return result;
        }

        public ICollection<Report> GetAll()
        {
            var reports = _dataContext.ReportSet.Include(r => r.Manager);
            var result = new List<Report>();
            foreach (var item in reports)
            {
                result.Add(item.ReportSetToSaleLog());
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

        private Report Find(Func<ReportSet, bool> predicate)
        {
            var reportList = _dataContext.ReportSet.Include(r => r.Manager);
            var result = reportList.FirstOrDefault(predicate).ReportSetToSaleLog();
            return result;
        }

        public ReportRepository(FileTracer_DataBaseContext context)
        {
            _dataContext = context;
        }
    }
}
