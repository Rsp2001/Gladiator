using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


public class Service
{
    [Key]
    public int ServiceID { get; set; }

    [Required(ErrorMessage = "ServiceType is required.")]
    public string ServiceType { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; }

    public string Requirements { get; set; }

    [Required(ErrorMessage = "Charges is required.")]
    public decimal Charges { get; set; }

    public DateTime Timing { get; set; }

    [Required(ErrorMessage = "Amount is required.")]
    public int Amount { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime ModifiedTime { get; set; }

    public bool IsDeleted { get; set; }

    // Navigation Property for Bookings
    public ICollection<Booking> Bookings { get; set; }
}
