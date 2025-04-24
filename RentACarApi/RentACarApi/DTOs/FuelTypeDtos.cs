using System.ComponentModel.DataAnnotations;

namespace RentACarApi.DTOs;

public record GetFuelTypeDto(string Id, string Name);
public record CreateFuelTypeDto([Required][StringLength(30)] string Name);
public record UpdateFuelTypeDto([Required][StringLength(30)] string Name);