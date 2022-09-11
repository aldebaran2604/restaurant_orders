namespace RestaurantClassLib.Models;

public class Stock
{
    #region  Properties

    public int Id { get; set; }

    public string ProductSKU { get; private set; }

    /// <summary>
    /// Price by unit
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Total quantity
    /// </summary>
    public int Quantity { get; set; }

    #endregion Properties

    #region Constructors

    public Stock(string sku)
    {
        ProductSKU = sku;
    }

    #endregion Constructors
}