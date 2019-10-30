using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agnoscolib
{
    public class Nomination
    {
        public int NominationId { get; set; }
        public int NominatorId{get;set;}
        public int NomineeId { get; set; }
        public string NominatorFullName { get; set; }
        public string NomineeFullName { get; set; }
        public string NominationDetails { get; set; }
        public int Points { get; set; }
        public string DateAdded { get; set; }
        public string Status { get; set; }
        public int LoggedInUserId { get; set; }

    }
}
