using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Barnama.Models;

public class User {
    public int Id { get; set; }
    public string Name { get; set; }
    public string Family { get; set; }
    public string FcmToken { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public DateTime RegisterDate { get; set; } = DateTime.Now;
    [JsonIgnore]
    public string Password { get; set; }
    public string ImageProfileUrl { get; set; }
    public string IntroducedUserPhone { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<Invoice> Invoices { get; set; }

 

}