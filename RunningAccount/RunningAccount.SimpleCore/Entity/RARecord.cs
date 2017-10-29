using RunningAccount.Core.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunningAccount.Core.Entity
{
    public class RARecord
    {
        public String UserID { get; set; }

        public RATypeEnum RAType { get; set; }

        public Decimal Amount { get; set; }

        public DateTime AddTime { get; set; }
    }
}
