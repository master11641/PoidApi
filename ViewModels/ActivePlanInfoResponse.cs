using System;
using System.Collections.Generic;

public class ActivePlanInfoResponse {
    public ActivePlanInfoResponse(){
        Courses = new List<Course>();
    }
    public int UserId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public double Bmi { get; set; }
    public double Calorie { get; set; }
    public string Description { get; set; }
    public double NormalWeight { get; set; }
    public double CurrentWeight { get; set; }
    public ICollection<Course> Courses { get; set; }

}

public class Course {
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
}