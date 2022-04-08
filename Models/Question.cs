using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class Question {
    public int Id { get; set; }
    [Display(Name="عنوان")]
    public string Title { get; set; }
  public ICollection<QuestionDiet> QuestionDiets { get; set; }
   public ICollection<PodcastQuestion> PodcastQuestions { get; set; }
 

}