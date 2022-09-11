namespace RestaurantClassLib.Models;

public class OrderDetails
{
    #region Properties

    public int Id { get; set; }

    public int OrderId { get; set; }

    public string ProductSKU { get; set; }

    /// <summary>
    /// Quantity of the ordered product
    /// </summary>
    public int Quantity { get; set; }

    #endregion Properties

    #region Constructors

    public OrderDetails(string sku)
    {
        ProductSKU = sku;
    }

    #endregion Constructors
}