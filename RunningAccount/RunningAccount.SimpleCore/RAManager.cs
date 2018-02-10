using RunningAccount.Core.Data;
using RunningAccount.Core.Entity;
using RunningAccount.Core.Util;
using RunningAccount.SimpleCore.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace RunningAccount.Core
{
    public class RAManager
    {
        public Result AddUser(String id, string name) {
            if (DataOpt.Mapping.Users.Exists(p => p.UserID == id))
                return Result.Fail("用户ID重复");

            if (DataOpt.Mapping.Users.Exists(p => p.UserName == name))
                return Result.Fail("用户名称重复");

            DataOpt.Mapping.Users.Add(new User() { UserID = id, UserName = name });
            DataOpt.Save();

            return Result.OK();
        }

        public Result AppendRecord(String userId, RATypeEnum raType, Decimal amount, DateTime addTime)
        {
            if (!DataOpt.Mapping.Users.Exists(p => p.UserID == userId))
                return Result.Fail("用户ID不存在");

            DataOpt.Mapping.Records.Add(new RARecord()
            {
                UserID = userId,
                RAType = raType,
                Amount = amount,
                AddTime = addTime
            });
            DataOpt.Save();

            return Result.OK();
        }

        public List<User> getUsers() {
            return DataOpt.Mapping.Users;
        }

        public List<RARecord> getRecord() {
            return DataOpt.Mapping.Records;
        }
    }
}
