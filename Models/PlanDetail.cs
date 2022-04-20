using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class PlanDetail {
  
    public int FoodId { get; set; }
  
    public Food Food { get; set; }

    public int PlanDateId { get; set; }
   
    public  PlanDate PlanDate { get; set; }
    public int UnitId { get; set; }
    [ForeignKey("UnitId")]
    public Unit Unit { get; set; }
    public double UnitValue { get; set; }
    public int MeelId { get; set; }
    [ForeignKey("MeelId")]
    public Meel Meel { get; set; } 
    public bool IsDone { get; set; }
    public string FailDescription { get; set; }
   public double Calorie { get; set; }
   public int? ReplacePlanDetailId { get; set; } //=>شناسه غذای جدید را نگهداری می کند بهتر است نامش تغییر کند

}