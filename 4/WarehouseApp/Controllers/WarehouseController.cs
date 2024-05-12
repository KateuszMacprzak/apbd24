using WarehouseApp.Models;
using Microsoft.AspNetCore.Mvc;
namespace WarehouseApp.Controllers;

// kontroler animals
[Route("api/animals")]
[ApiController]
public class AnimalsController: ControllerBase
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
            return NotFound($"Animal with id {id} was not found");
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