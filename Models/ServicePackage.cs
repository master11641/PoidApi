using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.AccessControl;

public class ServicePackage {
    public int Id { get; set; }

    [Display (Name = "عنوان")]
    public string Title { get; set; }

    [Display (Name = "توضیحات")]
    public string Desciption { get; set; }

    [UIHintAttribute ("ImageUpload")]

    [Display (Name = "تصویر")]
    public string ImageUrl { get; set; }

    [Display (Name = "قیمت")]
    public int Price { get; set; }

    [Display (Name = "تاریخ شروع")]
    public DateTime? StartTime { get; set; }

    [NotMapped]
    [DatabaseGenerated (DatabaseGeneratedOption.None)]
    public string PersianStartTime { get { return StartTime?.ToPersianDateTime ().ToPersianDateString (); } private set { } }

    [Display (Name = "تاریخ پایان")]
    public DateTime? EndTime { get; set; }

    [NotMapped]
    [DatabaseGenerated (DatabaseGeneratedOption.None)]
    public string PersianEndTime { get { return EndTime?.ToPersianDateTime ().ToPersianDateString (); } private set { } }
    [Display (Name = "پکیج مشاوره ای باشد")]
    public bool IsAdviserType { get; set; }
    [Display (Name = "مدت زمان اعتبار بعد از خرید بر حسب روز")]
    public int ExpireAfterBuyInDays { get; set; }

    [Display (Name = "انتخاب تخفیف")]
    public int? DiscountId { get; set; }

    [ForeignKey ("DiscountId")]
    public Discount Discount { get; set; }

    [Display (Name = "شناسه محصول در کافه بازار")]
    public string BazarProductId { get; set; }

}