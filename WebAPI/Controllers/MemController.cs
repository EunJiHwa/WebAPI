using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication3.Controllers
{
    public class MemController : Controller
    {
        private IMemoryCache memoryCache;

        public MemController(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            DateTime currentTime;
            bool AlreadyExit = memoryCache.TryGetValue("CachedTime", out currentTime);
            if (!AlreadyExit)
            {
                currentTime = DateTime.Now;
                var cacheEntryOptions = new MemoryCacheEntryOptions().
                    SetSlidingExpiration(TimeSpan.FromSeconds(20));
                memoryCache.Set("CacheTime", currentTime, cacheEntryOptions);

            }
            return View();
        }
    }
}
