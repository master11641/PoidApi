using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Role {
    public int Id { get; set; }
    public string Title { get; set; }
public ICollection<UserRole> UserRoles{get;set;}


}