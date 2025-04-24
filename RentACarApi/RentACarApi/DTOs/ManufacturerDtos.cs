using System.ComponentModel.DataAnnotations;

namespace RentACarApi.DTOs;

public record GetManufacturerDto(string Id, string Name);
public record CreateManufacturerDto([Required][StringLength(50)] string Name);
public record UpdateManufacturerDto([Required][StringLength(50)] string Name);