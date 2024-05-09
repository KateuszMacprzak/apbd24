using System.ComponentModel.DataAnnotations;

namespace WarehouseApp.Models;

public class Product_Warehouse
{
    public int IdProductWarehouse { get; set; }
    [Key]
    [Required]
    public int IdWarehouse { get; set; }
    [Required]
    [ForeignKey("Warehouse")]
    public int IdProduct { get; set; }
    [Required]
    [ForeignKey("Product")]
    public int Amount { get; set; }
    [Required]
    public decimal Price { get; set; }
    [Required]
    [Column(TypeName = "numeric(25,2")]
    public DateTime CreatedAt { get; set; }
}