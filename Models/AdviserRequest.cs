using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
public class AdviserRequest {
    public int Id { get; set; }
     [Display (Name = "کاربر درخواست کننده")]
    public int UserSenderId { get; set; }

    [ForeignKey ("UserSenderId")]
    public User UserSender { get; set; }
     [Display (Name = "مشاور انتخاب شده")]  
    public string UserRecievedPhone { get; set; }
     [Display (Name = "زمان درخواست")]
    public DateTime RequestTime { get; set; }
    public bool IsDone { get; set; }
}