using Dapper;
using Domain.Models;
using Infrastructure.DataContext;
using Infrastructure.Interface;

namespace Infrastructure.Services;
public class ProductServices : Interface<Products>
{
    private readonly DapperContext _context;
    public ProductServices()
    {
        _context = new DapperContext();
    }
    public void AddValues(Products products)
    {
        var sql = "insert into products (Product_Name,Price,Quantity) values (@Product_Name,@Price,@Quantity)";
        _context.Connection().Execute(sql,products);
    }

    public void DeleteValues(int id)
    {
        var sql = "delete from products where id = @id";
        _context.Connection().Execute(sql, new {Id = id});
    }


    public void UpdateValues(Products products)
    {
        var sql = "update products set Product_Name = @Product_Name, Price = @Price, Quantity = @Quantity, where id = @id";
        _context.Connection().Execute(sql , products); 
    }


    public List<Products> GetValues()
    {
        var sql = "select * from products";
        return _context.Connection().Query<Products>(sql).ToList();
    }
}
