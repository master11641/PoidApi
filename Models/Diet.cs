using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class Diet {
    public int Id { get; set; }
    public int UserId { get; set; }

    [ForeignKey ("UserId")]
    public User User { get; set; }
    public ICollection<QuestionDiet> QuestionDiets { get; set; }
    public ICollection<ProteinDiet> ProteinDiets { get; set; }

    public ICollection<AllergyDiet> AllergyDiets { get; set; }
    public ICollection<BadHabitDiet> BadHabitDiets { get; set; }
    public ICollection<SicknessDiet> SicknessDiets { get; set; }
    public ICollection<FatPartDiet> FatPartDiets { get; set; }
    public int? PlanId { get; set; }
    [ForeignKey("PlanId")]
    public Plan Plan { get; set; }

    public int? GenderId { get; set; }

    [ForeignKey ("GenderId")]
    public Gender Gender { get; set; }
    public int? GoalId { get; set; }

    [ForeignKey ("GoalId")]
    public Goal Goal { get; set; }
    public int? ActivityRateId { get; set; }

    [ForeignKey ("ActivityRateId")]
    public ActivityRate ActivityRate { get; set; }
    public int? WaterRateId { get; set; }

    [ForeignKey ("WaterRateId")]
    public WaterRate WaterRate { get; set; }
    public int? SleepRateId { get; set; }

    [ForeignKey ("SleepRateId")]
    public SleepRate SleepRate { get; set; }

    public double? Age { get; set; }
    public double? Height { get; set; }
    public double? Waist { get; set; }//کمر
    public double? Wrist { get; set; }//مچ
    public double? Weight { get; set; }
    public String SicknessDescription { get; set; }
    public String AllergyDescription { get; set; }
    public String ActivityRateDescription { get; set; }

    public String TakingMedicationDescription { get; set; } //توضیح مصرف دارو
    public bool? RequestComplete { get; set; }

}