using Microsoft.AspNetCore.Mvc;

namespace ASPMVC_Practice.Controllers
{
    public class BaseController<T> : Controller
    {
        protected readonly ILogger<T> _logger;

        public BaseController(ILogger<T> logger)
        {
            _logger = logger;
        }

    }
}
