using AutoMapper;
using DAL.DataEntity;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BAL.MappingServices
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookViewModel>()
                .ForMember(dest => dest.CategoryType, opt => opt.MapFrom(src => src.CategoryBook.CategoryType));
            CreateMap<BookViewModel, Book>();

            CreateMap<BookViewModel, SelectListItem>()
           .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.CategoryBookId.ToString()))
           .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.CategoryType));

        }
    }
}

