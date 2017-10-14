using System;
using System.Net;
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
            return Ok();
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id, string param1, string param2)
        {
            if (id == 0)
            {
                return StatusCode((int)HttpStatusCode.BadRequest, "Id cannot be zero.");
            }

            await Task.FromResult(true);
            return Ok($"values {id}, {param1}, {param2}");
        }

        // POST api/values
        [HttpPost("{id}")]
        public async Task<IActionResult> Post(int id, [FromBody]MyClass value)
        {
            await Task.FromResult(true);
            value.Id = id;
            return Ok(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody]MyClass value)
        {
            await Task.FromResult(true);
            value.Id = id;
            return Ok(value);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Task.FromResult(true);
            return Ok();
        }
    }

    public class MyClass
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public override string ToString()
        {
            return $"[Id = {Id}, Name = {Name}]";
        }
    }
}
