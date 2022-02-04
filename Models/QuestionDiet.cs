using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class QuestionDiet {

    public int DietId { get; set; }
    public Diet Diet { get; set; }
    public int QuestionId { get; set; }
    public Question Question { get; set; }
    public int ResponseValue { get; set; }
}