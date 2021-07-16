using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson1.Controllers
{

    /// <remarks>
    /// Запросы для Postman
    /// 
    /// https://localhost:44310/api/mycontroller/read?fromDate=01.07.2021&toDate=30.07.2021
    /// https://localhost:44310/api/mycontroller/update?date=20.07.2021&newValue=22
    /// https://localhost:44310/api/mycontroller/save?date=14.07.2021&input=15
    /// https://localhost:44310/api/mycontroller/delete?fromDate=20.07.2021&toDate=21.07.2021
    /// </remarks>

    [Route("api/[controller]")]
    [ApiController]
    public class MyControllerController : ControllerBase
    {
        private readonly DateTemperatureHolder _holder;

        public MyControllerController(DateTemperatureHolder holder)
        {
            _holder = holder;
        }



        [HttpGet("read")]
        public IActionResult Read(string fromDate, string toDate)
        {
            if (DateTime.TryParse(fromDate, out DateTime fromD) &&
                DateTime.TryParse(toDate, out DateTime toD))
            {
            return Ok(_holder.Get(fromD.Date, toD.Date));
            }

            return ValidationProblem();
        }

        [HttpPost("save")]
        public IActionResult Save([FromQuery] string date, [FromQuery] double input)
        {
            if (DateTime.TryParse(date, out DateTime d))
            {
                _holder.Save(d.Date, input);
            }
            
            return Ok();
        }

        /// <remarks>
        /// Дату передаю строкой, т.к. конструктор DateTime не может правильно вытянуть 
        /// из запроса аргументы для конструктора DateTime и выдает ошибку 405
        /// </remarks>
       
        [HttpPut("update")]
        public IActionResult Update([FromQuery] string date, [FromQuery] double newValue)
        {
            if (DateTime.TryParse(date, out DateTime d))
            {
                if (_holder.DatesTemperatures.ContainsKey(d.Date))
                {
                    _holder.Update(d.Date, newValue);
                }
            }

            return Ok();
        }

        [HttpDelete("delete")]
        public IActionResult Delete(string fromDate, string toDate)
        {
            if (DateTime.TryParse(fromDate, out DateTime f) && DateTime.TryParse(toDate, out DateTime t))
            {
                _holder.Delete(f.Date, t.Date);
            }
            else
            {
                return ValidationProblem();
            }
            return Ok();
        }
    }
}
