using AutoMapper;
using DataModel.Entites;
using Dto;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.MappingProfileEntity
{
    public class MappingEnities : Profile
    {
        public MappingEnities() 
        {
            CreateMap<Customer,CustomerDto>().ReverseMap();
        }
    }
}
