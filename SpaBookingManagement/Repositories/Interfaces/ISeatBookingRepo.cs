using DataModel.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Interfaces
{
    public interface ISeatBookingRepo
    {
        Task<IEnumerable<SeatBooking>> GetAll();
        Task<SeatBooking> GetById(int id);
        Task Add(SeatBooking seatBooking);
        Task Update(SeatBooking seatBooking);
        Task Delete(int id);
    }
}
