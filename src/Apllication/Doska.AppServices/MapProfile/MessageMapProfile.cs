using AutoMapper;
using Doska.Contracts.Message;
using Doska.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.AppServices.MapProfile
{
    public class MessageMapProfile : Profile
    {
        public MessageMapProfile()
        {
            CreateMap<Message, InfoMessageResponse>().ReverseMap();
            CreateMap<Message, CreateMessageRequest>().ReverseMap();
        }
    }
}
