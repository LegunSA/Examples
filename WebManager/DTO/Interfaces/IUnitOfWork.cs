using DTO.PresentationModels;
using System;

namespace DTO.Interfaces
{
    public interface IUnitOfWork: IDisposable
    {
        IRepository<Client, Client> ClientRepository { get; set; }
        IRepository<Manager, Manager> ManagerRepository { get; set; }
        IRepository<Product, Product> ProductRepository { get; set; }
        IRepository<Report, Report> ReportRepository { get; set; }

        void Save();
    }
}
