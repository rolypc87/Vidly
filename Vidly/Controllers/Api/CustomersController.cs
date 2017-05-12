using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
	public class CustomersController : ApiController
	{
		private ApplicationDbContext _context;

		public CustomersController()
		{
			_context = new ApplicationDbContext();
		}

		//Get /api/Customers
		public IHttpActionResult GetCustomers()
		{
			var customersDtos = _context.Customers
				.Include(c => c.MembershipType)
				.ToList()
				.Select(Mapper.Map<Customer,CustomerDto>);
			return Ok(customersDtos);
		}

		//Get /api/Customers/1
		[HttpGet]
		public IHttpActionResult GetCustomer(int id)
		{
			var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
			if (customer == null)
				return NotFound();
			return Ok(Mapper.Map<Customer,CustomerDto>(customer));
		}
		// POST /api/customers
		[HttpPost]
		public IHttpActionResult CreateCustomer(CustomerDto customerDto)
		{
			if (!ModelState.IsValid)
				return BadRequest();
			var customer = Mapper.Map<CustomerDto,Customer>(customerDto);
			_context.Customers.Add(customer);
			_context.SaveChanges();
			Mapper.Map(customer, customerDto);
			return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
		}
		// PUT /api/customers/1
		[HttpPut]
		public void UpdateCustomer(int id , CustomerDto customerDto)
		{
			if(!ModelState.IsValid)
				throw new HttpResponseException(HttpStatusCode.BadRequest);
			var customerInDb = _context.Customers.SingleOrDefault(c=>c.Id==id);

			if(customerInDb==null)
				throw new HttpResponseException(HttpStatusCode.NotFound);
			Mapper.Map(customerDto, customerInDb);// i don't need to declare it like this(Mapper.Map<CustomerDto,Customer>(customerDto, customerInDb)) because the compiler automaticaly maps this <CustomerDto,Customer> with the parameters

			_context.SaveChanges();
		}

		//DELETE /api/customers/1
		[HttpDelete]
		public void DeleteCustomer(int id)
		{
			var customerInDb = _context.Customers.SingleOrDefault(c=>c.Id==id);

			if(customerInDb==null)
				throw new HttpResponseException(HttpStatusCode.NotFound);

			_context.Customers.Remove(customerInDb);
			_context.SaveChanges();
		}
	}
}
