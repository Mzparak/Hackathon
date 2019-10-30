using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkunduConfig
{
    public class GenXML
    {
        public IList<PerilType> perilTypes { get; set; }
        public IList<PerilGroup> perilGroups { get; set; }
        public IList<RatingSectionType> ratingSectionTypes { get; set; }
    }

}
