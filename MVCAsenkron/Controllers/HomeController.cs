using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace MVCAsenkron.Controllers
{
    public class HomeController : AsyncController
    {
        public async Task<ActionResult> Index()
        {
            int tid = System.Threading.Thread.CurrentThread.ManagedThreadId;
            var data = GetCurrenciesAsnyc();

            return  View();
        }

        public async Task<string> GetCurrenciesAsnyc()
        {
            WebClient client = new WebClient();
            var exchange = await client.DownloadStringTaskAsync("http://polynomtech.com/");
            int tid2 = System.Threading.Thread.CurrentThread.ManagedThreadId;
            return exchange;
        }
    }
}