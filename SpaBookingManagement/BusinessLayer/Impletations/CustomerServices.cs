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
    public class CustomerServices : ICustomerServices
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;
        public CustomerServices(ICustomerRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<CustomerDto>> GetAll() =>
       _mapper.Map<IEnumerable<CustomerDto>>(await _repository.GetAll());

        public async Task<CustomerDto> GetById(int id) =>
            _mapper.Map<CustomerDto>(await _repository.GetById(id));

        public async Task Add(CustomerDto customerDto)
        {
            var cust = _mapper.Map<Customer>(customerDto);
            await _repository.Add(cust);
        }

      
        public async Task Update(CustomerDto customerDto)
        {
            var cust = _mapper.Map<Customer>(customerDto);
            await _repository.Update(cust);
        }
        public async Task Delete(int id) => await _repository.Delete(id);
    }
}

