using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using RentACarApi.DTOs;

namespace RentACarApi.Models;

public class Car
{
    [Key] public int Id { get; set; }
    public required int ModelId { get; set; }
    public required int FuelTypeId { get; set; }
    public required int CategoryId { get; set; }
    public int Km { get; set; }
    public int PricePerKm { get; set; }
    public int Year { get; set; }
    public int HorsePower { get; set; }
    [MaxLength(400)]public required string Description { get; set; }
    
    public Model? Model { get; set; }
    public Category? Category { get; set; }
    public FuelType? FuelType { get; set; }
}

public static class CarExtensions
{
    public static GetCarDto ToGetDto(this Car car)
    {
        return new GetCarDto(car.Id, car.ModelId, car.CategoryId, car.FuelTypeId, car.Km, car.PricePerKm, car.Year, car.HorsePower, car.Description);
    }
    
    public static Car ToCar(this CreateCarDto dto)
    {
        return new Car {
            CategoryId = dto.CategoryId ?? 0,
            ModelId = dto.ModelId ?? 0,
            FuelTypeId = dto.FuelTypeId ?? 0,
            Km = dto.Km ?? 0,
            HorsePower = dto.HorsePower ?? 0,
            PricePerKm = dto.PricePerKm ?? 0,
            Year = dto.Year ?? 0,
            Description = dto.Description,
        };
    }

    public static Car ToCar(this UpdateCarDto dto, int id)
    {
        return new Car
        {
            Id = id,
            CategoryId = dto.CategoryId ?? 0,
            ModelId = dto.ModelId ?? 0,
            FuelTypeId = dto.FuelTypeId ?? 0,
            Km = dto.Km ?? 0,
            HorsePower = dto.HorsePower ?? 0,
            PricePerKm = dto.PricePerKm ?? 0,
            Year = dto.Year ?? 0,
            Description = dto.Description,
        };
    }
}