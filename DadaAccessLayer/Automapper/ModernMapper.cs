using AutoMapper;
using DadaAccessLayer.Models;
using Modern.Object.Models;

namespace Modern.Utility.Automapper
{
    public class ModernMapper : Profile
    {
        public ModernMapper()
        {
            CreateMap<UserUserInfo, LoginInfo>();
        }
    }
}
