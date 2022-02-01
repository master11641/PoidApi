using System;
using System.ComponentModel.DataAnnotations.Schema;


public class Invoice {
    public int Id { get; set; }
    public int ServicePackageId { get; set; }

    [ForeignKey ("ServicePackageId")]
    public ServicePackage ServicePackage { get; set; }
    public string RefId { get; set; }
    public DateTime RegisterDate { get; set; }
    [NotMapped]
    [DatabaseGenerated (DatabaseGeneratedOption.None)]
    public string PersianPaymentDate { get { return PaymentDate?.ToPersianDateTime().ToPersianDateString() ;}  private set{ } }
    public DateTime? PaymentDate { get; set; }
    public int Amount { get; set; }
    public string Authority { get; set; }
    public int UserId { get; set; }
    public bool IsConfirm { get; set; }

    [ForeignKey ("UserId")]
    public User User { get; set; }

}