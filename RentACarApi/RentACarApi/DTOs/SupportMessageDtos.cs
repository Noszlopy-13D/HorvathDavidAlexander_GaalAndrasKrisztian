namespace RentACarApi.DTOs;

public record CreateSupportMessageDto(
    string EmailAddress,
    string Title,
    string Message
);