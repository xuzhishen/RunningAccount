using RunningAccount.Core.Data;
using RunningAccount.SimpleCore.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RunningAccount.Core
{
    public static class Statistics
    {
        public static String getShare()
        {
            List<Share> listShare = DataOpt.Mapping.Users.Select(p => new Share() { UserID = p.UserID, UserName = p.UserName }).ToList();

            DataOpt.Mapping.Records.ForEach(p => {
                if (p.RAType == Util.RATypeEnum.TurnIn)
                {
                    listShare.Find(q => q.UserID == p.UserID).Amount += p.Amount;

                    decimal sum = listShare.Sum(q => q.Amount);

                    listShare.ForEach(q => q.Perc = Convert.ToDouble(q.Amount / sum));
                }
                else if (p.RAType == Util.RATypeEnum.TurnOut)
                {
                    listShare.Find(q => q.UserID == p.UserID).Amount -= p.Amount;

                    decimal sum = listShare.Sum(q => q.Amount);

                    listShare.ForEach(q => q.Perc = Convert.ToDouble(q.Amount / sum));
                }
                else if (p.RAType == Util.RATypeEnum.NewVal) {
                    listShare.ForEach(q => q.Amount = Convert.ToDecimal(q.Perc) * p.Amount);
                }
            });

            StringBuilder sb = new StringBuilder();
            listShare.ForEach(p => {
                p.AllTurnIn = DataOpt.Mapping.Records.Sum(q => {
                    if (q.UserID == p.UserID)
                    {
                        if (q.RAType == Util.RATypeEnum.TurnIn)
                            return q.Amount;
                        else if (q.RAType == Util.RATypeEnum.TurnOut)
                            return -q.Amount;
                        else
                            return 0;
                    }
                    else
                        return 0;
                });

                sb.AppendLine(String.Format("用户：{0}\t总投入：{1}\t最新净值：{2}\t份额：{3}%",
                    p.UserName,p.AllTurnIn.ToString("F2"), p.Amount.ToString("F2"), (p.Perc * 100).ToString("F2")));
            });
            sb.AppendLine("----------------------------------------------------------------------------------------");
            sb.AppendLine(String.Format("总计：\t\t总投入：{0}\t最新净值：{1}\t份额：100%", listShare.Sum(p => p.AllTurnIn).ToString("F2"), listShare.Sum(p => p.Amount).ToString("F2")));

            return sb.ToString();
        }
    }
}
