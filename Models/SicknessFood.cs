using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class SicknessFood {

    public int FoodId { get; set; }
    public Food Food { get; set; }
    public int SicknessId { get; set; }
    public Sickness  Sickness { get; set; }
    [Display(Name="بیمار می تواند این غذا را مصرف کند؟")]
    public bool MustBe { get; set; }
  
}