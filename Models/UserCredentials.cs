using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;



namespace Gladiator.Models
{
    public class UserCredentials
{
    [Key]
    public int UserID { get; set; }
 
    [Required]
    public string UserName { get; set; }
 
    [Required]
    [EmailAddress]
    public string Email { get; set; }
 
    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }
 
    [Required]
    public string Role { get; set; }
 
    public DateTime CreatedTime { get; set; }
 
    public DateTime ModifiedTime { get; set; }
    public ICollection<Booking> Bookings { get; set; }
    public ICollection<Payment> Payments { get; set; }
}
}