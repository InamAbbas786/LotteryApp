using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryApp.Helpers
{
    public struct Result 
    { 
        public dynamic Data { get; set; }
        public string Message { get; set; }
        public Status Status { get; set; }
    }
}
