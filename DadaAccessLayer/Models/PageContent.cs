using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Modern.DataAccessLayer.Models
{
    public partial class PageContent
    {
        public PageContent()
        {
            PageImages = new HashSet<PageImages>();
        }

        public int ContentId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime PostDate { get; set; }
        public bool IsHomeBanner { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual ICollection<PageImages> PageImages { get; set; }
    }
}
