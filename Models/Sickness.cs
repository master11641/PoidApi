using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class Sickness {
    public int Id { get; set; }
    [Display(Name="عنوان")]
    public string Title { get; set; }
  
  public ICollection<SicknessDiet> SicknessDiets { get; set; }
  
  public ICollection<SicknessFood>  SicknessFoods { get; set; }

}