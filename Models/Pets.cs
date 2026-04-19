using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Seido.Utilities.SeedGenerator;

namespace Models;
public enum AnimalKind { Dog, Cat, Rabbit, Fish, Bird };
public enum AnimalMood { Happy, Hungry, Lazy, Sulky, Buzy, Sleepy };
public class Pet : ISeed<Pet>
{
    [Key]
    public Guid PetId { get; set; }

    //Model properties
    public AnimalKind Kind { get; set; }
    public AnimalMood Mood { get; set; }
    public string Name { get; set; }

    //Model relationships
    public Friend Owner { get; set; }

    public override string ToString() => $"{Name}, the {Mood} {Kind}";

    #region Random Seeding
    public bool Seeded { get; set; } = false;

    public Pet Seed(SeedGenerator seeder)
    {
        var country = seeder.Country;
        return new Pet
        {
            PetId = Guid.NewGuid(),
            
            Kind = seeder.FromEnum<AnimalKind>(),
            Mood = seeder.FromEnum<AnimalMood>(),

            Name = seeder.PetName,
            Seeded = true
        };
    }
    #endregion
}
