using AutoMapper;
using Doska.Contracts.Chat;
using Doska.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.AppServices.MapProfile
{
    public class ChatMapProfile : Profile
    {
        public ChatMapProfile()
        {
            CreateMap<Chat, InfoChatResponse>().ReverseMap();
            CreateMap<Chat, CreateChatRequest>().ReverseMap();
        }
    }
}
