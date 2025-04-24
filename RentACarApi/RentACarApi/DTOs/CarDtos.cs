using System.ComponentModel.DataAnnotations;

namespace RentACarApi.DTOs;

public record GetCarDto(
    int Id,
    int ModelId,
    int CategoryId,
    int FuelTypeId,
    int Km,
    int PricePerKm,
    int Year,
    int HorsePower,
    string Description);

public record CreateCarDto(
    [Required] int? ModelId,
    [Required] int? CategoryId,
    [Required] int? FuelTypeId,
    [Required] int? Km,
    [Required] int? PricePerKm,
    [Required] int? Year,
    [Required] int? HorsePower,
    [Required][StringLength(400)] string Description);

public record UpdateCarDto(
    [Required] int? ModelId,
    [Required] int? CategoryId,
    [Required] int? FuelTypeId,
    [Required] int? Km,
    [Required] int? PricePerKm,
    [Required] int? Year,
    [Required] int? HorsePower,
    [Required][StringLength(400)] string Description);
