using DCDomain.Data;
using DCDomain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using DCWebAPI.ViewModels;

namespace DCWebAPI.Controllers
{
    [Route("[controller]")]
    public class CustomerController : MainController
    {
        private readonly ICustomerData _customerData;
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerData customerData, IUnitOfWork uow, IMapper mapper)
        {
            _customerData = customerData;
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerViewModel>> Get()
        {
            return _mapper.Map<IEnumerable<CustomerViewModel>>(await _customerData.GetAll());
        }

        [HttpGet("{id:guid}")]
        public async Task<CustomerViewModel> Get(Guid id)
        {
            return _mapper.Map<CustomerViewModel>(await _customerData.GetById(id));
        }

        [HttpGet("{email}")]
        public async Task<CustomerViewModel> Get(string email)
        {
            return _mapper.Map<CustomerViewModel>(await _customerData.GetByEmail(email));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            _uow.BeginTransaction();
            await _customerData.Add(_mapper.Map<Customer>(customerViewModel));
            _uow.Commit();

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] CustomerViewModel customerViewModel)
        {
            if (!ModelState.IsValid)
                return CustomResponse(ModelState);

            _uow.BeginTransaction();
            await _customerData.Update(_mapper.Map<Customer>(customerViewModel));
            _uow.Commit();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var customer = await _customerData.GetById(id);

            if (customer == null)
                return NotFound();

            _uow.BeginTransaction();
            await _customerData.Remove(customer.Id);
            _uow.Commit();

            return Ok();
        }
    }
}
