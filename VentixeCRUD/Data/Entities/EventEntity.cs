using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VentixeCRUD.Data.Entities;

public class EventEntity
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    [StringLength(25)]
    public string EventName { get; set; } = null!;
    
    [Required]
    [StringLength(350)]
    public string Description { get; set; } = null!;
    
    [Required]
    [DataType(DataType.Date)]
    [DisplayFormat(
        DataFormatString = "{0:MM/dd/yyyy}", 
        ApplyFormatInEditMode = true)]
    [Column(TypeName = "date")]
    public DateTime DateFrom { get; set; }
    
    [Required]
    [StringLength(25)]
    public string Category { get; set; } = null!;
    
    [StringLength(150)]
    public string? ImageUrl { get; set; }
    
    [Required]
    [StringLength(150)]
    public string Location { get; set; } = null!;
    
    [Required]
    [Column(TypeName = "decimal(18, 2)")] 
    public double Price { get; set; }
}