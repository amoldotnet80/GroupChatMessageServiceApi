using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroupChatMessageService.Model
{
    public class ChatGroupMessageMapperMappings : Profile
    {
        public ChatGroupMessageMapperMappings()
        {
            CreateMap<Group, GroupDto>().ReverseMap();
        }
    }
}
