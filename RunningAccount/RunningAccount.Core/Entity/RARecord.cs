using RunningAccount.Core.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunningAccount.Core.Entity
{
    public class RARecord
    {
        public int UserID { get; set; }

        public RATypeEnum RAType { get; set; }

        public Decimal Amount { get; set; }
    }
}
