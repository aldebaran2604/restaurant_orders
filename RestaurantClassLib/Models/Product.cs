using RestaurantClassLib.Enumerators;

namespace RestaurantClassLib.Models;

public class Product
{
    #region Properties

    /// <summary>
    /// Identifier in SKU format UPPER(ProductType-Name-Size)
    /// </summary>
    public string SKU { get => $"{ProductTypeId}-{Name}-{Size}".Replace(" ","_").ToUpper(); }

    public ProductType ProductTypeId { get; set; }

    public string Name { get; set; }

    /// <summary>
    /// The size of the product
    /// </summary>
    public string Size { get; set; }

    #endregion Properties

    #region Constructors

    public Product()
    {
        Name = string.Empty;
        Size = string.Empty;
    }

    public Product( string name, string size)
    {
        Name = name;
        Size = size;
    }

    #endregion Constructors
}
