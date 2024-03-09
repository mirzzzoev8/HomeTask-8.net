using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class CustomerController : ControllerBase
{
    private readonly CustomerServices _cuscontroller;
    public CustomerController()
    {
        _cuscontroller = new CustomerServices();
    }
    [HttpPost("add - customer")]
    public void AddCustomers(Customers customers)
    {
        _cuscontroller.AddValues(customers);
    }
    [HttpGet("get-customers")]
    public List<Customers> GetCustomers()
    {
        return _cuscontroller.GetValues();
    }
    [HttpGet("get-customers - by orderdate")]
    public List<Customers> GetCustomersByOrderDate(DateTime startDate,DateTime endDate)
    {
        return _cuscontroller.GetCustomersByOrderDate(startDate,endDate);
    }
    [HttpGet("get-customers - by product name")]
    public List<Customers> GetCustomersByProductName()
    {
        return _cuscontroller.GetCustomersByProductname();
    }
    [HttpPut("update-customers")]
    public void UpdateCustomers(Customers customers)
    {
        _cuscontroller.UpdateValues(customers);
    }
    [HttpDelete("delete-customers")]
    public void DeleteCustomers(int id)
    {
        _cuscontroller.DeleteValues(id);
    } 

}
