using System.ComponentModel.DataAnnotations;

namespace RentACarApi.Models;

public class FuelType
{
    [Key] public int Id { get; set; }
    [MaxLength(30)] public required string Name { get; set; }
}