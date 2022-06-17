using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

public class ToolsService {

    private BarnamaConntext _context;
    public ToolsService (BarnamaConntext context) {
        _context = context;
    }

    public ActivePlanInfoResponse GetActivePlanInfo (int DietId) {
        ActivePlanInfoResponse PlanInfo = new ActivePlanInfoResponse ();
        Diet CurrentDiet = _context.Diets.Include (x => x.Plan).Where (x => x.Id == DietId).Include (x => x.SicknessDiets).FirstOrDefault ();
        PlanInfo.UserId = CurrentDiet.UserId;
        GetCallerieForUser (PlanInfo); //برخی فیلدهای این شی را تکمیل می کند
        var invoices = _context.Invoices.Include (x => x.ServicePackage).
        Where (x => x.UserId == CurrentDiet.UserId && x.IsConfirm == true).OrderByDescending (x => x.Id).ToList ();
        var invoice = invoices.FirstOrDefault ();
        if (invoice == null) {
            ServicePackage freePackage = _context.ServicePackages.Where (x => x.Price == 0).FirstOrDefault ();
            invoice = new Invoice {
                Amount = 0,
                PaymentDate = DateTime.Now,
                IsConfirm = true,
                RegisterDate = DateTime.Now,
                ServicePackageId = freePackage.Id,
                UserId = CurrentDiet.UserId,
                RefId = "free package",
                Authority = "free package",
            };
            _context.Invoices.Add (invoice);
            _context.SaveChanges ();
            invoices.Add (invoice);
        }

        if (CurrentDiet.Plan == null) {
            Plan Plan = new Plan ();
            Plan.CreationDate = DateTime.Now;
            Plan.EndDate = ((DateTime) invoice.PaymentDate).AddDays (invoice.ServicePackage.ExpireAfterBuyInDays);
            Plan.DietId = DietId;
            Plan.Calorie = PlanInfo.Calorie;
            Plan.StartDate = (DateTime) invoice.PaymentDate;
            CurrentDiet.Plan = Plan;
            _context.SaveChanges ();
            CurrentDiet.PlanId = Plan.Id;
        }
        // var diffInDays = (DateTime.Now - (DateTime) invoice.PaymentDate).Days;
        // int remindInDays = invoice.ServicePackage.ExpireAfterBuyInDays - diffInDays;
        PlanInfo.StartDate = (DateTime) invoice.PaymentDate;
        PlanInfo.EndDate = ((DateTime) invoice.PaymentDate).AddDays (invoice.ServicePackage.ExpireAfterBuyInDays);
        PlanInfo.Calorie = PlanInfo.Calorie;
        foreach (var temp in invoices) {
            Course course = new Course () {
                StartDate = (DateTime) temp.PaymentDate,
                EndDate = ((DateTime) temp.PaymentDate).AddDays (temp.ServicePackage.ExpireAfterBuyInDays)
            };
            PlanInfo.Courses.Add(course);
        }
        return PlanInfo;

    }
    void GetCallerieForUser (ActivePlanInfoResponse PlanInfo) {
        var diet = _context.Diets.Include (x => x.Weights).Include (x => x.User).Where (x => x.RequestComplete == true)
            .Include (x => x.User).Include (x => x.Gender).FirstOrDefault (x => x.UserId == PlanInfo.UserId);
        double weight = diet.Weights.LastOrDefault ().UserWeight;
        var bmi = weight / ((diet.Height / 100) * (diet.Height / 100));
        string description = "";
        double g = 0;

        if (diet.Gender.Title.Contains ("مرد")) {
            g = 1; //مرد
        } else {
            g = 0.95; //زن
        }
        double callery = 0;
        int coefficient = 0;
        if (diet.Age < 30) {
            coefficient = 21;
        } else if (diet.Age < 50) {
            coefficient = 23;
        } else {
            coefficient = 24;
        }
        double weightNormal = (double) (coefficient * ((diet.Height / 100) * (diet.Height / 100)));
        double ibw = (double) (weightNormal + ((weight - weightNormal) * 0.25));
        PlanInfo.NormalWeight = weightNormal;
        if (bmi < 25) {
            callery = (double) (1.1 * 1.3 * 24 * g * weight);
        } else {
            callery = 1.1 * 1.3 * 24 * g * ibw;
        }

        if (bmi < 18.5) {
            description = "لاغر-دچار کمبود وزن";
        } else if (bmi > 18.5 && bmi < 25) {
            description = "وزن نرمال";
        } else if (bmi >= 25 && bmi < 30) {
            description = "اضافه وزن";
        } else if (bmi >= 30 && bmi < 35) {
            description = "چاقی درجه یک";
        } else if (bmi >= 35 && bmi < 40) {
            description = "چاقی درجه دو";
        } else {
            description = "چاقی درجه سه";
        }
        PlanInfo.CurrentWeight = weight;
        PlanInfo.Bmi = (double) bmi;
        PlanInfo.Calorie = callery;
        PlanInfo.Description = description;

    }

}