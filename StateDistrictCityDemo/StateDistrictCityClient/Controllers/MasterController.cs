using Microsoft.AspNetCore.Mvc;
using StateDistrictCityClient.Services;

namespace StateDistrictCityClient.Controllers
{
    public class MasterController : Controller
    {
        private readonly MasterServices _masterServices;
         
        public MasterController(MasterServices masterServices)
        {
            _masterServices = masterServices;
        }
        public IActionResult Index()
        {
            
            return View();
        }
        public async Task<JsonResult> GatState()
        {
            var stateList = await _masterServices.GetStatesAsync();
            return Json(stateList);
        }

    }
}
