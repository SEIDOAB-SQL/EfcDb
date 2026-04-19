using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Seido.Utilities.SeedGenerator;

namespace Models;
public class Address : ISeed<Address>
{   
    [Key]
    public Guid AddressId { get; set; }

    //Model properties
    public  string StreetAddress { get; set; }
    public int ZipCode { get; set; }
    public string City { get; set; }
    public string Country { get; set; }

    //Model relationships
    public List<Friend> Residents { get; set; } = null;

    public override string ToString() => $"{StreetAddress}, {ZipCode} {City}, {Country}";

    #region Random Seeding
    public bool Seeded { get; set; } = false;

    public Address Seed(SeedGenerator seeder)
    {
        var country = seeder.Country;
        return new Address
        {
            AddressId = Guid.NewGuid(),
            
            StreetAddress = seeder.StreetAddress(country),
            ZipCode = seeder.ZipCode,
            City = seeder.City(country),
            Country = country,
            Seeded = true
        };
    }
    #endregion
}

