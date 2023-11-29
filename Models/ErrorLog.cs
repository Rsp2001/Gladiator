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
   public class ErrorLog
{
    [Key]
    public int Sno { get; set; }
 
    public string Description { get; set; }
 
    public DateTime Time { get; set; }
 
    public string Status { get; set; }
}
}