using WarehouseApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace WarehouseApp.Controllers;

// kontroler warehouse
[Route("api/warehouses")]
[ApiController]
public class WarehousesController: ControllerBase
{
    private static readonly List<Warehouse> _warehouses = new()
    {
        new Warehouse {IdWarehouse = 1, Name = "Warsaw", Address = "Kwiatowa 12"}
    };
    [HttpGet]
    public IActionResult GetWarehouses()
    {
        return Ok(_warehouses.OrderBy(warehouse => warehouse.IdWarehouse).ToList()); 
    }
    

    [HttpPost]
    public IActionResult CreateWarehouse(Warehouse warehouse)
    {
        _warehouses.Add(warehouse);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateWarehouse(int id, Warehouse warehouse)
    {
        var warehouseToEdit= _warehouses.FirstOrDefault(a => a.IdWarehouse == id);

        if (warehouseToEdit == null)
        {
            return NotFound($"Warehouse with id {id} was not found");
        }

        if (warehouseToEdit.IdWarehouse != warehouse.IdWarehouse)
        {
            return BadRequest("Id cannot be changed");
        };
        _warehouses.Remove(warehouseToEdit);
        _warehouses.Add(warehouse);
        return NoContent();    
    }
    
    [HttpDelete("{id:int}")]
    public IActionResult DeleteWarehouse(int id, Warehouse warehouse)
    {
        var warehouseToDelete= _warehouses.FirstOrDefault(a => a.IdWarehouse == id);
        if (warehouseToDelete == null)
        {
            return NoContent();
        }

        _warehouses.Remove(warehouseToDelete);
        return NoContent();
    }
}

// kontroler product
[Route("api/products")]
[ApiController]

public class ProductController: ControllerBase
{
    private static readonly List<Product> _products = new()
    {
        new Product {IdProduct=1, Name="Abacavir", Description="", Price=25.5, Area=""},
        new Product {IdProduct=2, Name="Acyclovir", Description="", Price=45.0, Area=""},
        new Product {IdProduct=3, Name="Allopurinol", Description="", Price=30.8, Area=""},
    }
        [HttpGet]
    public IActionResult GetProducts()
    {
        return Ok(_products.OrderBy(product => product.IdProduct).ToList());
    }

    [HttpPost]
    public IActionResult CreateProduct(Product product)
    {
        _products.Add(product);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateProduct(int id, Product product)
    {
        var productToEdit = _products.FirstOrDefault(a => a.IdProduct == id)

        if (productToEdit == null)
        {
            return NotFound($"Product with id {id} was not found");
        }

        if (productToEdit.IdProduct != product.IdProduct)
        {
            return BadRequest("Id cannot be changed");
        }

        _products.Remove(productToEdit);
        _products.Add(product);
        return NoContent();
    }

    [HttpDelete("{id:int")]
    public IActionResult DeleteProduct(int id, Product product)
    {
        var productToDelete = _products.FirstOrDefault(a => a.IdProduct == id);
        if (productToDelete == null)
        {
            return NoContent();
        }

        _products.Remove(productToDelete);
        return NoContent();
    }
}

public class OrderController

// kontroler zamowien
[Route("api/orders")]
[ApiController]

public class OrderController: ControllerBase
{
    private static readonly List<Order> _orders = new()
        {
            new Order {IdOrder=1, IdProduct=1, Amount=125, CreatedAt="12-05-2024", FullfilledAt="12-05-2024"},
        }
        [HttpGet]
    public IActionResult GetOrders()
    {
        return Ok(_orders.OrderBy(order => order.IdOrder).ToList());
    }

    [HttpPost]
    public IActionResult CreateOrder(Order order)
    {
        _orders.Add(order);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateOrder(int id, Order order)
    {
        var orderToEdit = _orders.FirstOrDefault(a => a.IdOrder == id)

        if (orderToEdit == null)
        {
            return NotFound($"Order with id {id} was not found");
        }

        if (orderToEdit.IdProduct != order.IdProduct)
        {
            return BadRequest("Id cannot be changed");
        }

        _orders.Remove(orderToEdit);
        _orders.Add(order);
        return NoContent();
    }

    [HttpDelete("{id:int")]
    public IActionResult DeleteOrder(int id, Order order)
    {
        var orderToDelete = _orders.FirstOrDefault(a => a.IdProduct == id);
        if (orderToDelete == null)
        {
            return NoContent();
        }

        _orders.Remove(orderToDelete);
        return NoContent();
    }
}