using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StateDistrictCityMasterApi.Model;
using System.Security.AccessControl;

namespace StateDistrictCityMasterApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public MasterController(ApplicationDbContext context)       
        {
            _context = context;
        }

        [HttpGet("GetAllState")]
        public IActionResult GetAllState()
        {
            var stateList = _context.States.ToList();
            return Ok(stateList);
        }

        [HttpGet("GetAllDirstictByStateId")]
        public IActionResult GetAllDirstictByStateId(int stateId)
        {
            var dirstictList = _context.Districts.Where(d=>d.StateId == stateId).ToList();
            return Ok(dirstictList);
        }
        [HttpGet("GetAllCityByDistrictId")]
        public IActionResult GetAllCityByDistrictId(int districtId)
        {
            var cityList = _context.Citys.Where(c => c.DistrictId == districtId).ToList();
            return Ok(cityList);
        }
    }
}
