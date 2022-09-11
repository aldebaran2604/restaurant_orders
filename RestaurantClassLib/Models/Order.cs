using RestaurantClassLib.Enumerators;

namespace RestaurantClassLib.Models;

public class Order
{
    #region  Properties

    public int Id { get; set; }

    /// <summary>
    /// Folio number with format (#000000)
    /// </summary>
    public string FolioNumber { get => $"{Id:D6}"; }

    public OrderStatus OrderStatus { get; set; }

    /// <summary>
    /// Total price to pay
    /// </summary>
    public decimal TotalPay { get; set; }

    public ICollection<OrderDetails> OrderDetails { get; set; }

    #endregion Properties

    #region Constructors

    public Order()
    {
        OrderDetails = new List<OrderDetails>();
    }

    public Order(List<OrderDetails> orderDetails)
    {
        OrderDetails = orderDetails;
    }

    #endregion Constructors
}