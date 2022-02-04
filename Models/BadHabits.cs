using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class BadHabit {
    public int Id { get; set; }
    [Display(Name="عنوان")]
    public string Title { get; set; }
  
  
 

}