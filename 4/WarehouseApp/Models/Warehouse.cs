using System.ComponentModel.DataAnnotations;

namespace WarehouseApp.Models;

public class Warehouse
{
    public int IdWarehouse { get; set; }
    [Key]
    [Required]
    public String Name { get; set; }
    [Required]
    [MaxLength(200)]
    public String Address { get; set; }
    [Required]
    [MaxLength(200)]
}