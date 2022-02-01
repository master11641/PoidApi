using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class Nutrient {
    public int Id { get; set; }
     [Display(Name="عنوان")]
    public string Title { get; set; }
    public ICollection<FoodNutrient> FoodNutrients { get; set; }
     [Display(Name="تصویر")]
    public string ImageUrl { get; set; }
     [Display(Name="آیا ریز مغذی است؟")]
    public bool IsMicro { get; set; }


}