using BusinessLayer.Interfaces;
using Dto;
using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeatBookingController : ControllerBase
    {
        private readonly ISeatBookingServices _services;

        public SeatBookingController(ISeatBookingServices services)
        {
            _services = services;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() => Ok(await _services.GetAll());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id) => Ok(await _services.GetById(id));

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] SeatBookingDto dto)
        {
            if(ModelState.IsValid)
            {
                 await _services.Add(dto);
                return CreatedAtAction(nameof(GetById), new { id = dto.Id }, dto);
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] SeatBookingDto dto)
        {
            await _services.Update(dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _services.Delete(id);
            return NoContent();
        }
    }
}
