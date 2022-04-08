using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class Sport {
    public int Id { get; set; }

    [Display (Name = "عنوان")]
    public string Title { get; set; }

    [UIHint ("ImageUpload")]
      [Display (Name = "آپلود تصویر")]
    public string ImageUrl { get; set; }
    [Display (Name = "ماهیچه های مربوطه")]
    public ICollection<SportMuscle> SportMuscles { get; set; } //many-to-many

    public ICollection<SportItem> SportItems { get; set; } //one-to-many
      [Display (Name = "گروه مربوطه")]
    public int SportGroupId { get; set; }
    [ForeignKey("SportGroupId")]
      [Display (Name = "گروه مربوطه")]
    public SportGroup SportGroup { get; set; }
}