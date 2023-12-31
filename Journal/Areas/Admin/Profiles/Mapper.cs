using AutoMapper;
using Journal.DTOs;
using Journal.Models;

namespace Journal.Areas.Admin.Profiles
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<journal, JournalGetDto>();
            CreateMap<JournalPostDto, journal>();

        }
    }
}
