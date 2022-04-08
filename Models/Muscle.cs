using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class Muscle {
    public int Id { get; set; }

    [Display (Name = "عنوان عضله")]
    public string Title { get; set; }

    [UIHint ("ImageUpload")]
    [Display (Name = "تصویر عضله")]
    public string ImageUrl { get; set; }
    public ICollection<SportMuscle> SportMuscles { get; set; }

}