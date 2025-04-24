using System.ComponentModel.DataAnnotations;

namespace RentACarApi.DTOs;

public record GetModelDto(int Id, int ManufacturerId, string Name);
public record CreateModelDto([Required] int? ManufacturerId, [Required][StringLength(50)] string Name);
public record UpdateModelDto([Required] int? ManufacturerId, [Required][StringLength(50)] string Name);