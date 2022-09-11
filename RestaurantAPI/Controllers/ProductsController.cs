using Microsoft.AspNetCore.Mvc;
using RestaurantClassLib.Models;
using RestaurantAPI.Helpers;
using RestaurantClassLib;

namespace RestaurantAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    #region Properties

    private readonly ILogger<ProductsController> _logger;

    #endregion Properties

    #region Constructors

    public ProductsController(ILogger<ProductsController> logger)
    {
        _logger = logger;
    }

    #endregion Constructors

    #region Api Method

    [HttpGet]
    public ActionResult<ResponseInformation<List<Product>>> GetListProducts()
    {
        ResponseInformation<List<Product>> responseInformation = new ResponseInformation<List<Product>>()
        {
            Message = "The query was carried out successfully.",
            ResultItem = DataHelpers.ListProducts
        };
        return Ok(responseInformation);
    }

    [HttpGet("{sku}")]
    public ActionResult<ResponseInformation<Product>> GetProduct(string sku)
    {
        ResponseInformation<Product> responseInformation = new ResponseInformation<Product>()
        {
            Message = "The query was carried out successfully.",
            ResultItem = DataHelpers.ListProducts.FirstOrDefault(p => p.SKU == sku)
        };
        return Ok(responseInformation);
    }

    [HttpPost]
    public ActionResult<ResponseInformation> AddProduct(Product product)
    {
        ResponseInformation responseInformation = new ResponseInformation();
        if (product is null)
        {
            responseInformation.Success = false;
            responseInformation.Message = "The product is required.";
        }
        else if (DataHelpers.ListProducts.Exists(p => p.SKU == product?.SKU))
        {
            responseInformation.Success = false;
            responseInformation.Message = "The product SKU already exists.";
        }
        else
        {
            DataHelpers.ListProducts.Add(product);
            responseInformation.Message = "The product has been added successfully.";
        }
        return Ok(responseInformation);
    }

    [HttpPut("{sku}")]
    public ActionResult<ResponseInformation> EditProduct(string sku, Product product)
    {
        ResponseInformation responseInformation = new ResponseInformation();
        Product? productQuery = DataHelpers.ListProducts.FirstOrDefault(p => p.SKU == sku);
        if (product is null)
        {
            responseInformation.Success = false;
            responseInformation.Message = "The product is required.";
        }
        else if (productQuery is null)
        {
            responseInformation.Success = false;
            responseInformation.Message = "the product does not exist.";
        }
        else if (productQuery.SKU == product.SKU)
        {
            responseInformation.Success = false;
            responseInformation.Message = "The product SKU already exists.";
        }
        else
        {
            productQuery.ProductTypeId = product.ProductTypeId;
            productQuery.Name = product.Name;
            productQuery.Size = product.Size;
            responseInformation.Message = "The product has been edited successfully.";
        }
        return Ok(responseInformation);
    }

    //TODO: Evaluate the possibility of eliminating or changing status to no longer be used.
    /* [HttpDelete("{sku}")]
    public ActionResult<ResponseInformation> DeleteProduct(string sku)
    {
        ResponseInformation responseInformation = new ResponseInformation();
        Product? product = DataHelpers.Products.FirstOrDefault(p => p.SKU == sku);
        if (product is null)
        {
            responseInformation.Success = false;
            responseInformation.Message = "The product does not exist.";
        }
        else
        {
            DataHelpers.Products.Remove(product);
            responseInformation.Message = "The product has been removed successfully.";
        }
        return Ok(responseInformation);
    } */

    #endregion Api Method
}