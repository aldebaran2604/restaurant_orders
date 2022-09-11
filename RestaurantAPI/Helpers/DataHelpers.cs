using RestaurantClassLib.Models;
using RestaurantClassLib.Enumerators;

namespace RestaurantAPI.Helpers;

/// <summary>
/// Model data stored in memory
/// </summary>
internal static class DataHelpers
{
    #region Lazy Properties

    private static readonly Lazy<List<Product>> _products = new Lazy<List<Product>>(CreateListProducts);

    internal static List<Product> Products { get => _products.Value; }

    private static readonly Lazy<List<Stock>> _stock = new Lazy<List<Stock>>(CreateListStock);

    /// <summary>
    /// List of products in stock
    /// </summary>
    internal static List<Stock> Stock { get => _stock.Value; }

    private static readonly Lazy<List<Order>> _orders = new Lazy<List<Order>>(CreateListOrders);

    /// <summary>
    /// List of products ordered
    /// </summary>
    internal static List<Order> Orders { get => _orders.Value; }

    private static readonly Lazy<List<OrderDetails>> _orderDetails = new Lazy<List<OrderDetails>>(CreateListOrderDetails);

    internal static List<OrderDetails> OrderDetails { get => _orderDetails.Value; }

    private static readonly Lazy<Dictionary<OrderStatus, string>> _listOrderStatus = new Lazy<Dictionary<OrderStatus, string>>(CreateListOrderStatus);

    internal static Dictionary<OrderStatus, string> ListOrderStatus { get => _listOrderStatus.Value; }

    private static readonly Lazy<Dictionary<ProductType, string>> _listProductType = new Lazy<Dictionary<ProductType, string>>(CreateListProductType);

    internal static Dictionary<ProductType, string> ListProductType { get => _listProductType.Value; }

    #endregion Lazy Properties

    #region Properties

    private static int _consecutiveStockId = 0;

    internal static int ConsecutiveStockId { get => ++_consecutiveStockId; }

    private static int _consecutiveOrderId = 0;

    internal static int ConsecutiveOrderId { get => ++_consecutiveOrderId; }

    private static int _consecutiveOrderDetailsId = 0;

    internal static int ConsecutiveOrderDetailsId { get => ++_consecutiveOrderDetailsId; }

    #endregion Properties

    #region Private Methods

    private static List<Product> CreateListProducts()
    {
        List<Product> products = new List<Product>();
        products.Add(new Product("Hamburger", "Small") { ProductTypeId = ProductType.HotFood });
        products.Add(new Product("Pizza", "Macro") { ProductTypeId = ProductType.HotFood });
        products.Add(new Product("Water Bottle", "Macro") { ProductTypeId = ProductType.ColdDrink });
        return products;
    }

    private static List<Stock> CreateListStock()
    {
        List<Stock> stock = new List<Stock>();
        Product productTake1Last = Products.Take(1).Last();
        stock.Add(new Stock(productTake1Last.SKU) { Id = ConsecutiveStockId, UnitPrice = 5, Quantity = 100 });
        Product productTake2Last = Products.Take(2).Last();
        stock.Add(new Stock(productTake2Last.SKU) { Id = ConsecutiveStockId, UnitPrice = 8, Quantity = 56 });
        Product productLast = Products.Last();
        stock.Add(new Stock(productLast.SKU) { Id = ConsecutiveStockId, UnitPrice = 1, Quantity = 300 });
        return stock;
    }

    private static List<Order> CreateListOrders()
    {
        List<Order> orders = new List<Order>();
        return orders;
    }

    private static List<OrderDetails> CreateListOrderDetails()
    {
        List<OrderDetails> orderDetails = new List<OrderDetails>();
        return orderDetails;
    }

    private static Dictionary<OrderStatus, string> CreateListOrderStatus()
    {
        Dictionary<OrderStatus, string> listOrderStatus = new Dictionary<OrderStatus, string>();
        listOrderStatus.Add(OrderStatus.Pending, $"{OrderStatus.Pending}");
        listOrderStatus.Add(OrderStatus.InProcess, $"{OrderStatus.InProcess}");
        listOrderStatus.Add(OrderStatus.Completed, $"{OrderStatus.Completed}");
        listOrderStatus.Add(OrderStatus.Delivered, $"{OrderStatus.Delivered}");
        listOrderStatus.Add(OrderStatus.Canceled, $"{OrderStatus.Canceled}");
        return listOrderStatus;
    }

    private static Dictionary<ProductType, string> CreateListProductType()
    {
        Dictionary<ProductType, string> listProductType = new Dictionary<ProductType, string>();
        listProductType.Add(ProductType.ColdFood, $"{ProductType.ColdFood}");
        listProductType.Add(ProductType.HotFood, $"{ProductType.HotFood}");
        listProductType.Add(ProductType.ColdDrink, $"{ProductType.ColdDrink}");
        listProductType.Add(ProductType.HotDrink, $"{ProductType.HotDrink}");
        return listProductType;
    }

    #endregion Private Methods
}