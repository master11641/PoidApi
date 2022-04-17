using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSharp;
namespace Barnama.Controllers {

    [Route ("Api")]
    public class PlansController : Controller {
        private BarnamaConntext _context;
        public PlansController (BarnamaConntext context) {
            _context = context;
        }

        [HttpPost ("AddVoiceDate")]
        public IActionResult AddVoiceDate (int UserId, DateTime CurrentDate, string VoiceUserUrl) {
            PlanDate PlanDate = _context.PlanDates.Include (x => x.Plan).ThenInclude (x => x.Diet).Where (x => x.CurrentDate.Date == CurrentDate.Date && x.Plan.Diet.UserId == UserId).FirstOrDefault ();
            if (PlanDate == null) {
                return BadRequest ("رژیم مربوطه یافت نشد");
            }
            PlanDate.VoiceUserUrl = VoiceUserUrl;
            _context.SaveChanges ();
            return Ok (PlanDate.Id);
        }

        [HttpPost ("GetPlanByDate")]
        public IActionResult GetPlanByDate (int DietId, DateTime CurrentDate) {
            Diet CurrentDiet = _context.Diets.Include (x => x.Plan).Where (x => x.Id == DietId).FirstOrDefault ();
            double TotalCallory = 2700;
            if (CurrentDiet.Plan == null) {
                Plan Plan = new Plan ();
                Plan.CreationDate = DateTime.Now;
                Plan.EndDate = DateTime.Now.AddDays (30);
                Plan.DietId = DietId;
                Plan.Calorie = TotalCallory;
                CurrentDiet.Plan = Plan;
                // CurrentDiet.PlanId = 
                Plan.Id = _context.SaveChanges ();
            }
            if (DateTime.Now > CurrentDiet.Plan.EndDate) {
                return BadRequest ("کاربر گرامی ، ابتدا پلنی را خریداری نموده و سپس مجدد اقدام نمایید .");
            }
            PlanDate PlanDate = _context.PlanDates.Include (x => x.PlanDetails).ThenInclude (x => x.Food)
                .Include (x => x.PlanDetails).ThenInclude (x => x.Meel)
                .Include (x => x.PlanDetails).ThenInclude (x => x.Unit)
                .Where (x => x.CurrentDate.Date == CurrentDate.Date).FirstOrDefault ();

            if (PlanDate == null) {
                PlanDate = new PlanDate ();
                PlanDate.CurrentDate = CurrentDate;
                PlanDate.PlanId = CurrentDiet.PlanId ?? 0;
                _context.PlanDates.Add (PlanDate);
                int temp = _context.SaveChanges ();
                Console.WriteLine (temp);

            } else if (PlanDate.PlanDetails != null && PlanDate.PlanDetails.Count != 0) {
                return Ok (PlanDate.PlanDetails.Select (x => new {
                    foodTitle = x.Food.Title,
                        x.Calorie,
                        meelTitle = x.Meel.Title,
                        x.UnitValue,
                        unitTitle = x.Unit.Title,
                        x.UnitId,
                        x.FoodId,
                        x.MeelId,
                        x.IsDone,
                        x.PlanDateId,
                        OrderId = x.Meel.OrderId

                }));
            }
            //  PlanDate.PlanDetails.Clear ();
            //گرفتن کلیه وعده های غذایی تعریف شده
            List<Meel> Meels = _context.Meels.Include (x => x.FoodMeels).ToList ();
            //گرفتن تمامی غذایهایی که حداقل یک واحد سنجش دارند
            List<Food> AllFoods = _context.Foods.Include (x => x.FoodMeels).Include (x => x.FoodUnits)
                .ThenInclude (x => x.Unit).Where (x => x.FoodUnits.Any (x => x.Calorie != null)).ToList ();
            foreach (var CurrentMeel in Meels) {

                SavePlanDetailsForFood (AllFoods: AllFoods, CurrentMeel: CurrentMeel, PlanDate: PlanDate, TotalCallory: TotalCallory);
            }
            // _context.SaveChanges();
            PlanDate result = _context.PlanDates.Include (x => x.PlanDetails).Where (x => x.CurrentDate.Date == CurrentDate.Date).FirstOrDefault ();
            return Ok (result.PlanDetails.Select (x => new {
                foodTitle = x.Food.Title,
                    x.Calorie,
                    meelTitle = x.Meel.Title,
                    x.UnitValue,
                    unitTitle = x.Unit.Title,
                    x.UnitId,
                    x.FoodId,
                    x.MeelId,
                    OrderId = x.Meel.OrderId
            }));

        }
        //غداهای جایگزین برای کاربر بر می گرداند
        [HttpPost ("GetReplaceFood")]
        public IActionResult GetReplaceFood (int planDateId, int foodId) {
            PlanDetail planDetail = _context.PlanDetails.FirstOrDefault (x => x.FoodId == foodId && x.PlanDateId == planDateId);
            if (planDetail == null) {
                return BadRequest ("اطلاعات ارسالی اشتباه می باشد ");
            }
            //گرفتن غذاهایی که در وعده  غذای قبلی قرار دارند
            List<Food> AllFoods = _context.Foods.Include (x => x.FoodMeels)
                .Where (x => x.FoodMeels.Any (x => x.MeelId == planDetail.MeelId)).ToList ();
            return Ok (AllFoods.Select (x => new { x.Title }));
        }

