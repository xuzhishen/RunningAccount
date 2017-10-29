using RunningAccount.Core;
using RunningAccount.Core.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAccount.SimpleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RAManager raManage = new RAManager();

            while (true)
            {
                Console.WriteLine("1 添加用户,2 添加资金记录,3 显示所有用户列表, 4 显示所有资金记录");
                char c = Console.ReadKey().KeyChar;
                if (c == '1')
                {
                    Console.WriteLine();
                    Console.WriteLine("请输入用户ID");
                    String userId = Console.ReadLine();

                    Console.WriteLine("请输入用户名称");
                    String userName = Console.ReadLine();

                    raManage.AddUser(userId, userName);

                    Console.WriteLine("用户 {0}\t{1}添加完成", userId, userName);
                }
                else if (c == '2')
                {
                    Console.WriteLine();
                    Console.WriteLine("请输入用户ID");
                    String userId = Console.ReadLine();

                    Console.WriteLine("请输入帐号类型：转入 1,转出 2,盈利 3,亏损 4,费用 5,新估值 6");
                    RATypeEnum raType = (RATypeEnum)int.Parse(Console.ReadLine());

                    Console.WriteLine("请输入金额");
                    decimal amount = Decimal.Parse(Console.ReadLine());

                    Console.WriteLine("请输入时间");
                    DateTime dateTime = DateTime.Parse(Console.ReadLine());

                    raManage.AppendRecord(userId, raType, amount, dateTime);

                    Console.WriteLine("记录 {0}\t{1}\t{2}\t{3} 添加完成", userId, raType, amount, dateTime);
                }
                else if (c == '3')
                {
                    Console.WriteLine();
                    raManage.getUsers().ForEach(p =>
                        Console.WriteLine("{0}\t{1}", p.UserID, p.UserName)
                    );
                }
                else if (c == '4')
                {
                    Console.WriteLine();
                    raManage.getRecord().ForEach(p =>
                          Console.WriteLine("{0}\t{1}\t{2}\t{3}", p.UserID, p.RAType, p.Amount, p.AddTime)
                      );
                }
            }
        }
    }
}
