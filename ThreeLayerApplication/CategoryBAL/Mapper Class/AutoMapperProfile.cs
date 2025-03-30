using AutoMapper;
using CategoryDAL;
using CategoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CategoryBAL.Mapper_Class
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<Category,CategoryViewModel>().ReverseMap();
        }
    }
}
