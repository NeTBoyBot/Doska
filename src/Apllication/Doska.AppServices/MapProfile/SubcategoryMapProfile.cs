using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Doska.Domain;
using Doska.Contracts.AdDto;
using Doska.Contracts.SubCategoryDto;

namespace Doska.AppServices.MapProfile
{
    public class SubCategoryMapProfile : Profile
    {
        public SubCategoryMapProfile()
        {
            CreateMap<Subcategory, AdOrUpdateSubCategoryRequest>().ReverseMap();
            CreateMap<Subcategory, InfoSubCategoryResponse>().ReverseMap();
        }
    }
}
