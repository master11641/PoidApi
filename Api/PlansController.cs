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
        public IActionResult AddVoiceDate (int UserId,DateTime CurrentDate, string VoiceUserUrl) {
            PlanDate PlanDate = _context.PlanDates.Include(x=>x.Plan).ThenInclude(x=>x.Diet).Where (x=>x.CurrentDate.Date==CurrentDate.Date && x.Plan.Diet.UserId==UserId).FirstOrDefault();
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
            if(DateTime.Now > CurrentDiet.Plan.EndDate){
                return BadRequest("کاربر گرامی ، ابتدا پلنی را خریداری نموده و سپس مجدد اقدام نمایید .");
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

    }

}