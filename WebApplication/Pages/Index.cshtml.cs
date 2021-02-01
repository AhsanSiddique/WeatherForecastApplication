using BusinessLogic.Weather;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using ViewModels.WeatherModels;

namespace WebApplication.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IWeatherBLL _weatherBLL;
        public IEnumerable<WeatherForecastModel.Period> Forecast { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IWeatherBLL weatherBLL)
        {
            _logger = logger;
            _weatherBLL = weatherBLL;
        }
        //4600 Silver Hill Rd, Suitland, MD 20746
        public void OnGet()
        {
            Forecast = new List<WeatherForecastModel.Period>();
            var response = _weatherBLL.GetWeatherDetails(SearchTerm);
            if (response != null)
            {
                if (response.properties != null)
                {
                    Forecast = response.properties.periods;
                }
            }
        }
    }
}
