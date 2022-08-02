using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LotteryApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        
        [HttpGet]
        [Route("GetData")]
        public IEnumerable<BookingGrouping> GetData()
        {
            List<Booking> bookings = new List<Booking>()
            {
             new Booking()  {Project="HR", Date=Convert.ToDateTime("01/02/2020") , Allocation= 10},
             new Booking()  {Project="CRM", Date =Convert.ToDateTime("01/02/2020") , Allocation= 15},
             new Booking()  {Project="HR", Date=Convert.ToDateTime("02/02/2020") , Allocation= 10},
             new Booking()  {Project="CRM", Date=Convert.ToDateTime("02/02/2020") , Allocation= 15},
             new Booking()  {Project="HR", Date=Convert.ToDateTime(" 03/02/2020") , Allocation= 15},
             new Booking()  {Project="CRM", Date=Convert.ToDateTime("03/02/2020") , Allocation= 15},
             new Booking()  {Project="HR", Date=Convert.ToDateTime("04/02/2020") , Allocation= 15},
             new Booking()  {Project="CRM", Date=Convert.ToDateTime("04/02/2020") , Allocation= 15},
             new Booking()  {Project="HR", Date=Convert.ToDateTime("05/02/2020") , Allocation= 15},
             new Booking()  {Project="CRM", Date = Convert.ToDateTime("05/02/2020") , Allocation= 15},
             new Booking()  {Project="ECom", Date=Convert.ToDateTime("05/02/2020") , Allocation= 15},
             new Booking()  {Project="ECom", Date = Convert.ToDateTime("06/02/2020") , Allocation= 10},
             new Booking()  {Project="CRM", Date = Convert.ToDateTime("06/02/2020") , Allocation= 15},
             new Booking()  {Project="ECom", Date = Convert.ToDateTime("07/02/2020") , Allocation= 10},
             new Booking()  {Project="CRM", Date = Convert.ToDateTime("07/02/2020") , Allocation= 15}
            };
            var groupings = bookings
                            .OrderBy(x => x.Date)
                            .GroupBy(x => x.Date.ToString("yyyy-MM"))
                            .Select(g => new BookingGrouping
                            {
                                From = g.Min(x => x.Date),
                                To = g.Max(x => x.Date),
                                Items = g.Select(x => new BookingGroupingItem() {Project= x.Project,Allocation= x.Allocation }).ToList()
                            }).ToList();
            return groupings;
        }
    }
    public class Booking
    {
        public string Project { get; set; }
        public DateTime Date { get; set; }
        public decimal Allocation { get; set; }
    }
    public class BookingGroupingItem
    {
        public string Project { get; set; }
        public decimal Allocation { get; set; }
    }
    public class BookingGrouping
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public List<BookingGroupingItem> Items { get; set; }
    }
}
