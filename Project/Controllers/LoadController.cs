using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Project.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoadController : Controller
    {
        private readonly string filePath;
        public LoadController(string filePath)
        {
            this.filePath = filePath;
        }

        public IActionResult Index() => View();

        // GET: /<LoadController>
        [HttpGet]
        [Route("download")] 
        public FileContentResult Download()
        {
            return File(System.IO.File.ReadAllBytes(filePath), "application/octet-stream", "Haggard - Menuetto in fa-minore.mp3");
        }
         
        [HttpPost]
        public IActionResult Upload(IFormFile file)
        {
            using (var stream = new FileStream(Path.Combine("D:\\MediaStorage\\MediaDB\\content\\audio", file.Name+".mp3"),
                                    FileMode.Create, FileAccess.Write))
            {
                file.CopyTo(stream);
            }
            return RedirectToAction("Index", "Home");
        }

    }
}
