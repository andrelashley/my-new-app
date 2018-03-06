using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Models;
using ViewModels;

namespace my_new_app.Controllers
{
    [Route("api/[controller]")]
    public class SampleDataController : Controller
    {
        private DataAccess db;

        public SampleDataController(DataAccess db)
        {
            this.db = db;
        }

        [HttpGet("create")]
        public IActionResult CreateWidget(string name) {
            Models.Widget widget = new Models.Widget();
            widget.Name = name;
            db.CreateWidget(widget);

            return new ObjectResult(widget);
        }

        [HttpGet("[action]")]
        public IEnumerable<WeatherForecast> WeatherForecasts()
        {
            var rng = new Random();

            var data = db.GetWidgets();
            var viewModels = new List<ViewModels.Widget>();
            data.ForEach(x => viewModels.Add(x.ToViewModel()));

            var names = new List<string>();
            viewModels.ForEach(x => names.Add(x.Name));

            string[] summaries = names.ToArray();

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                DateFormatted = DateTime.Now.AddDays(index).ToString("d"),
                TemperatureC = rng.Next(-20, 55),
                Summary = summaries[rng.Next(summaries.Length)]
            });
        }

        public class WeatherForecast
        {
            public string DateFormatted { get; set; }
            public int TemperatureC { get; set; }
            public string Summary { get; set; }

            public int TemperatureF
            {
                get
                {
                    return 32 + (int)(TemperatureC / 0.5556);
                }
            }
        }
    }
}
