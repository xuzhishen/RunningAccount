﻿using RunningAccount.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunningAccount.Core.Data
{
    class DataMapping
    {
        public List<User> Users { get; set; } = new List<User>();

        public List<RARecord> Records { get; set; } = new List<RARecord>();

    }
}
