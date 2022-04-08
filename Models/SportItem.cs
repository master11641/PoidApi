using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class SportItem {
    public int Id { get; set; }

    [Display (Name = "عنوان حرکت")]
    public string Title { get; set; }

    [Display (Name = "توضیح حرکت")]
    public string Description { get; set; }

    [UIHint ("ImageUpload")]
    [Display (Name = "صوت حرکت")]
    public string DescriptionAudio { get; set; }

    [UIHint ("ImageUpload")]
    [Display (Name = "ویدیوی حرکت")]
    public string DescriptionVideo { get; set; }
    public ICollection<SImage> SImages { get; set; }

    
    public int SportId { get; set; }

    [ForeignKey ("SportId")]
    [Display (Name = "انتخاب ورزش")]
    public Sport Sport { get; set; }

}