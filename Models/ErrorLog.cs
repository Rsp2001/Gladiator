using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;


public class ErrorLog
{
[Key]    
public int Sno { get; set; }

    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; }

    public DateTime Time { get; set; }

    [Required(ErrorMessage = "Status is required.")]
    public string Status { get; set; }
}
