using AutoMapper;
using DTO.PresentationModels;
using System.Collections.Generic;
using System.Linq;
using WebManager.Models;

namespace WebManager.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Client, ClientModel>();
            CreateMap<ClientModel, Client>();
            CreateMap<ICollection<Client>, ICollection<ClientModel>>();
            CreateMap<Manager, ManagerModel>();
            CreateMap<ManagerModel, Manager>();
            CreateMap<ICollection<Manager>, ICollection<ManagerModel>>();
            CreateMap<Product, ProductModel>();
            CreateMap<ProductModel, Product>();
            CreateMap<Report, ReportModel>();
            CreateMap<ReportModel, Report>();
        }
    }
}
