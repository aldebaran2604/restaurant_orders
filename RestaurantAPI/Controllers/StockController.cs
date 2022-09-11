using Microsoft.AspNetCore.Mvc;
using RestaurantClassLib.Models;
using RestaurantAPI.Helpers;
using RestaurantClassLib;

namespace RestaurantAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StockController : ControllerBase
{
    #region Properties

    private readonly ILogger<StockController> _logger;

    #endregion Properties

    #region Constructors

    public StockController(ILogger<StockController> logger)
    {
        _logger = logger;
    }

    #endregion Constructors

    #region Api Method

    [HttpGet]
    public ActionResult<ResponseInformation<List<Stock>>> GetListStock()
    {
        ResponseInformation<List<Stock>> responseInformation = new ResponseInformation<List<Stock>>()
        {
            Message = "The query was carried out successfully.",
            ResultItem = DataHelpers.ListStock
        };
        return Ok(responseInformation);
    }

    [HttpGet("{sku}")]
    public ActionResult<ResponseInformation<Stock>> GetStock(string sku)
    {
        ResponseInformation<Stock> responseInformation = new ResponseInformation<Stock>()
        {
            Message = "The query was carried out successfully.",
            ResultItem = DataHelpers.ListStock.FirstOrDefault(s => s.ProductSKU == sku)
        };
        return Ok(responseInformation);
    }

    [HttpPost]
    public ActionResult<ResponseInformation> AddStock(Stock stock)
    {
        ResponseInformation responseInformation = new ResponseInformation();
        if (stock is null)
        {
            responseInformation.Success = false;
            responseInformation.Message = "The stock information is required.";
        }
        else if(!DataHelpers.ListProducts.Exists(p=> p.SKU == stock.ProductSKU))
        {
            responseInformation.Success = false;
            responseInformation.Message = "the product related to SKU does not exist.";
        }
        else if (DataHelpers.ListStock.Exists(s => s.ProductSKU == stock.ProductSKU))
        {
            responseInformation.Success = false;
            responseInformation.Message = "The product SKU already exists in the stock.";
        }
        else
        {
            DataHelpers.ListStock.Add(stock);
            responseInformation.Message = "The product has been added successfully in the stock.";
        }
        return Ok(responseInformation);
    }

    [HttpPut("{sku}")]
    public ActionResult<ResponseInformation> EditStock(string sku, Stock stock)
    {
        ResponseInformation responseInformation = new ResponseInformation();
        Stock? stockQuery = DataHelpers.ListStock.FirstOrDefault(s => s.ProductSKU == sku);
        if (stock is null)
        {
            responseInformation.Success = false;
            responseInformation.Message = "The stock information is required.";
        }
        else if (stockQuery is null)
        {
            responseInformation.Success = false;
            responseInformation.Message = "The stock does not exist.";
        }
        else
        {
            stockQuery.UnitPrice = stock.UnitPrice;
            stockQuery.Quantity = stock.Quantity;
            responseInformation.Message = "The stock information has been successfully updated.";
        }
        return Ok(responseInformation);
    }

    #endregion Api Method
}