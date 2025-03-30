using AutoMapper;
using BusinessLayer.Interfaces;
using DataModel.Entites;
using Dto;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Impletations
{
    public class SeatBookingServices :ISeatBookingServices
    {
        private readonly ISeatBookingRepo _repository;
        private readonly IMapper _mapper;
        public SeatBookingServices(ISeatBookingRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<SeatBookingDto>> GetAll() =>
       _mapper.Map<IEnumerable<SeatBookingDto>>(await _repository.GetAll());

        public async Task<SeatBookingDto> GetById(int id) =>
            _mapper.Map<SeatBookingDto>(await _repository.GetById(id));

        public async Task Add(SeatBookingDto seatBookingDto)
        {
            var seatBooking = _mapper.Map<SeatBooking>(seatBookingDto);
            await _repository.Add(seatBooking);
             _mapper.Map<SeatBookingDto>(seatBooking);
        }
        public async Task Update(SeatBookingDto seatBookingDto)
        {
            var seatBooking = _mapper.Map<SeatBooking>(seatBookingDto);
            await _repository.Update(seatBooking);
        }
        public async Task Delete(int id) => await _repository.Delete(id);
    }
}
