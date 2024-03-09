namespace Domain.Models;

public class Orders
{
    public int Order_Id { get; set; }
    public int Customer_Id { get; set; }
    public DateTime Order_Date { get; set; }
    public decimal Amount { get; set; }
}
