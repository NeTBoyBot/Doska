using AutoMapper;
using Doska.Contracts.FavoriteAdDto;
using Doska.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.AppServices.MapProfile
{
    public class FavoriteAdMapProfile : Profile
    {
        public FavoriteAdMapProfile()
        {
            CreateMap<FavoriteAd, InfoFavoriteAdResponse>().ReverseMap();
        }
    }
}
