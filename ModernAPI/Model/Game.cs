using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModernAPI.Model
{
    public class Game
    {
        public string background_Image { get; set; }
        public string name { get; set; }
        public string released { get; set; }
        public string metacritic_Url { get; set; }
        public string website { get; set; }
        public string description { get; set; }
        public Int32 metacritic { get; set; }
        public List<ParentPlatForm> parentPlatForms { get; set; }
    }

    public class ParentPlatForm
    {
        public string platForm { get; set; }
    }
}
