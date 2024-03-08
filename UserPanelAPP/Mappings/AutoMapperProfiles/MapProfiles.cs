using AutoMapper;
using UserPanelAPP.Models;
using UserPanelAPP.Models.DTOs;

namespace UserPanelAPP.Mappings.AutoMapperProfiles
{
    public class MapProfiles:Profile
    {
        public MapProfiles()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
