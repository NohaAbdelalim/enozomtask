using AutoMapper;
using enozom.Domain.Models;

namespace enozom.API.MappingProfiles
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<BookCopy, Dto>().ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Book.Title))
                 .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status))
                 .ForMember(dest => dest.CopyId, opt => opt.MapFrom(src => src.Id));




        }
    }
}
