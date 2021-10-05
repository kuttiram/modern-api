using System;
using System.Collections.Generic;

namespace Modern.Object.Models
{
    public class PageBanner
    {
        //public PageBanner()
        //{
        //    this.PageImages = new List<BannerImage>();
        //}
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? PostDate { get; set; }
        public ICollection<BannerImage> PageImages { get; set; }
    }
}
