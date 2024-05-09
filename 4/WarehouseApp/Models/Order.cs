using System.ComponentModel.DataAnnotations;

namespace WarehouseApp.Models;

public class Order
{
    public int IdOrder { get; set; }
    [Key]
    [Required]
    public int IdProduct { get; set; }
    [ForeignKey("Product")]
    [Required]
    public int Amount { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public DateTime? FullfilledAt { get; set; }
    
}