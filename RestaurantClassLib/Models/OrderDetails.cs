namespace RestaurantClassLib.Models;

public class OrderDetails
{
    #region Properties

    public int Id { get; set; }

    public int OrderId { get; set; }

    public string ProductSKU { get; set; }

    public string ProductName { get; set; }

    /// <summary>
    /// Quantity of the ordered product
    /// </summary>
    public int Quantity { get; set; }

    #endregion Properties

    #region Constructors

    public OrderDetails()
    {
        ProductSKU = string.Empty;
        ProductName = string.Empty;
    }

    public OrderDetails(string sku, string productName)
    {
        ProductSKU = sku;
        ProductName = productName;
    }

    #endregion Constructors
}