using System;
using System.IO;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

namespace WebSample.Controllers
{
    [Route("api/Upload")]
    public class UploadController : Controller
    {
        private IHostingEnvironment _hostingEnvironment = null;

        public UploadController(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        // POST api/upload
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id)
        {
            string fileName = Path.Combine(_hostingEnvironment.WebRootPath, "Images", $"{id}.jpg");
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                await Request.Body.CopyToAsync(stream);
            }
            return Ok();
        }
    }
}
