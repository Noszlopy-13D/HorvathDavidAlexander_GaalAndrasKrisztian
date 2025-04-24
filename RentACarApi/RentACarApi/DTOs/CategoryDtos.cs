using System.ComponentModel.DataAnnotations;

namespace RentACarApi.DTOs;

public record GetCategoryDto(string Id, string Name);
public record CreateCategoryDto([Required][StringLength(30)]string Name);
public record UpdateCategoryDto([Required][StringLength(30)]string Name);