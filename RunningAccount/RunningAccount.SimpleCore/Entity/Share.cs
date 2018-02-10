using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAccount.SimpleCore.Entity
{
    public class Share
    {
        public String UserID { get; set; }

        public String UserName { get; set; }

        public double Perc { get; set; }

        public Decimal Amount { get; set; }

        public Decimal AllTurnIn { get; set; }
    }
}
