using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class PodcastGroup {
    public int Id { get; set; }

    [Display (Name = "عنوان گروه")]
    public string Title { get; set; }

    [UIHint ("ImageUpload")]
    [Display (Name = "آپلود تصویر")]
    public string ImageUrl { get; set; }
    public ICollection<Podcast> Podcasts { get; set; }

}