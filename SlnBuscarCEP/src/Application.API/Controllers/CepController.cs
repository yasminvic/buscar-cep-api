using Microsoft.AspNetCore.Mvc;

namespace Application.API.Controllers
{
    public class CepController : Controller
    {
        [HttpGet]
        public async Task<ActionResult> ProcuraCep()
        {
            return View();
        }
    }
}
