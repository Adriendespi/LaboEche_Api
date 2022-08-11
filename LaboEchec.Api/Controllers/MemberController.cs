using Microsoft.AspNetCore.Mvc;

namespace LaboEchec.Api.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
