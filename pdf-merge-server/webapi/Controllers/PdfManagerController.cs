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

    }
}