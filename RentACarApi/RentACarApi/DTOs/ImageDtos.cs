namespace RentACarApi.DTOs;

public record GetImageDto(int Id, int CarId, string ImagePath, DateTime UploadDate);
public record CreateImageDto(int CarId);
public record UpdateImageDto(int CarId);
