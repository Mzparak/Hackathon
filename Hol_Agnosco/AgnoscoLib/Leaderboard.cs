using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agnoscolib
{
    public class Leaderboard
    {
        public int Id { get; set; }
        public string AnonymousName { get; set; }
        public string Branch { get; set; }
        public int Points { get; set; }
        public string Department { get; set; }
        public string FullName { get; set; }
    }
}
