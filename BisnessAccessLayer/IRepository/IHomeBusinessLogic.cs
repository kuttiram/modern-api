using Modern.Object.Models;

namespace Modern.BisnessAccessLayer.IRepository
{
    public interface IHomeBusinessLogic
    {
        HomeTitleObj GetHomeTitle();
        PageBanner GetPageContentBanner();
    }
}
