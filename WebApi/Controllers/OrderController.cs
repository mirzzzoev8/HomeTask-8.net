using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly OrderServices _orcontroller;
    public OrderController()
    {
        _orcontroller = new OrderServices();
    }
    [HttpPost("add - order")]
    public void AddOrder(Orders orders)
    {
        _orcontroller.AddValues(orders);
    }
    [HttpGet("get-orders")]
    public List<Orders> GetOrders()
    {
        return _orcontroller.GetValues();
    }
    [HttpGet("get-orders by total amount")]
    public List<Orders> GetOrdersByTotalAmount(decimal amount)
    {
        return _orcontroller.GetOrdersByTotalAmount(amount);
    }
    [HttpGet("get-orders by orderdetail")]
    public List<OrderDetail> GetOrdersByOrderDeatail()
    {
        return _orcontroller.GetOrderDetails();
    }
    [HttpPut("update-orders")]
    public void UpdateOrders(Orders orders)
    {
        _orcontroller.UpdateValues(orders);
    }
    [HttpDelete("delete-orders")]
    public void DeleteOrders(int id)
    {
        _orcontroller.DeleteValues(id);
    } 
}
