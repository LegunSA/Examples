using DataBase.Models;
using System.Collections.Generic;
using DTO.Interfaces;
using DTO.PresentationModels;
using AutoMapper;

namespace DTO.Mapping
{
    internal static class MappingExtension
    {
        internal static ClientSet ClientToClientSet(this Client client)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Client, ClientSet>());
            var t = Mapper.Map<Client, ClientSet>(client);

            return t;
        }

        internal static Client ClientSetToClient(this ClientSet client)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ClientSet, Client>());
            var result = Mapper.Map<ClientSet, Client>(client);

            return result;
        }

        internal static SaleLogSet SaleLogToSaleLogSet(this SaleLog saleLog)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<SaleLog, SaleLogSet>());
            var result = Mapper.Map<SaleLog, SaleLogSet>(saleLog);

            return result;
        }

        internal static SaleLog SaleLogSetToSaleLog(this SaleLogSet saleLog)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<SaleLogSet, SaleLog>());
            var result = Mapper.Map<SaleLogSet, SaleLog>(saleLog);

            return null;
        }

        internal static ProductSet ProductToProductSet(this Product product)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Product, ProductSet>());
            var result = Mapper.Map<Product, ProductSet>(product);

            return result;
        }

        internal static Product ProductSetToProduct(this ProductSet product)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ProductSet, Product>());
            var result = Mapper.Map<ProductSet, Product>(product);

            return result;
        }

        internal static ReportSet ReportToIReport(this Report report)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Report, ReportSet>());
            var result = Mapper.Map<Report, ReportSet>(report);

            return result;
        }

        internal static Report ReportSetToSaleLog(this ReportSet report)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ICollection<SaleLogSet>, ICollection<SaleLog>>());
            var result = new Report()
            {
                Id = report.Id,
                Date = report.Date,
                Manager = report.Manager.ManagerSetToManager(),
                SaleLog = new List<SaleLog>()
            };
            result.SaleLog = Mapper.Map<ICollection<SaleLogSet>, ICollection<SaleLog>>(report.SaleLogSet);

            return result;
        }

        internal static ManagerSet ManagerToManagerSet(this Manager manager)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<Report, ReportSet>());
            Mapper.Initialize(cfg => cfg.CreateMap<ICollection<Report>, ICollection<ReportSet>>());
            var result = new ManagerSet()
            {
                Id = manager.Id,
                Name = manager.Name,
                ReportSet = new List<ReportSet>()
            };
            result.ReportSet = Mapper.Map<ICollection<Report>, ICollection<ReportSet>>(manager.Report);

            return result;
        }

        internal static Manager ManagerSetToManager(this ManagerSet manager)
        {
            Mapper.Initialize(cfg => cfg.CreateMap<ManagerSet, Manager>());
            var result = Mapper.Map<ManagerSet, Manager>(manager);

            return result;
        }
    }
}
