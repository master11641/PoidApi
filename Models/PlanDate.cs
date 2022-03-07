using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class PlanDate {
   public PlanDate(){
        PlanDetails=new List<PlanDetail> ();
    }
    public int Id { get; set; }
    public DateTime CurrentDate { get; set; }
    public int PlanId { get; set; }
    [ForeignKey("PlanId")]
    public Plan Plan { get; set; }
    public ICollection<PlanDetail> PlanDetails { get; set; }

}