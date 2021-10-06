using AutoMapper;
using Modern.DataAccessLayer.Models;
using Modern.Object.Models;

namespace Modern.DataAccessLayer.Automapper
{
    public class ModernMapper : Profile
    {
        public ModernMapper()
        {
            CreateMap<UserUserInfo, LoginInfo>();
            CreateMap<PageTitle, HomeTitle>();
            CreateMap<PageContent, PageBanner>()
                    .ForMember(d => d.PageImages, o => o.MapFrom(src => src.PageImages));
            CreateMap<PageImages, BannerImage>();
        }
    }
}
