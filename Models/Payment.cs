using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
namespace Gladiator.Models
{
    public class Payment
{
    [Key]
    public int Sno { get; set; }
 
    [ForeignKey("UserCredentials")]
    public int UserID { get; set; }
 
    [ForeignKey("Booking")]
    public int BookingID { get; set; }
 
    public DateTime CreatedTime { get; set; }
 
    public int GSTCharge { get; set; }
 
    public int Discount { get; set; }
 
    public decimal TotalAmount { get; set; }
 
    public string ModeOfPayment { get; set; }
 
    // Navigation properties
    public UserCredentials UserCredentials { get; set; }
 
    public Booking Booking { get; set; }
}
}
