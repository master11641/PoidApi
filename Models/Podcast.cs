using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class Podcast {
    public int Id { get; set; }

    [Display (Name = "عنوان پادکست")]
    public string Title { get; set; }

    [Display (Name = "عنوان گروه")]
    public int PodcastGroupId { get; set; }

    [Display (Name = "عنوان گروه")]

    [ForeignKey ("PodcastGroupId")]
    public PodcastGroup PodcastGroup { get; set; }

    [Display (Name = "آپلود صوت پادکست")]
    [UIHint ("ImageUpload")]
    public string PodcastAudio { get; set; }

    [Display (Name = "سوال های مرتبط")]
    public ICollection<PodcastQuestion> PodcastQuestions { get; set; }

    [Display (Name = "مریضی های مرتبط")]
    public ICollection<PodcastSickness> PodcastSicknesses { get; set; }

}