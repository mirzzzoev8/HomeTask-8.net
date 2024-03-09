using Domain.Models;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class ProductController : ControllerBase
{
    private readonly ProductServices _prcontroller;
    public ProductController()
    {
        _prcontroller = new ProductServices();
    }
    [HttpPost("add - product")]
    public void AddProduct(Products products)
    {
        _prcontroller.AddValues(products);
    }
    [HttpGet("get-products")]
    public List<Products> GetProducts()
    {
        return _prcontroller.GetValues();
    }
    
    [HttpPut("update-products")]
    public void UpdateProducts(Products products)
    {
        _prcontroller.UpdateValues(products);
    }
    [HttpDelete("delete-products")]
    public void DeleteProducts(int id)
    {
        _prcontroller.DeleteValues(id);
    } 
}

