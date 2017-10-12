using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

namespace WebSample.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            await Task.FromResult(true);
            return Ok(new string[] { "value1", "value2" });
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, string param1, string param2)
        {
            await Task.FromResult(true);
            return Ok($"values {id}, {param1}, {param2}");
        }

        // POST api/values
        [HttpPost]
        public async Task<IActionResult> Post(string id, [FromBody]string value)
        {
            await Task.FromResult(true);
            return Ok($"values {id}, {value}");
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]string value)
        {
            await Task.FromResult(true);
            return Ok($"values {id}, {value}");
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, [FromBody]string value)
        {
            await Task.FromResult(true);
            return Ok($"values {id}, {value}");
        }
    }
}
