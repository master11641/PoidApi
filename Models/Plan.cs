using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class Plan {
    public int Id { get; set; }

    [Display (Name = "عنوان")]
    public string Title { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int DietId { get; set; }

    [ForeignKey ("DietId")]
    public Diet Diet { get; set; }

    public double Calorie { get; set; }
    public ICollection<PlanDate> PlanDates { get; set; }
   

}