using AutoMapper;
using DataAccessLayer.Models;
using Modern.Object.Models;

namespace Modern.DataAccessLayer.Automapper
{
    public class ModernMapper : Profile
    {
        public ModernMapper()
        {
            CreateMap<UserUserInfo, LoginInfo>();
        }
    }
}
