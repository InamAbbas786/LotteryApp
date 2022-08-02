using LotteryApp.Helpers;
using LotteryApp.IServices;
using LotteryApp.Models.Request;
using LotteryApp.Models.Response;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Threading.Tasks;

namespace Lottery.Core.App.Dao
{
    public class Lotteries : ILotteries
    {
        public Result LotteryWinningOddNumbers(DrawInfoRequest Info)
        {
            try
            {
                List<DrawInfoResponse> drawInfoResponse = new List<DrawInfoResponse>();
                int r = Info.r;
                int n = Info.n;
                int m = Info.m;
                double CalculateOdds = 0;
                for (int i = Info.r; i >= 1; i--)
                {
                    m = i;
                    double Numerator = Calculator.C(n, r);
                    double Denominator = (Calculator.C(r, m) * Calculator.C(n - r, r - m));
                    CalculateOdds = Numerator / (Denominator == 0 ? 1 : Denominator);
                    drawInfoResponse.Add(new DrawInfoResponse { Key = i, Values = CalculateOdds });
                }
                if (drawInfoResponse.Count > 0)
                    return new Result() { Data = drawInfoResponse, Status = Status.Success, Message = "" };
                else
                    return new Result() { Data = new List<DrawInfoResponse>(), Status = Status.Warring, Message = "Data Not Found" };
            }
            catch (Exception ex)
            {
                return new Result() { Data = new List<DrawInfoResponse>(), Status = Status.Error, Message = ex.Message };
            }
        }
    }
}


