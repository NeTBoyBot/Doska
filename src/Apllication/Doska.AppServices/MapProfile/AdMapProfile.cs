using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Doska.Domain;
using Doska.Contracts.AdDto;

namespace Doska.AppServices.MapProfile
{
    public class AdMapProfile : Profile
    {
        public AdMapProfile()
        {
            CreateMap<Ad, InfoAdResponse>().ReverseMap();
            CreateMap<Ad, CreateOrUpdateAdRequest>().ReverseMap();
        }
    }
}
