using Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ISeatBookingServices
    {
        Task<IEnumerable<SeatBookingDto>> GetAll();
        Task<SeatBookingDto> GetById(int id);
        Task Add(SeatBookingDto seatBookingDto);
        Task Update(SeatBookingDto seatBookingDto);
        Task Delete(int id);
    }
}
