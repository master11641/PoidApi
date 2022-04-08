using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class SImage {
    public int Id { get; set; }

    [UIHint ("ImageUpload")]
    [Display (Name = "آپلود تصویر")]
    public string ImageUrl { get; set; }
    // public ICollection<SportItemImage> SportItemImages { get; set; }
    public int SportItemId { get; set; }
    [ForeignKey("SportItemId")]
    public SportItem SportItem { get; set; }

}