using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RunningAccount.SimpleCore.Entity
{
    public class Result
    {
        public bool Sucess { get; set; }

        public string Message { get; set; }

        public static Result OK() {
            return new Result() { Sucess = true }; 
        }

        public static Result Fail(String errMessage) {
            return new Result() { Message = errMessage };
        }
    }
}
