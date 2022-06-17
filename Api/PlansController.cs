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
        private ToolsService _toolsService;
        public PlansController (BarnamaConntext context, ToolsService toolsService) {
            _context = context;
            _toolsService = toolsService;
        }

        [HttpPost ("AddVoiceDate")]
        public IActionResult AddVoiceDate (int UserId, DateTime CurrentDate, string VoiceUserUrl) {
            PlanDate PlanDate = _context.PlanDates.Include (x => x.Plan).ThenInclude (x => x.Diet).Where (x => x.CurrentDate.Date == CurrentDate.Date && x.Plan.Diet.UserId == UserId).FirstOrDefault ();
            if (PlanDate == null) {
                return BadRequest ("ابتدا برنامه رژیمی امروز خود را مشاهده کنید و سپس نظر خود را ارسال کنید ");
                // Plandate
            }
            PlanDate.VoiceUserUrl = VoiceUserUrl;
            _context.SaveChanges ();
            return Ok (PlanDate.Id);
        }
        //محاسبه انرژی کل بدن برای کاربر
        //که در اکشن متدها استفاده می شود
        double GetCallerieForUser (int userId) {
            var diet = _context.Diets.Include (x => x.Weights).Include (x => x.User).Where (x => x.RequestComplete == true).Include (x => x.User)
                .Include (x => x.Gender).FirstOrDefault (x => x.UserId == userId);
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
            if (bmi < 25) {
                callery = (double) (1.1 * 1.3 * 24 * g * weight);
            } else {
                double weightNormal = (double) (coefficient * ((diet.Height / 100) * (diet.Height / 100)));
                double ibw = (double) (weightNormal + ((weight - weightNormal) * 0.25));
                callery = 1.1 * 1.3 * 24 * g * ibw;
            }

            var result = new {
                fat = callery,
                description = description
            };
            return result.fat;
        }

        [HttpPost ("GetPlanByDate")]
        public IActionResult GetPlanByDate (int DietId, DateTime CurrentDate) {
            Diet CurrentDiet = _context.Diets.Include (x => x.Plan).Where (x => x.Id == DietId).Include (x => x.SicknessDiets).FirstOrDefault ();
            var invoices = _context.Invoices.Include (x => x.ServicePackage)
                .Where (x => x.UserId == CurrentDiet.UserId && x.IsConfirm == true).OrderByDescending (x => x.Id).ToList ();
            List<Course> courses = new List<Course> ();
            foreach (var temp in invoices) {
                Course course = new Course () {
                    StartDate = (DateTime) temp.PaymentDate,
                    EndDate = ((DateTime) temp.PaymentDate).AddDays (temp.ServicePackage.ExpireAfterBuyInDays)
                };
                courses.Add (course);
            }
            var invoice = invoices.FirstOrDefault ();
            double TotalCallory = GetCallerieForUser (CurrentDiet.UserId);
            if (CurrentDiet.Plan == null) {
                Plan Plan = new Plan ();
                Plan.CreationDate = DateTime.Now;
                Plan.EndDate = invoice == null ? DateTime.Now.AddDays (5) : ((DateTime) invoice.PaymentDate).AddDays (invoice.ServicePackage.ExpireAfterBuyInDays);
                Plan.DietId = DietId;
                Plan.Calorie = TotalCallory;
                CurrentDiet.Plan = Plan;
                // CurrentDiet.PlanId = 
                _context.SaveChanges ();
                CurrentDiet.PlanId = Plan.Id;
            }
            bool isApproved = false;
            foreach (var course in courses) {
                if (CurrentDate.Date >= course.StartDate.Date && CurrentDate < course.EndDate.Date) {
                    isApproved = true;
                }

            }
            if (isApproved == false) {
                return BadRequest ("رژیم فعالی در تاریخ فوق ندارید");
            }
            // if (CurrentDate.Date >= ((DateTime) invoice.PaymentDate).AddDays (invoice.ServicePackage.ExpireAfterBuyInDays).Date) {
            //     return BadRequest ("کاربر گرامی ، ابتدا پلنی را خریداری نموده و سپس مجدد اقدام نمایید .");
            // }
            // if (CurrentDate.Date < ((DateTime) invoice.PaymentDate).Date) {
            //     return BadRequest (String.Format ("کاربر گرامی ،تاریخ شروع رژیم شما {0} می باشد .", ((DateTime) invoice.PaymentDate).ToPersianDigitalDateTimeString ().Split (" ") [0]));
            // }
            // if (CurrentDate.Date > DateTime.Now.Date) {
            //     return BadRequest ("کاربر گرامی،رژیم های روزهای آینده را در همان روز مشاهده نمایید .");
            // }
            PlanDate PlanDate = _context.PlanDates.Include (x => x.PlanDetails).ThenInclude (x => x.Food)
                .Include (x => x.PlanDetails).ThenInclude (x => x.Meel)
                .Include (x => x.PlanDetails).ThenInclude (x => x.Unit)
                .Where (x => x.CurrentDate.Date == CurrentDate.Date && x.PlanId == CurrentDiet.PlanId).FirstOrDefault ();

            if (PlanDate == null) {
                PlanDate = new PlanDate ();
                PlanDate.CurrentDate = CurrentDate;
                PlanDate.PlanId = (int) CurrentDiet.PlanId;
                _context.PlanDates.Add (PlanDate);
                // CurrentDiet.Plan.PlanDates.Add (PlanDate);
                _context.SaveChanges ();

            } else if (PlanDate.PlanDetails != null && PlanDate.PlanDetails.Count != 0) {
                return Ok (PlanDate.PlanDetails.Where (x => x.ReplacePlanDetailId == null).Select (x => new {
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
            List<Food> AllFoods = new List<Food> ();
            //اگر کاربر دارای بیماری است فقط غذاهای همان بیماری را انتخاب می کنیم
            // if(CurrentDiet.SicknessDiets.Count != 0){
            if (CurrentDiet.SicknessDiets.Count != 0) {
                // AllFoods = _context.Foods.Include (x => x.SicknessFoods).Include (x => x.FoodMeels).Include (x => x.FoodUnits)
                //     .ThenInclude (x => x.Unit).Where (x => x.FoodUnits.Any (x => x.Calorie != null) && x.SicknessFoods.Any (x => CurrentDiet.SicknessDiets.Select (x => x.SicknessId).Contains (x.SicknessId))).ToList ();
               AllFoods = _context.Foods.Include (x => x.SicknessFoods).Include (x => x.FoodMeels).Include (x => x.FoodUnits)
                    .ThenInclude (x => x.Unit)
                    .Where (x => x.FoodUnits.Any (x => x.Calorie != null)  
                   ).ToList ();
                   //شناسه بیماری های کاربر
                   //
                   List<int> sickDietIds = CurrentDiet.SicknessDiets.Select (x => x.SicknessId).ToList (); 
                   List<int>  foodIdsMustNotBe=  AllFoods.SelectMany(x=>x.SicknessFoods)
                   .Where(x=>x.MustBe == false &&  sickDietIds.Contains(x.SicknessId)).Select(x=>x.FoodId).Distinct().ToList();               
                   AllFoods.RemoveAll(x=>foodIdsMustNotBe.Contains(x.Id));

                   
            // !x.SicknessFoods.Where(y=>y.MustBe == false).Any (x => CurrentDiet.SicknessDiets.Select (x => x.SicknessId).Contains (x.SicknessId))
            //AllFoods.RemoveAll();
            } else {
                AllFoods = _context.Foods.Include (x => x.FoodMeels).Include (x => x.FoodUnits)
                    .ThenInclude (x => x.Unit).Where (x => x.FoodUnits.Any (x => x.Calorie != null)).ToList ();
            }

            foreach (var CurrentMeel in Meels) {

                SavePlanDetailsForFood (AllFoods: AllFoods, CurrentMeel: CurrentMeel, PlanDate: PlanDate, TotalCallory: TotalCallory);
            }
            // _context.SaveChanges();
            PlanDate result = _context.PlanDates.Include (x => x.PlanDetails).Where (x => x.CurrentDate.Date == CurrentDate.Date).FirstOrDefault ();
            //  Console.WriteLine (result.PlanDetails.Sum(x=>x.Calorie));
            return Ok (result.PlanDetails.Where (x => x.ReplacePlanDetailId == null).Select (x => new {
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
            Food currentFood = _context.Foods.FirstOrDefault(x=>x.Id == foodId);
            //گرفتن غذاهایی که در وعده  غذای قبلی قرار دارند
            List<Food> AllFoods = _context.Foods.Include (x => x.FoodMeels)
                .Where (x => x.FoodMeels.Any (x => x.MeelId == planDetail.MeelId) && x.GroupId==currentFood.GroupId ).ToList ();
            return Ok (AllFoods.Select (x => new { x.Title, x.Id }));
        }

        [HttpPost ("ConfirmFood")]
        public IActionResult confirmFood (int planDateId, int foodId, int unitId, double unitValue) {
            PlanDetail planDetail = _context.PlanDetails.FirstOrDefault (x => x.FoodId == foodId && x.PlanDateId == planDateId);
            if (planDetail == null) {
                return BadRequest ("اطلاعات ارسالی اشتباه می باشد ");
            }
            planDetail.IsDone = planDetail.UnitId == unitId ? !planDetail.IsDone : true;
            planDetail.UnitId = unitId;
            planDetail.UnitValue = unitValue;

            _context.SaveChanges ();
            return Ok ();
        }

        [HttpPost ("ReplaceFood")]
        public IActionResult ReplaceFood (int planDateId, int oldFoodId, int unitId, double unitValue, int newFoodId) {
            PlanDetail planDetail = _context.PlanDetails.FirstOrDefault (x => x.FoodId == oldFoodId && x.PlanDateId == planDateId);
            if (planDetail == null) {
                return BadRequest ("اطلاعات ارسالی اشتباه می باشد ");
            }
            planDetail.IsDone = false;
            planDetail.ReplacePlanDetailId = newFoodId;
            PlanDetail newPlanDetail = new PlanDetail {
                FoodId = newFoodId,
                PlanDateId = planDateId,
                UnitId = unitId,
                UnitValue = unitValue,
                MeelId = planDetail.MeelId,
                Calorie = planDetail.Calorie,
                IsDone = false,

            };
            _context.PlanDetails.Add (newPlanDetail);
            _context.SaveChanges ();

            return Ok ();
        }
        //غذا در برنامه روز جاری تکراری نباشد
        bool IsFoodAcceprt (int foodId, List<PlanDetail> planDetails, List<Food> allFoods) {
            if (planDetails.Any (x => x.FoodId == foodId)) {
                allFoods.RemoveAll (x => x.Id == foodId);
                return false;
            }
            return true;
        }
        ///این تابع برای هر وعده غذایی یک بار صدا زده می  شود
        void SavePlanDetailsForFood (List<Food> AllFoods, Meel CurrentMeel, PlanDate PlanDate, double TotalCallory) {
            var FoodMeels = AllFoods.Where (x => x.FoodMeels.Any (y => y.MeelId == CurrentMeel.Id)).ToList ();
            Food CurrentFood;

            List<MeelProgram> programs = new List<MeelProgram> ();
            switch (CurrentMeel.Id) {
                case 1: //صبحانه
                    programs.Add (
                        new MeelProgram {
                            Calorie = (TotalCallory * CurrentMeel.Percent / 100) * 65 / 100,
                                CategoryIndexes = { 3 },
                        }
                    );
                    programs.Add (
                        new MeelProgram {
                            Calorie = (TotalCallory * CurrentMeel.Percent / 100) * 25 / 100,
                                CategoryIndexes = { 10 },
                        }
                    );
                    programs.Add (
                        new MeelProgram {
                            Calorie = (TotalCallory * CurrentMeel.Percent / 100) * 10 / 100,
                                CategoryIndexes = { 5, 4, 11, 6 },
                        }
                    );
                    programs.Add (
                        new MeelProgram {
                            Calorie = 0,
                                CategoryIndexes = { 13 },
                        }
                    );
                    break;
                case 2: //نهار
                    programs.Add (
                        new MeelProgram {
                            Calorie = (TotalCallory * CurrentMeel.Percent / 100) * 45 / 100,
                                CategoryIndexes = { 3 },
                        }
                    );
                    programs.Add (
                        new MeelProgram {
                            Calorie = (TotalCallory * CurrentMeel.Percent / 100) * 35 / 100,
                                CategoryIndexes = { 12, 1 },
                        }
                    );
                    programs.Add (
                        new MeelProgram {
                            Calorie = (TotalCallory * CurrentMeel.Percent / 100) * 10 / 100,
                                CategoryIndexes = { 4 },
                        }
                    );
                    programs.Add (
                        new MeelProgram {
                            Calorie = (TotalCallory * CurrentMeel.Percent / 100) * 10 / 100,
                                CategoryIndexes = { 10, 6 },
                        }
                    );
                    break;
                case 3: //شام
                    programs.Add (
                        new MeelProgram {
                            Calorie = (TotalCallory * CurrentMeel.Percent / 100) * 15 / 100,
                                CategoryIndexes = { 3 },
                        }
                    );
                    programs.Add (
                        new MeelProgram {
                            Calorie = (TotalCallory * CurrentMeel.Percent / 100) * 35 / 100,
                                CategoryIndexes = { 1 },
                        }
                    );
                    programs.Add (
                        new MeelProgram {
                            Calorie = (TotalCallory * CurrentMeel.Percent / 100) * 30 / 100,
                                CategoryIndexes = { 4 },
                        }
                    );
                    programs.Add (
                        new MeelProgram {
                            Calorie = (TotalCallory * CurrentMeel.Percent / 100) * 20 / 100,
                                CategoryIndexes = { 10, 6 },
                        }
                    );
                    break;
                case 4: //میان وعده صبح
                    programs.Add (
                        new MeelProgram {
                            Calorie = (TotalCallory * CurrentMeel.Percent / 100) * 70 / 100,
                                CategoryIndexes = { 5 },
                        }
                    );
                    programs.Add (
                        new MeelProgram {
                            Calorie = (TotalCallory * CurrentMeel.Percent / 100) * 30 / 100,
                                CategoryIndexes = { 10, 6, 4 },
                        }
                    );
                    programs.Add (
                        new MeelProgram {
                            Calorie = 0,
                                CategoryIndexes = { 13 },
                        }
                    );
                    break;
                case 5: //میان وعده عصر
                    programs.Add (
                        new MeelProgram {
                            Calorie = (TotalCallory * CurrentMeel.Percent / 100) * 20 / 100,
                                CategoryIndexes = { 3 },
                        }
                    );
                    programs.Add (
                        new MeelProgram {
                            Calorie = (TotalCallory * CurrentMeel.Percent / 100) * 20 / 100,
                                CategoryIndexes = { 1 },
                        }
                    );
                    programs.Add (
                        new MeelProgram {
                            Calorie = (TotalCallory * CurrentMeel.Percent / 100) * 50 / 100,
                                CategoryIndexes = { 5 },
                        }
                    );
                    programs.Add (
                        new MeelProgram {
                            Calorie = (TotalCallory * CurrentMeel.Percent / 100) * 10 / 100,
                                CategoryIndexes = { 11, 6 },
                        }
                    );
                    programs.Add (
                        new MeelProgram {
                            Calorie = 0,
                                CategoryIndexes = { 13 },
                        }
                    );
                    break;
                case 6: //میان وعده آخر شب
                    programs.Add (
                        new MeelProgram {
                            Calorie = (TotalCallory * CurrentMeel.Percent / 100) * 70 / 100,
                                CategoryIndexes = { 10 },
                        }
                    );
                    programs.Add (
                        new MeelProgram {
                            Calorie = (TotalCallory * CurrentMeel.Percent / 100) * 20 / 100,
                                CategoryIndexes = { 5 },
                        }
                    );
                    programs.Add (
                        new MeelProgram {
                            Calorie = (TotalCallory * CurrentMeel.Percent / 100) * 10 / 100,
                                CategoryIndexes = { 11, 6 }, //چربی ، قند ساده
                        }
                    );
                    break;

                default:

                    break;
            }
            foreach (var program in programs) {
                var tempFoods = FoodMeels.Where (x => program.CategoryIndexes.Contains (x.GroupId)).ToList ();
                CurrentFood = tempFoods[new Random ().Next (0, tempFoods.Count - 1)];
                if (PlanDate.PlanDetails != null && PlanDate.PlanDetails.Count != 0) {
                    while (IsFoodAcceprt (CurrentFood.Id, PlanDate.PlanDetails.ToList (), AllFoods) == false) {
                        CurrentFood = tempFoods[new Random ().Next (0, tempFoods.Count - 1)];
                    }
                }

                double meelCallory = program.Calorie;
                // double tempCalorieCounter = 0;
                // double UnitValue = 0;
                PlanDetail PlanDetail = new PlanDetail ();
                FoodUnit CurrentFoodUnit = CurrentFood.FoodUnits.FirstOrDefault (x => x.IsDefault == true) ?? CurrentFood.FoodUnits.FirstOrDefault ();
                PlanDetail.Meel = CurrentMeel;
                PlanDetail.PlanDateId = PlanDate.Id;
                PlanDetail.UnitId = CurrentFoodUnit.UnitId;
                PlanDetail.FoodId = CurrentFood.Id;
                // while (tempCalorieCounter <= meelCallory) {
                //     UnitValue++;
                //     PlanDetail.UnitValue = UnitValue;
                //     tempCalorieCounter += CurrentFoodUnit.Calorie ?? 0;
                // }
                // PlanDetail.Calorie = tempCalorieCounter;
                if (meelCallory == 0) {
                    PlanDetail.Calorie = 0;
                    PlanDetail.UnitValue = 1;
                } else {
                    ReplaceFood replaceFood = GetReplaceUnitAndCalorie (CurrentFood.Id, meelCallory, CurrentFoodUnit.UnitId);
                    PlanDetail.Calorie = meelCallory;
                    PlanDetail.UnitValue = replaceFood.UnitValue;

                }

                PlanDate.PlanDetails.Add (PlanDetail);
            }

            //  _context.PlanDetails.Add(PlanDetail);
            _context.SaveChanges ();
        }
        //         ReplaceFood GeCalorieForProgram (int FoodId, double Calorie, int UnitId) {
        //     //ابتدا فود یونیت را برای استفاده از فیلد کالری آن بدست می آوریم
        //     FoodUnit foodUnit = _context.FoodUnits.Include (x => x.Unit).Include (x => x.Food).FirstOrDefault (x => x.UnitId == UnitId && x.FoodId == FoodId);
        //     double tempCalorieCounter = 0;
        //     double UnitValue = 0;
        //     while (tempCalorieCounter <= Calorie) {

        //         if (tempCalorieCounter + foodUnit.Calorie > Calorie) {
        //             double pecrcent = GetCaloriePercent (Calorie - tempCalorieCounter, (double) foodUnit.Calorie);
        //             UnitValue += pecrcent;
        //             tempCalorieCounter += pecrcent * (double) foodUnit.Calorie;
        //             break;
        //         } else {
        //             UnitValue++;
        //             tempCalorieCounter += (double) foodUnit.Calorie;
        //         }

        //     }
        //     ReplaceFood ReplaceFood = new ReplaceFood {
        //         Calorie = tempCalorieCounter,
        //         UnitId = UnitId,
        //         UnitTitle = foodUnit.Unit.Title,
        //         FoodTitle = foodUnit.Food.Title,
        //         UnitValue = UnitValue,
        //         FoodId = FoodId

        //     };
        //     return ReplaceFood;
        // }
        // Food getFoodByMeel(List<Food> AllFoods , Meel CurrentMeel){
        //      Food CurrentFood ;

        //      return CurrentFood;
        // }
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
                    double pecrcent = GetCaloriePercent (Calorie - tempCalorieCounter, (double) foodUnit.Calorie);
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
            double result = tempCalorieCounter / calorie;
            return result;

        }
        //لیستی از واحدهای سنجش برای یک غذا
        //به میزان کالری مشخص بر می گرداند
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

        [HttpPost ("GetFoodAndUnitsById")]
        public IActionResult GetFoodAndUnitsById (int foodId) {
            Food food = _context.Foods.Include (x => x.FoodUnits).ThenInclude (x => x.Unit).FirstOrDefault (x => x.Id == foodId);
            if (food == null) {
                return BadRequest ("غذای مورد نظر پیدا نشد");
            }

            return Ok (food.FoodUnits.Select (x => new {
                x.Calcium,
                    x.Calorie,
                    x.Carbohydrate,
                    FoodTitle = x.Food.Title,
                    UnitId = x.Unit.Id,
                    UnitName = x.Unit.Title,
                    x.Fat,
                    x.Iron,
                    x.IsDefault,
                    x.Magnesium,
                    x.Phosphor,
                    x.Potassium,
                    x.Protein,
                    x.Sfa,
                    x.Sodium,
                    x.Sugar,
                    x.Tfa,
                    x.Umfa,
                    x.Upfa
            }));
        }

        [HttpPost ("GetPlanInfo")]
        public IActionResult GetPlanInfo (int userId) {
            var diet = _context.Diets.Where (x => x.UserId == userId).OrderByDescending (x => x.Id).FirstOrDefault ();
            return Ok (_toolsService.GetActivePlanInfo (diet.Id));
        }
    }

}