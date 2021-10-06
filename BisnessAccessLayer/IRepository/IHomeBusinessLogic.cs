using Modern.Object.Models;

namespace Modern.BisnessAccessLayer.IRepository
{
    public interface IHomeBusinessLogic
    {
        HomeTitle GetHomeTitle();
        PageBanner GetPageContentBanner();
    }
}
