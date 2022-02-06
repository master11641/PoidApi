using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class FatPartDiet {

    public int DietId { get; set; }
    public Diet Diet { get; set; }
    public int FatPartId { get; set; }
    public FatPart  FatPart { get; set; }
 
}