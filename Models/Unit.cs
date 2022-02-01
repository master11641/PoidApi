using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class Unit {
    public int Id { get; set; }
     [Display(Name="عنوان واحد")]
    public string Title { get; set; }
    public ICollection<FoodUnit> FoodUnits { get; set; }
     [Display(Name="تصویر (غیر ضروری)")]
    public string ImageUrl { get; set; }

}