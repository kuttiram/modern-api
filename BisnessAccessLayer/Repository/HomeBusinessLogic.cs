using AutoMapper;
using Modern.BisnessAccessLayer.IRepository;
using Modern.DataAccessLayer.UOW;
using Modern.Object.Models;
using System.Collections.Generic;
using System.Linq;

namespace Modern.BisnessAccessLayer.Repository
{
    public class HomeBusinessLogic : IHomeBusinessLogic
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public HomeBusinessLogic(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public HomeTitle GetHomeTitle()
        {
            var result = this._unitOfWork.homeTitle.Find(data => data.IsActive == true).Result?
                            .Select(data => this._mapper.Map<HomeTitle>(data)).FirstOrDefault();
            return result;
        }

        public PageBanner GetPageContentBanner()
        {
            var result = this._unitOfWork.contentBanner.Find(data => data.IsActive == true && data.IsHomeBanner == true).Result?
                            .Select(data => this._mapper.Map<PageBanner>(data)).FirstOrDefault();
            return result;
        }

        public List<PageBanner> GetPageContentBanners()
        {
            var result = this._unitOfWork.contentBanner.Find(data => data.IsActive == true && data.IsHomeBanner != true).Result?
                            .Select(data => this._mapper.Map<PageBanner>(data)).Take(4).ToList();
            return result;
        }
    }
}
