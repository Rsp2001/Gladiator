using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

public class Payment
{
    [Key]
    public int Sno { get; set; }

    [Required(ErrorMessage = "UserID is required.")]
    [ForeignKey("User")]
    // [OnDelete(DeleteBehavior.NoAction)]
    public int UserID { get; set; }

    [Required(ErrorMessage = "BookingID is required.")]
    [ForeignKey("Booking")]
    // [OnDelete(DeleteBehavior.NoAction)]
    public int BookingID { get; set; }

    public DateTime CreatedTime { get; set; }

    public int GSTCharge { get; set; }

    public int Discount { get; set; }

    [Required(ErrorMessage = "TotalAmount is required.")]
    public decimal TotalAmount { get; set; }

    [Required(ErrorMessage = "ModeOfPayment is required.")]
    public string ModeOfPayment { get; set; }

    // Navigation Properties
    public User User { get; set; }
    public Booking Booking { get; set; }
}
