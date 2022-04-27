using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class Weight {
    public int Id { get; set; }
    public double UserWeight { get; set; }
    public DateTime RegisterDate { get; set; } = DateTime.Now;
    public int  DietId { get; set; }
    [ForeignKey("DietId")]
    public Diet Diet { get; set; }
}