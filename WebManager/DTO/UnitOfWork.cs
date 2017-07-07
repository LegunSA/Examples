using DTO.Interfaces;
using DataBase.Models;
using DTO.Repositories;
using DTO.PresentationModels;

namespace DTO
{
    public class UnitOfWork : IUnitOfWork
    {
        public IRepository<Client, Client> ClientRepository { get; set; }
        public IRepository<Manager, Manager> ManagerRepository { get; set; }
        public IRepository<Product, Product> ProductRepository { get; set; }
        public IRepository<Report, Report> ReportRepository { get; set; }
        public IRepository<SaleLog, SaleLog> SaleLogRepository { get; set; }

        public void Save()
        {
            ClientRepository.Save();
            ManagerRepository.Save();
            ProductRepository.Save();
            ReportRepository.Save();
            SaleLogRepository.Save();
        }

        public UnitOfWork()
        {
            FileTracer_DataBaseContext context = new FileTracer_DataBaseContext();
            ClientRepository = new ClientRepository(context);
            ManagerRepository = new ManagerRepository(context);
            ProductRepository = new ProductRepository(context);
            ReportRepository = new ReportRepository(context);
            SaleLogRepository = new SaleLogRepository(context);
        }
        public void Dispose()
        {
            if (ClientRepository != null)
            {
                ClientRepository.Dispose();
                ClientRepository = null;
            }
            if (ManagerRepository != null)
            {
                ManagerRepository.Dispose();
                ManagerRepository = null;
            }
            if (ProductRepository != null)
            {
                ProductRepository.Dispose();
                ProductRepository = null;
            }
            if (ReportRepository != null)
            {
                ReportRepository.Dispose();
                ReportRepository = null;
            }
            if (SaleLogRepository != null)
            {
                SaleLogRepository.Dispose();
                SaleLogRepository = null;
            }
        }

    }
}