        [HttpPost ("ConfirmFood")]
        public IActionResult confirmFood (int planDateId, int foodId) {
            PlanDetail planDetail = _context.PlanDetails.FirstOrDefault (x => x.FoodId == foodId && x.PlanDateId == planDateId);
            if (planDetail == null) {
                return BadRequest ("اطلاعات ارسالی اشتباه می باشد ");
            }
            planDetail.IsDone = !planDetail.IsDone;
            _context.SaveChanges ();
            return Ok ();
        }
        bool IsFoodAcceprt (int foodId, List<PlanDetail> planDetails, List<Food> allFoods) {
            if (planDetails.Any (x => x.FoodId == foodId)) {
                allFoods.RemoveAll (x => x.Id == foodId);
                return false;
            }
            return true;
        }

        void SavePlanDetailsForFood (List<Food> AllFoods, Meel CurrentMeel, PlanDate PlanDate, double TotalCallory) {
            var FoodMeels = AllFoods.Where (x => x.FoodMeels.Any (y => y.MeelId == CurrentMeel.Id)).ToList ();
            var CurrentFood = FoodMeels[new Random ().Next (0, FoodMeels.Count - 1)];
            for (int i = 0; i < 2; i++) {
                if (PlanDate.PlanDetails != null && PlanDate.PlanDetails.Count != 0) {
                    while (IsFoodAcceprt (CurrentFood.Id, PlanDate.PlanDetails.ToList (), AllFoods) == false) {
                        CurrentFood = FoodMeels[new Random ().Next (0, FoodMeels.Count - 1)];
                    }
                }

                double meelCallory = (TotalCallory * (CurrentMeel.Percent * 1 / 2) / 100);
                double tempCalorieCounter = 0;
                double UnitValue = 0;
                PlanDetail PlanDetail = new PlanDetail ();
                FoodUnit CurrentFoodUnit = CurrentFood.FoodUnits.FirstOrDefault ();
                PlanDetail.Meel = CurrentMeel;
                PlanDetail.PlanDateId = PlanDate.Id;
                PlanDetail.UnitId = CurrentFoodUnit.UnitId;
                PlanDetail.FoodId = CurrentFood.Id;
                while (tempCalorieCounter <= meelCallory) {
                    UnitValue++;
                    PlanDetail.UnitValue = UnitValue;
                    tempCalorieCounter += CurrentFoodUnit.Calorie ?? 0;
                }
                PlanDetail.Calorie = tempCalorieCounter;
                PlanDate.PlanDetails.Add (PlanDetail);
            }

            //  _context.PlanDetails.Add(PlanDetail);
            _context.SaveChanges ();
        }
        //با گرفتن شناسه واحد سنجش جدید تغییرات لازم یعنی
        //کالری و واحد جدیدو یونیت ولیو را جایگزین پلن دیتیل کرده و بر می گرداند 
        ReplaceFood GetReplaceUnitAndCalorie (int FoodId, double Calorie, int UnitId) {
            //ابتدا فود یونیت را برای استفاده از فیلد کالری آن بدست می آوریم
            FoodUnit foodUnit = _context.FoodUnits.Include (x => x.Unit).Include (x => x.Food).FirstOrDefault (x => x.UnitId == UnitId && x.FoodId == FoodId);
            double tempCalorieCounter = 0;
            double UnitValue = 0;
            while (tempCalorieCounter <= Calorie) {
                //  UnitValue++;
                // tempCalorieCounter += foodUnit.Calorie ?? 0;
                //    UnitValue +=  (tempCalorieCounter+foodUnit.Calorie ) > Calorie ? GetCaloriePercent(foodUnit.Calorie ?? 0,Calorie  ) : 1;
                //    tempCalorieCounter += (tempCalorieCounter+foodUnit.Calorie ) > Calorie ? GetCaloriePercent(foodUnit.Calorie ?? 0,Calorie  )*foodUnit.Calorie ?? 0 : foodUnit.Calorie  ?? 0;
                if (tempCalorieCounter + foodUnit.Calorie > Calorie) {
                    double pecrcent = GetCaloriePercent (Calorie-tempCalorieCounter,(double) foodUnit.Calorie);
                    UnitValue += pecrcent;
                    tempCalorieCounter += pecrcent * (double) foodUnit.Calorie;
                    break;
                } else {
                    UnitValue++;
                    tempCalorieCounter += (double) foodUnit.Calorie;
                }

            }
            ReplaceFood ReplaceFood = new ReplaceFood {
                Calorie = tempCalorieCounter,
                UnitId = UnitId,
                UnitTitle = foodUnit.Unit.Title,
                FoodTitle = foodUnit.Food.Title,
                UnitValue = UnitValue,
                FoodId = FoodId

            };
            return ReplaceFood;
        }
        double GetCaloriePercent (double tempCalorieCounter, double calorie) {
            double result = tempCalorieCounter/calorie ;
            return result;

        }

        [HttpPost ("GetAllUnitPlanByFood")]
        public IActionResult GetAllUnitPlanByFood (double calorie, int foodId) {
            List<FoodUnit> foodUnits = _context.FoodUnits.Where (x => x.FoodId == foodId).ToList ();
            List<ReplaceFood> replaceFoods = new List<ReplaceFood> ();
            foreach (var item in foodUnits) {
                ReplaceFood temp = GetReplaceUnitAndCalorie (item.FoodId, calorie, item.UnitId);
                replaceFoods.Add (temp);

            }
            return Ok (replaceFoods);
        }
    }

}