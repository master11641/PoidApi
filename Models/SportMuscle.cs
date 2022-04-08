using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class SportMuscle {

    public int SportId { get; set; }
    public Sport Sport { get; set; }
    public int MuscleId { get; set; }
    public Muscle  Muscle { get; set; }
  

}