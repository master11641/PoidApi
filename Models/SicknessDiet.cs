using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class SicknessDiet {

    public int DietId { get; set; }
    public Diet Diet { get; set; }
    public int SicknessId { get; set; }
    public Sickness  Sickness { get; set; }
  
}