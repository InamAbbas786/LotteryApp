using LotteryApp.Helpers;
using LotteryApp.Models.Request;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryApp.IServices
{
    public interface ILotteries
    {
        public Result LotteryWinningOddNumbers(DrawInfoRequest Info);
    }
}
