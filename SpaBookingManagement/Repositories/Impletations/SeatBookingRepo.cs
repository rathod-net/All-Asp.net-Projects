using DataModel.DbContextEntity;
using DataModel.Entites;
using Microsoft.EntityFrameworkCore;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Impletations
{
    public class SeatBookingRepo : ISeatBookingRepo
    {
        private readonly ApplicationDbContext _context;
        public SeatBookingRepo(ApplicationDbContext context) 
        {
            _context = context;
        }
        public async Task<IEnumerable<SeatBooking>> GetAll() => await _context.SeatBookings.ToListAsync();
        public async Task<SeatBooking> GetById(int id) => await _context.SeatBookings.FindAsync(id);
        public async Task Add(SeatBooking seatBooking)
        {
            await _context.SeatBookings.AddAsync(seatBooking);
            await _context.SaveChangesAsync();
        }
        public async Task Update(SeatBooking seatBooking)
        {
            _context.SeatBookings.Update(seatBooking);
            await _context.SaveChangesAsync();
        }
        public async Task Delete(int id)
        {
            var entity = await _context.SeatBookings.FindAsync(id);
            if (entity != null)
            {
                _context.SeatBookings.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
