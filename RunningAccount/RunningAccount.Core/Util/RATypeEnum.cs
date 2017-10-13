using System;
using System.Collections.Generic;
using System.Text;

namespace RunningAccount.Core.Util
{
    /// <summary>
    /// 动账类型
    /// </summary>
    public enum RATypeEnum
    {
        /// <summary>
        /// 转入
        /// </summary>
        TurnIn = 1,

        /// <summary>
        /// 转出
        /// </summary>
        TurnOut = 2,

        /// <summary>
        /// 盈利
        /// </summary>
        Profit = 3,

        /// <summary>
        /// 亏损
        /// </summary>
        Loss = 4,

        /// <summary>
        /// 费用
        /// </summary>
        Fee = 5
    }
}
