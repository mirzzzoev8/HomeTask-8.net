using Dapper;
using Domain.Models;
using Infrastructure.DataContext;
using Infrastructure.Interface;

namespace Infrastructure.Services;

public class OrderServices : Interface<Orders>
{
    private readonly DapperContext _context;
    public OrderServices()
    {
        _context = new DapperContext();
    }
    public void AddValues(Orders orders)
    {
        var sql = "insert into orders (Customer_Id,Order_Date,Amount) values (@Customer_Id,@Order_Date,@Amount)";
        _context.Connection().Execute(sql,orders);
    }

    public void DeleteValues(int id)
    {
        var sql = "delete from orders where id = @id";
        _context.Connection().Execute(sql, new {Id = id});
    }
    public List<Orders> GetOrdersByTotalAmount(decimal amount)
    {
        var sql = "select O.order_id, O.order_date, O.amount, C.customer_id, C.customer_name " +
                  "from Orders as O " +
                  "join Customers as C on O.customer_id = C.customer_id " +
                  "where O.amount > @Amount";
        var result = _context.Connection().Query<Orders>(sql, new { Amount = amount }).ToList();
        return result;
    
    }
    public List<OrderDetail> GetOrderDetails()
    {
        var sql = "select O.order_id, P.product_name, OD.quantity, OD.unit_price " +
                  "from Orders as O " +
                  "join OrderDetails as OD on O.order_id = OD.order_id " +
                  "join Products as P on OD.product_id = P.product_id";
        return _context.Connection().Query<OrderDetail>(sql).ToList();
    }

    public void UpdateValues(Orders orders)
    {
        var sql = "update orders set Customer_Id = @Customer_Id, Order_Date = @Order_Date, Amount = @Amount, where id = @id";
        _context.Connection().Execute(sql , orders); 
    }


    public List<Orders> GetValues()
    {
        var sql = "select * from orders";
        return _context.Connection().Query<Orders>(sql).ToList();
    }
}
