using System.ComponentModel.DataAnnotations;

namespace RentACarApi.Models;

public class SupportMessage
{
    [Key] public int Id { get; set; }
    public DateTime Date { get; set; }
    [StringLength(80)] public required string EmailAddress { get; set; }
    [StringLength(100)] public required string Title { get; set; }
    [StringLength(2_500)] public required string Message { get; set; }
}