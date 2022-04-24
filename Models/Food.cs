using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class Food {
  public Food(){
    FoodUnits =new List<FoodUnit>();
  }
  public int Id { get; set; }

  [Display (Name = "غذا")]
  public string Title { get; set; }

  [Display (Name = "گروه غذایی")]
  public int GroupId { get; set; }

  [ForeignKey ("GroupId")]
  public Group Group { get; set; }

  [Display (Name = "تصاویر")]
  public ICollection<FoodImage> FoodImages { get; set; } //one to many
  [Display (Name = "مغذی ها")]
  public ICollection<FoodNutrient> FoodNutrients { get; set; } //many to many
  [Display (Name = "وعده های غذایی")]
  public ICollection<FoodMeel> FoodMeels { get; set; } //many to many
  [Display (Name = "واحدهای غذا")]
  public ICollection<FoodUnit> FoodUnits { get; set; } //many to many
    [Display (Name = "بیماری های مرتبط")]
  public ICollection<SicknessFood> SicknessFoods { get; set; } //many to many
    public ICollection<PlanDetail> PlanDetails { get; set; }//many to many

}