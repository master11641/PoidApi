using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class Meel {
  public int Id { get; set; }

  [Display (Name = "عنوان")]
  public string Title { get; set; }
  public ICollection<FoodMeel> FoodMeels { get; set; }

  [Display (Name = "تصویر")]
  public string ImageUrl { get; set; }
  public int Percent { get; set; }
  public ICollection<PlanDetail> PlanDetails { get; set; }
  public int OrderId { get; set; }

}