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
            ResultItem = DataHelpers.Stock
        };
        return Ok(responseInformation);
    }

    [HttpGet("{sku}")]
    public ActionResult<ResponseInformation<Stock>> GetStock(string sku)
    {
        ResponseInformation<Stock> responseInformation = new ResponseInformation<Stock>()
        {
            Message = "The query was carried out successfully.",
            ResultItem = DataHelpers.Stock.FirstOrDefault(s => s.ProductSKU == sku)
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
        else if (DataHelpers.Stock.Exists(s => s.ProductSKU == stock.ProductSKU))
        {
            responseInformation.Success = false;
            responseInformation.Message = "The product SKU already exists in the stock.";
        }
        else
        {
            DataHelpers.Stock.Add(stock);
            responseInformation.Message = "The product has been added successfully in the stock.";
        }
        return Ok(responseInformation);
    }

    #endregion Api Method
}