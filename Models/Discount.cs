using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

public class Discount {
    public int Id { get; set; }

    [Display (Name = "عنوان")]
    public string Title { get; set; }
     [Display (Name = "کد")]
    public string Code { get; set; }
    [Display (Name = "حداکثر استفاده")]
    public int UsageRestrictions { get; set; }
    [Display (Name = "توضیحات")]
    public string Desciption { get; set; }
    [Display (Name = "تصویر")]
    public string ImageUrl { get; set; }
    [Display (Name = "کاربران")]
    public string UserNames { get; set; }
    [Display (Name = "درصد تخفیف")]
    public double Percentage { get; set; }
    [Display (Name = "زمان شروع تخفیف")]
    public DateTime? StartTime { get; set; }
    [Display (Name = "زمان پایان تخفیف")]
    public DateTime? EndTime { get; set; }
    public ICollection<ServicePackage> servicePackages { get; set; }
    [Display (Name = "شناسه محصول در کافه بازار")]
    public string BazarProductId { get; set; }

}