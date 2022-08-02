using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryApp.Models.Request
{
    public class DrawInfoRequest
    {
        public DrawInfoRequest()
        {
            this.n = 48;
            this.r = 6;
            this.m = 6;
        }
        [Required(ErrorMessage = "Please Enter The Total Balls")]
        public int n { get; set; }
        [Required(ErrorMessage = "Please Enter The Draw Balls")]
        public int r { get; set; }
        [Required(ErrorMessage = "Please Enter The Pool Balls")]
        public int m { get; set; }
    }
}
