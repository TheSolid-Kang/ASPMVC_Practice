using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Newtonsoft.Json;

namespace ASPMVC_Practice.Controllers
{
    public class BaseController<T> : Controller
    {
        protected readonly ILogger<T> _logger;

        public BaseController(ILogger<T> logger)
        {
            _logger = logger;
        }
        /*
        /// <summary>
        /// Puts an object into the TempData by first serializing it to JSON.
        /// </summary>
        /// <typeparam name="V"></typeparam>
        /// <param name="tempData"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        protected static void Put<V>(this ITempDataDictionary tempData, string key, V value) where V : notnull
        {
            tempData[key] = JsonConvert.SerializeObject(value);
        }

        /// <summary>
        /// Gets an object from the TempData by deserializing it from JSON.
        /// </summary>
        /// <typeparam name="V"></typeparam>
        /// <param name="tempData"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        protected static V Get<V>(this ITempDataDictionary tempData, string key) 
        {
            object o;
            tempData.TryGetValue(key, out o);
            return (o == null) ? default(V) : JsonConvert.DeserializeObject<V>((string)o);
        }
        */
    }
}
