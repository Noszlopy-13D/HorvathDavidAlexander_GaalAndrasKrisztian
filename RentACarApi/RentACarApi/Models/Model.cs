using System.ComponentModel.DataAnnotations;
using RentACarApi.DTOs;

namespace RentACarApi.Models;

public class Model
{
    [Key] public int Id { get; set; }
    public int ManufacturerId { get; set; }
    [MaxLength(80)] public required string Name { get; set; }

    public Manufacturer? Manufacturer { get; set; }
}

public static class ModelExtensions
{
    public static GetModelDto ToGetDto(this Model model)
    {
        return new GetModelDto(model.Id, model.ManufacturerId, model.Name);
    }

    public static Model ToModel(this CreateModelDto dto)
    {
        return new Model{ManufacturerId = dto.ManufacturerId ?? 0, Name = dto.Name};
    }

    public static Model ToModel(this UpdateModelDto dto, int id)
    {
        return new Model{Id = id, ManufacturerId = dto.ManufacturerId ?? 0, Name = dto.Name};
    }
}