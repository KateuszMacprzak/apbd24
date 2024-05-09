using System.ComponentModel.DataAnnotations;

namespace WarehouseApp.Models;

public class Product
{
    public int IdProduct { get; set; }
    [Required]
    [Key]
    public string Name { get; set; }
    [Required]
    [MaxLength(200)]
    public string Description { get; set; }
    [Required]
    [MaxLength(200)]
    public decimal Price { get; set; }
    [Required]
    [Column(TypeName = "numeric(25,2)")]
    public string Area { get; set; }
}


