using System.ComponentModel.DataAnnotations;

namespace RentACarApi.Models;

public class Image
{
    [Key] public int Id { get; set; }
    public required int CarId { get; set; }
    [StringLength(100)] public required string Path { get; set; }
    public DateTime UploadDate { get; set; }
    
    public Car? Car { get; set; }
}