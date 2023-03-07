using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Doska.Domain;
using Doska.Contracts.AdDto;
using Doska.Contracts.CategoryDto;

namespace Doska.AppServices.MapProfile
{
    public class CategoryMapProfile : Profile
    {
        public CategoryMapProfile()
        {
            CreateMap<Category,InfoCategoryResponse>().ReverseMap();
            CreateMap<Category, CreateCategoryRequest>().ReverseMap();
        }
    }
}
