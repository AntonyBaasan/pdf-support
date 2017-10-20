using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PdfManager.Services;

namespace webapi.Controllers
{
    [Route("api/[controller]")]
    public class PdfManagerController : Controller
    {
        [HttpGet]
        public string Get()
        {
            var pdfMergeService = new PdfMergeService();
            return pdfMergeService.MergeFiles(new string[] { "" });
        }

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> UploadAsync(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            // full path to file in temp location
            // var filePath = Path.GetTempFileName();
            var filePath = GetAppTempDirectory();

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var fileFullName = Path.Combine(filePath, formFile.FileName);
                    using (var stream = new FileStream(fileFullName, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            // process uploaded files
            // Don't rely on or trust the FileName property without validation.
            return Ok(new { count = files.Count, size, filePath });
        }

        private string GetAppTempDirectory(){
            var filePath = Directory.GetCurrentDirectory();
            filePath = Directory.GetParent(filePath).FullName;
            filePath = Path.Combine(filePath, "temp");
            if(!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            return filePath;
        }
    }
}