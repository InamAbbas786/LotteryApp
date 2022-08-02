using LotteryApp.IServices;
using LotteryApp.Models.Request;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryApp.Controllers
{
    public class LotteriesController : Controller
    {
       private readonly ILotteries _Lotteries;
        public LotteriesController(ILotteries Lotteries)
        {
            _Lotteries = Lotteries;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Lottery()
        {
            DrawInfoRequest drawInfo = new DrawInfoRequest();
            drawInfo.n = 48;
            drawInfo.r = 6;
            drawInfo.m = 6;
            return View(drawInfo);
        }

        [HttpPost]
        public IActionResult GetLottery(DrawInfoRequest drawInfo)
        {          
            var result = _Lotteries.LotteryWinningOddNumbers(drawInfo);
            return PartialView(result.Data);
        }
    }
}
