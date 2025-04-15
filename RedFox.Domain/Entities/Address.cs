namespace RedFox.Domain.Entities;

public class Address
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Street { get; set; } = string.Empty;
    public string Suite { get; set; } = string.Empty;
    public string City { get; set; } = string.Empty;
    public string Zipcode { get; set; } = string.Empty;
    public Geo Geo { get; set; } = null!;
    public required User User { get; set; }
}

public class Geo
{
    public int Id { get; set; }
    public int AddressId { get; set; }
    public string Lat { get; set; } = string.Empty;
    public string Lng { get; set; } = string.Empty;
    public required Address Address { get; set; }
} 