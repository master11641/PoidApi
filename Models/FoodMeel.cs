using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class FoodMeel {
    [Display(Name="غذا")]
    public int FoodId { get; set; }
  
    public Food Food { get; set; }
    [Display(Name="وعده")]
    public int MeelId { get; set; }
   
    public  Meel Meel { get; set; }
}