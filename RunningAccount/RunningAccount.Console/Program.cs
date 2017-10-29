using RunningAccount.Core;
using System;

namespace RunningAccount.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            RAManager raManage = new RAManager();

            while (true) {

                Console.WriteLine("1 输入用户，2 输入资金记录");
                if (Console.ReadKey().KeyChar == '1')
                {
                    Console.WriteLine("请输入用户ID");
                    String userId = Console.ReadLine();

                    Console.WriteLine("请输入用户名称");
                    String userName = Console.ReadLine();

                    raManage.AddUser(userId, userName);
                }
                else if (Console.ReadKey().KeyChar == '2') {
                    continue;
                }
            }
        }
    }
}