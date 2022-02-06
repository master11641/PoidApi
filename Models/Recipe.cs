using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class Recipe {
    public int Id { get; set; }

    [Display (Name = "عنوان")]
    public string Title { get; set; }

    [Display (Name = "توضیحات")]
    public string Description { get; set; }
    public int FoodId { get; set; }
    [ForeignKey("FoodId")]
   public Food Food { get; set; }

}