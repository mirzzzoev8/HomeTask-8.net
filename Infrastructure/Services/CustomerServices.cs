using Dapper;
using Domain.Models;
using Infrastructure.DataContext;
using Infrastructure.Interface;

namespace Infrastructure.Services;

public class CustomerServices : Interface<Customers>
{
    private readonly DapperContext _context;
    public CustomerServices()
    {
        _context = new DapperContext();
    }
    public void AddValues(Customers customers)
    {
        var sql = "insert into customers (Customer_Name,Email,Address) values (@Customer_Name,@Email,@Address)";
        _context.Connection().Execute(sql,customers);
    }

    public void DeleteValues(int id)
    {
        var sql = "delete from customers where id = @id";
        _context.Connection().Execute(sql, new {Id = id});
    }


    public void UpdateValues(Customers customers)
    {
        var sql = "update customers set Customer_Name = @Customer_Name, Email = @Email, Address = @Address, where id = @id";
        _context.Connection().Execute(sql , customers); 
    }


    public List<Customers> GetValues()
    {
        var sql = "select * from customers";
        return _context.Connection().Query<Customers>(sql).ToList();
    }
    public List<Customers> GetCustomersByProductname()
    {
        var sql = @"SELECT o.order_id, p.product_name, od.quantity, od.price
            FROM Orders o
            JOIN OrderDetails od ON o.order_id = od.order_id
            JOIN Products p ON od.product_id = p.product_id";
        return _context.Connection().Query<Customers>(sql).ToList();
        
    }
    public List<Customers> GetCustomersByOrderDate(DateTime startDate, DateTime endDate)
{
        var sql = "select C.customer_id, C.customer_name, C.email, C.address " +
                  "from Customers as C " +
                  "join Orders as O on C.customer_id = O.customer_id " +
                  "where O.order_date >= @StartDate and O.order_date <= @EndDate";
        return _context.Connection().Query<Customers>(sql, new { StartDate = startDate, EndDate = endDate }).ToList();
        
}
}
