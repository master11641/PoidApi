using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class FoodUnit {
  [Display(Name="غذا")]
    public int FoodId { get; set; }
  
    public Food Food { get; set; }
     [Display(Name="واحد مربوطه")]
    public int UnitId { get; set; }
   
    public  Unit Unit { get; set; }
     [Display(Name="میزان کالری")]

    public double Calorie{ get; set; }
}