using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class Group {
    public int Id { get; set; }
    [Display(Name="عنوان")]
    public string Title { get; set; }
    [Display(Name="تصویر")]
     public string ImageUrl { get; set; }
   
   public ICollection<Food> Foods { get; set; }
 

}