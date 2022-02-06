using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class ProteinDiet {

    public int DietId { get; set; }
    public Diet Diet { get; set; }
    public int ProteinId { get; set; }
    public Protein  Protein { get; set; }
    public int ResponseValue { get; set; }
}