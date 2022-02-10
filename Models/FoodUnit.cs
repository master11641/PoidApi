using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class FoodUnit {
  [Display (Name = "غذا")]
  public int FoodId { get; set; }

  public Food Food { get; set; }

  [Display (Name = "واحد مربوطه")]
  public int UnitId { get; set; }

  public Unit Unit { get; set; }

  [Display (Name = "میزان کالری")]

  public double? Calorie { get; set; }
   [Display (Name = "پروتئین")]
  public double? Protein { get; set; }
   [Display (Name = "كربوهيدرات(گرم)")]
  public double? Carbohydrate { get; set; }
   [Display (Name = "چربي(گرم)")]
  public double? Fat { get; set; }
   [Display (Name = "قند(گرم)")]
  public double? Sugar { get; set; }
   [Display (Name = "سديم(ميلي گرم)")]
  public double? Sodium { get; set; }
   [Display (Name = "پتاسيم(ميلي گرم)")]
  public double? Potassium { get; set; }
   [Display (Name = "منيزيوم(ميلي گرم)")]
  public double? Magnesium { get; set; }
   [Display (Name = "كلسيم(ميلي گرم)")]
  public double? Calcium { get; set; }
   [Display (Name = "فسفر(ميلي گرم)")]
  public double? Phosphor { get; set; }
   [Display (Name = "آهن(ميلي گرم)")]
  public double? Iron { get; set; }
   [Display (Name = "اسيد چرب تك غير اشباع(گرم)")]
  public double? Umfa { get; set; } //اسيد چرب تك غير اشباع
   [Display (Name = "اسيد چرب چند تاييي غير اشباع(گرم)")]
  public double? Upfa { get; set; } //Unsaturated polyunsaturated fatty acid   اسيد چرب چند تاييي غير اشباع(گرم)
   [Display (Name = "اسيد چرب اشباع(گرم)")]
  public double? Sfa { get; set; } //Saturated fatty acids  اسيد چرب اشباع
   [Display (Name = "اسيد چرب ترانس( گرم)")]
  public double? Tfa { get; set; } //Trans fatty acids    اسيد چرب ترانس

}