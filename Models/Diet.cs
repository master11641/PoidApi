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
      public int GenderId { get; set; }

    [ForeignKey ("GenderId")]
    public Gender Gender { get; set; }

    
    public bool RequestComplete { get; set; }
}