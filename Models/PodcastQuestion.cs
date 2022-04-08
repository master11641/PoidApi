using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class PodcastQuestion{

    public int  PodcastId { get; set; }
    public Podcast Podcast { get; set; }
    public int QuestionId { get; set; }
    public Question   Question { get; set; }
  

}