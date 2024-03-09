namespace Domain.Models;

public class OrderDetail
{
    public int Order_Detail_Id { get; set; }
    public int Customer_Id { get; set; }
    public int Order_Id { get; set; }
    public int Product_Id { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }

}
