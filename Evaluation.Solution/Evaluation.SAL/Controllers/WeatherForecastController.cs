using Microsoft.AspNetCore.Mvc;

namespace Evaluation.SAL.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        //private static readonly string[] Summaries = new[]
        //{
        //    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"

        //};

        //private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 1).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}


        //[HttpGet]
        //public IActionResult ChechUserCred()
        //{

        //    var resp = InstManagerAccessPoint.GetNewAccessPoint().CheckUserCred("AdminUser", "AdminUser@Test123");
        //    if (resp != null && resp.Count == 1 && resp[0].TotalCount == 1)
        //    {
        //       // 
        //    }
        //    else
        //    {
        //       //
        //    }
        //    return NoContent();
        //    // UserCredDao t = new UserCredDao();
        //    //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
