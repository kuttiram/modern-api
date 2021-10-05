using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Modern.DataAccessLayer.Models
{
    public partial class PageImages
    {
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
        public int ContentId { get; set; }
        public bool? IsActive { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }

        public virtual PageContent Content { get; set; }
    }
}
