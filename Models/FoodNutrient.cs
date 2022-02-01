using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class FoodNutrient {
    [Display(Name="غذا")]
    public int FoodId { get; set; }
  
    public Food Food { get; set; }
    [Display(Name="مغذی")]
    public int NutrientId { get; set; }
   
    public Nutrient Nutrient { get; set; }
}