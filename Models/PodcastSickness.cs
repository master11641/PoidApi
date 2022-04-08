using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class PodcastSickness{

    public int  PodcastId { get; set; }
    public Podcast Podcast { get; set; }
    public int SicknessId { get; set; }
    public Sickness   Sickness { get; set; }
  

}