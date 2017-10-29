using RunningAccount.Core.Data;
using RunningAccount.Core.Entity;
using RunningAccount.Core.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunningAccount.Core
{
    public class RAManager
    {
        public void AddUser(String id, string name) {
            DataOpt.Mapping.Users.Add(new User() { UserID = id, UserName = name });
            DataOpt.Save();
        }

        public void AppendRecord(String userId, RATypeEnum raType, Decimal amount, DateTime addTime)
        {
            DataOpt.Mapping.Records.Add(new RARecord()
            {
                UserID = userId,
                RAType = raType,
                Amount = amount,
                AddTime = addTime
            });
            DataOpt.Save();
        }

        public List<User> getUsers() {
            return DataOpt.Mapping.Users;
        }

        public List<RARecord> getRecord() {
            return DataOpt.Mapping.Records;
        }
    }
}
