using AutoMapper;
using DataModel.Entites;
using Dto;
using Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ICustomerServices
    {
        Task<IEnumerable<CustomerDto>> GetAll();
        Task<CustomerDto> GetById(int id);
        Task Add(CustomerDto customer);
        Task Update(CustomerDto customer);
        Task Delete(int id);

    }
}
