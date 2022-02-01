using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

public class ExaminRegister {

    public int Id { get; set; }
    public string Title { get; set; }
    public DateTime DateTest { get; set; }
    public double Percent { get; set; }
    public int UserId { get; set; }

    [ForeignKey ("UserId")]
    public User User { get; set; }



 

}