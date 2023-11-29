using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

public class Booking
{
    [Key]
    public int BookingID { get; set; }

    [Required(ErrorMessage = "UserID is required.")]
    [ForeignKey("User")]
    public int UserID { get; set; }

    [Required(ErrorMessage = "UserName is required.")]
    public string UserName { get; set; }

    public DateTime SubmissionDate { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; }

    [Required(ErrorMessage = "BookingStatus is required.")]
    public string BookingStatus { get; set; }

    [Required(ErrorMessage = "ServiceID is required.")]
    [ForeignKey("Service")]
    public int ServiceID { get; set; }

    public DateTime CreatedTime { get; set; }

    public DateTime ModifiedTime { get; set; }

    public bool IsDeleted { get; set; }

  
    public User User { get; set; }
    public Service Service { get; set; }


    public ICollection<Payment> Payments { get; set; }
}
