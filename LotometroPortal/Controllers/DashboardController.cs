using LotometroPortal.Entities;
using LotometroPortal.Models;
using Microsoft.AspNetCore.Mvc;

namespace LotometroPortal.Controllers
{
    [Route("[controller]")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View(EntitiesHelperClass.GetAuthObj());
        }

        [HttpGet, Route("GetCameraInfo")]
        public LeituraCamera GetCameraInfo()
        {
            return ApiHelperClass.GetCameraInfo(1, 1);
        }
    }
}
