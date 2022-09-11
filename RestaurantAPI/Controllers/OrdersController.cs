using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Helpers;
using RestaurantClassLib;
using RestaurantClassLib.Models;
using RestaurantClassLib.Enumerators;

namespace RestaurantAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    #region Properties

    private readonly ILogger<OrdersController> _logger;

    #endregion Properties

    #region Constructors

    public OrdersController(ILogger<OrdersController> logger)
    {
        _logger = logger;
    }

    #endregion Constructors

    #region Api Method

    [HttpGet]
    public ActionResult<ResponseInformation<List<Order>>> GetListOrders()
    {
        ResponseInformation<List<Order>> responseInformation = new ResponseInformation<List<Order>>()
        {
            Message = "The query was carried out successfully.",
            ResultItem = DataHelpers.Orders
        };
        return Ok(responseInformation);
    }

    [HttpGet("{folio}")]
    public ActionResult<ResponseInformation<Order>> GetOrder(string folio)
    {
        ResponseInformation<Order> responseInformation = new ResponseInformation<Order>()
        {
            Message = "The query was carried out successfully.",
            ResultItem = DataHelpers.Orders.FirstOrDefault(o => o.FolioNumber == folio)
        };
        return Ok(responseInformation);
    }

    [HttpPost]
    public ActionResult<ResponseInformation> AddOrder(ICollection<OrderDetails> orderDetails)
    {
        ResponseInformation responseInformation = new ResponseInformation();

        IEnumerable<string> listSKUNotExists = orderDetails.Where(od => !DataHelpers.ListProducts.Exists(p => p.SKU == od.ProductSKU))
        .Select(od => od.ProductSKU);

        IEnumerable<string> listSKUQuantity = DataHelpers.ListStock.Where(s => orderDetails.Where(od => od.ProductSKU == s.ProductSKU && s.Quantity < od.Quantity).Any())
        .Select(s => $"SKU: {s.ProductSKU}, The difference is by: {orderDetails.First(od => od.ProductSKU == s.ProductSKU).Quantity - s.Quantity}");

        if (orderDetails is null || orderDetails.Count == 0)
        {
            responseInformation.Success = false;
            responseInformation.Message = "The product information and its quantity is required.";
        }
        else if (listSKUNotExists is not null && listSKUNotExists.Count() > 0)
        {
            string joinListSKU = $"{string.Join(", ", listSKUNotExists)}";
            responseInformation.Success = false;
            responseInformation.Message = $"The SKUs do not exist in the product list.{Environment.NewLine}{joinListSKU}";
        }
        else if (listSKUQuantity is not null && listSKUQuantity.Count() > 0)
        {
            string joinSKUQuantity = string.Join(", ", listSKUQuantity);
            responseInformation.Success = false;
            responseInformation.Message = $"The quantity of the requested product is greater than the existing one.{Environment.NewLine}{joinSKUQuantity}";
        }
        else
        {
            Order order = new Order() { Id = DataHelpers.ConsecutiveOrderId, OrderStatus = OrderStatus.Pending };
            decimal totalToPay = decimal.Zero;
            foreach (OrderDetails orderDetail in orderDetails)
            {
                orderDetail.Id = DataHelpers.ConsecutiveOrderDetailsId;
                orderDetail.OrderId = order.Id;

                Stock stock = DataHelpers.ListStock.First(s => s.ProductSKU == orderDetail.ProductSKU);

                totalToPay += stock.UnitPrice * orderDetail.Quantity;
                stock.Quantity -= orderDetail.Quantity;
            }
            order.OrderDetails = orderDetails;
            order.TotalPay = totalToPay;
            DataHelpers.Orders.Add(order);
            responseInformation.Message = "The order has been added successfully.";
        }
        return Ok(responseInformation);
    }

    [HttpPut("{folio}/{orderStatus}")]
    public ActionResult<ResponseInformation> EditOrderStatus(string folio, OrderStatus orderStatus)
    {
        ResponseInformation responseInformation = new ResponseInformation();
        Order? order = DataHelpers.Orders.FirstOrDefault(o=> o.FolioNumber == folio);
        if(order is null)
        {
            responseInformation.Success = false;
            responseInformation.Message = $"The order of folio #{folio} does not exist.";
        }
        else
        {
            order.OrderStatus = orderStatus;
            responseInformation.Message = "The status of the order has been updated successfully.";
        }
        return Ok(responseInformation);
    }

    #endregion Api Method
}