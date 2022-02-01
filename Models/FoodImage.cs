using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class FoodImage {
    public int Id { get; set; }

    [Display (Name = "عنوان")]
    public string Title { get; set; }

    [Display (Name = "تصویر")]
    public string ImageUrl { get; set; }

    [Display (Name = "آیا تصویر اصلی باشد؟")]
    public bool IsMainImage { get; set; }

    [Display (Name = "غذا")]
    public int FoodId { get; set; }

    [ForeignKey ("FoodId")]
    public Food Food { get; set; }

}