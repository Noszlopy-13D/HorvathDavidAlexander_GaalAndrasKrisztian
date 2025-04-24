using System.ComponentModel.DataAnnotations;

namespace RentACarApi.Models;

public class Manufacturer
{
    [Key] public int Id { get; set; }
    [MaxLength(50)] public required string Name { get; set; }
}