using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EkunduConfig
{
    public class RiskAttributes
    {
        public List<PerilType> perilTypes { get; set; }
        public PerilGroup perilGroup { get; set; }
        public RatingSectionType ratingSectionType { get; set; }

    }
}
