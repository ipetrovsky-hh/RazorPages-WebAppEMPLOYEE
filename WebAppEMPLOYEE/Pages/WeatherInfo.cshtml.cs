using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebAppEMPLOYEE.Pages
{
    public class WeatherInfoModel : PageModel
    {
        private readonly ILogger<WeatherInfoModel> _logger;

        public WeatherInfoModel(ILogger<WeatherInfoModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
