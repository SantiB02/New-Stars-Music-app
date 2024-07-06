using AutoMapper;
using Merchanmusic.Data.Entities;
using Merchanmusic.Data.Models;

namespace Merchanmusic.Data.Mapping_Profiles
{
    public class ClientUpdateDtoMappingProfile : Profile
    {
        public ClientUpdateDtoMappingProfile()
        {
            CreateMap<ClientUpdateDto, User>().ForAllMembers(opts => opts.MapAtRuntime());
        }
    }
}
