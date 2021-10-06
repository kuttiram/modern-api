using Modern.Object.Models;
using System.Collections.Generic;

namespace Modern.BisnessAccessLayer.IRepository
{
    public interface IHomeBusinessLogic
    {
        HomeTitle GetHomeTitle();
        PageBanner GetPageContentBanner();
        List<PageBanner> GetPageContentBanners();
    }
}
