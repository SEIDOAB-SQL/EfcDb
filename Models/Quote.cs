using System;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Models;
public class Quote
{
    [Key]
    public Guid QuoteId { get; set; }

    //Model properties
    public string QuoteText { get; set; }
    public string Author { get; set; }

    //Model relationships
    public List<Friend> Friends { get; set; } = null;

    //constructor
    public Quote()
    {
        QuoteId = Guid.NewGuid();
    }
}