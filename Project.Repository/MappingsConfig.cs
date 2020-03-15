using AutoMapper;
using Project.DAL.Entities;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class MappingsConfig : Profile
    {
        public MappingsConfig()
        {
            CreateMap<CartEntity, Cart>().ReverseMap();
            CreateMap<CartEntity, ICart>().ReverseMap();
            CreateMap<ICart, Cart>().ReverseMap();
        }   
    }
}
