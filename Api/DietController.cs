using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace Barnama.Controllers {

    [Route ("Api")]
    public class DietController : Controller {
        private BarnamaConntext _context;
        public DietController (BarnamaConntext context) {
            _context = context;;
        }

        [HttpGet ("GetUserDiet")]
        public IActionResult GetUserDiet (int userId) {
            var diet = _context.Diets.Include (x => x.User).Where (x => x.RequestComplete != true).FirstOrDefault ();
            return Ok (diet);
        }

        [HttpPost ("GetBmiUser")]
        public IActionResult GetBmiUser (int userId) {
            var diet = _context.Diets.Include (x => x.User).Where (x => x.RequestComplete == true).FirstOrDefault ();
            if (diet == null) {
                return BadRequest ("اطلاعات شما کامل نیست");
            }
            var bmi = diet.Weight / ((diet.Height / 100) * (diet.Height / 100));
            string description = "";
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
            var result = new {
                bmi = bmi,
                description = description
            };
            return Ok (result);
        }

        [HttpPost ("GetFatUser")]
        public IActionResult GetFatUser (int userId) {

            var diet = _context.Diets.Include (x => x.User).Where (x => x.RequestComplete == true).Include (x => x.User).Include (x => x.Gender).FirstOrDefault ();
            if (diet == null) {
                return BadRequest ("اطلاعات شما کامل نیست");
            }
            var bmi = diet.Weight / ((diet.Height / 100) * (diet.Height / 100));
            string description = "";
            int g = 0;
            if (diet.Gender.Title.Contains ("مرد")) {
                g = 1; //مرد
            } else {
                g = 0; //زن
            }
            var fat = (1.2 * bmi) + (0.23 * diet.Age) - (10.8 * g) - 5.4;
            if (g == 1) {
                if (fat >= 20 && fat <= 25) {
                    description = "درصد چربی بدن زیاد بوده و احتمال خطر سلامت متابولیک و چاقی وجود دارد .";
                }
            } else {
                if (fat >= 25 && fat <= 32) {
                    description = "درصد چربی بدن زیاد بوده و احتمال خطر سلامت متابولیک و چاقی وجود دارد .";
                }
            }

            var result = new {
                fat = fat,
                description = description
            };
            return Ok (result);
        }

        [HttpPost ("GetCalleryUser")]
        public IActionResult GetCalleryUser (int userId) {

            var diet = _context.Diets.Include (x => x.User).Where (x => x.RequestComplete == true).Include (x => x.User).Include (x => x.Gender).FirstOrDefault ();
            if (diet == null) {
                return BadRequest ("اطلاعات شما کامل نیست");
            }
            var bmi = diet.Weight / ((diet.Height / 100) * (diet.Height / 100));
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
                callery = (double) (1.1 * 1.3 * 24 * g * diet.Weight);
            } else {
                double weightNormal = (double) (coefficient * ((diet.Height / 100) * (diet.Height / 100)));
                double ibw = (double) (weightNormal + ((diet.Weight - weightNormal) * 0.25));
                callery = 1.1 * 1.3 * 24 * g * ibw;
            }

            var result = new {
                fat = callery,
                description = description
            };
            return Ok (result);
        }

        [HttpPost ("SetGoalUser")]
        public IActionResult SetGoalUser (int userId, int goalId) {
            var diet = _context.Diets.Include (x => x.User).Where (x => x.UserId == userId).FirstOrDefault ();
            if (diet == null) {
                return BadRequest ("رژیم قابل ویرایش وجود ندارد .");
            }
            diet.GoalId = goalId;
            _context.SaveChanges ();
            return Ok (goalId);
        }

        [HttpPost ("SetGenderUser")]
        public IActionResult SetGenderUser (int userId, int genderId) {
            var diet = _context.Diets.Where (x => x.UserId == userId).FirstOrDefault ();
            if (diet == null) {
                return BadRequest ("رژیم قابل ویرایش وجود ندارد .");
            }
            diet.GenderId = genderId;
            _context.SaveChanges ();
            return Ok (genderId);
        }

        [HttpPost ("SetAgeUser")]
        public IActionResult SetAgeUser (int userId, double age) {
            var diet = _context.Diets.Where (x => x.UserId == userId && x.RequestComplete != true).FirstOrDefault ();
            if (diet == null) {
                return BadRequest ("رژیم قابل ویرایش وجود ندارد .");
            }
            diet.Age = age;
            _context.SaveChanges ();
            return Ok (int.Parse (age.ToString ()));
        }

        [HttpPost ("SetHeightUser")]
        public IActionResult SetHeightUser (int userId, double height) {
            var diet = _context.Diets.Where (x => x.UserId == userId && x.RequestComplete != true).FirstOrDefault ();
            if (diet == null) {
                return BadRequest ("رژیم قابل ویرایش وجود ندارد .");
            }
            diet.Height = height;
            _context.SaveChanges ();
            return Ok (height);
        }

        [HttpPost ("SetWaistUser")]
        public IActionResult SetWaistUser (int userId, double waist) {
            var diet = _context.Diets.Where (x => x.UserId == userId && x.RequestComplete != true).FirstOrDefault ();
            if (diet == null) {
                return BadRequest ("رژیم قابل ویرایش وجود ندارد .");
            }
            diet.Waist = waist;
            _context.SaveChanges ();
            return Ok (waist);
        }

        [HttpPost ("SetWristUser")]
        public IActionResult SetWristUser (int userId, double wrist) {
            var diet = _context.Diets.Where (x => x.UserId == userId && x.RequestComplete != true).FirstOrDefault ();
            if (diet == null) {
                return BadRequest ("رژیم قابل ویرایش وجود ندارد .");
            }
            diet.Wrist = wrist;
            _context.SaveChanges ();
            return Ok (wrist);
        }

        [HttpPost ("SetWeightUser")]
        public IActionResult SetWeightUser (int userId, double weight) {
            var diet = _context.Diets.Where (x => x.UserId == userId && x.RequestComplete != true).FirstOrDefault ();
            if (diet == null) {
                return BadRequest ("رژیم قابل ویرایش وجود ندارد .");
            }
            diet.Weight = weight;
            _context.SaveChanges ();
            return Ok (weight);
        }
        //اگر رژیم تکمیل نشده ای داشت مراحل آن را محاسبه و بر می گرداند 
        //در غیر اینصورت مقدار 6 به معنای تکمیل شده را بر می گرداند
        [HttpPost ("GeStepCompleteCountUser")]
        public IActionResult GeStepCompleteCountUser (int userId) {
            var step = 0;
            var diets = _context.Diets.Include (x => x.User).Include (x => x.User).Include (x => x.Gender).Where (x => x.UserId == userId)
                .Include (x => x.FatPartDiets).Include (x => x.SicknessDiets).Include (x => x.AllergyDiets)
                .Include (x => x.BadHabitDiets).Include (x => x.ProteinDiets).Include (x => x.QuestionDiets).

            OrderByDescending (x => x.Id);
            Diet currentDiet;
            if (diets.Count () > 0) {
                currentDiet = diets.Where (x => x.RequestComplete != true).FirstOrDefault ();
                if (currentDiet == null) {
                    currentDiet = diets.Where (x => x.RequestComplete == true).FirstOrDefault ();
                    if (currentDiet != null) {
                        step = 6;
                    }
                } else {
                    if (currentDiet.GoalId != null) {
                        step = 1;
                    }
                    if (currentDiet.Waist != null) {
                        step = 2;
                    }
                    if (currentDiet.FatPartDiets != null && currentDiet.FatPartDiets.Count != 0) {
                        step = 3;
                    }
                    if (currentDiet.AllergyDescription != null) {
                        step = 4;
                    }
                    if (currentDiet.ProteinDiets != null && currentDiet.ProteinDiets.Count != 0) {
                        step = 5;
                    }
                    if (currentDiet.QuestionDiets != null && currentDiet.QuestionDiets.Count != 0) {
                        step = 6;
                    }

                }
            }
            return Ok (step);
        }

        [HttpGet ("GetNotCompletedDietUser")]
        public IActionResult GetNotCompletedDietUser (int userId) {

            var currentDiet = _context.Diets.Include (x => x.FatPartDiets).Include (x => x.SicknessDiets).Include (x => x.AllergyDiets)
                .Include (x => x.BadHabitDiets).Include (x => x.ProteinDiets).Include (x => x.QuestionDiets).Where (x => x.UserId == userId && x.RequestComplete != true).OrderByDescending (x => x.Id).FirstOrDefault ();
            if (currentDiet != null) {

                return Ok (currentDiet);
            }
            currentDiet = new Diet ();
            currentDiet.UserId = userId;
            _context.Diets.Add (currentDiet);
            int id = _context.SaveChanges ();
            currentDiet.Id = id;
            return Ok (currentDiet);

        } //GetNotCompletedDietUser
        [HttpPost ("AddParts")]
        public IActionResult AddParts (int userId, List<int> id) {
            var diet = _context.Diets.Include (x => x.FatPartDiets).Where (x => x.UserId == userId && x.RequestComplete != true).FirstOrDefault ();
            if (diet == null) {
                return BadRequest ("رژیم قابل ویرایش وجود ندارد .");
            }
            if (id != null && id.Count != 0) {
                diet.FatPartDiets.Clear ();
                foreach (int partId in id) {
                    FatPartDiet fatDiet = new FatPartDiet { FatPartId = partId, Diet = diet };
                    diet.FatPartDiets.Add (fatDiet);
                }
            }
            _context.SaveChanges ();
            return Ok (id.Count);
        }

        [HttpPost ("AddSicknesses")]
        public IActionResult AddSicknesses (int userId, List<int> id) {
            var diet = _context.Diets.Include (x => x.SicknessDiets).Where (x => x.UserId == userId && x.RequestComplete != true).FirstOrDefault ();
            if (diet == null) {
                return BadRequest ("رژیم قابل ویرایش وجود ندارد .");
            }
            diet.SicknessDiets.Clear ();
            if (id != null && id.Count != 0) {

                foreach (int sickId in id) {
                    SicknessDiet temp = new SicknessDiet { SicknessId = sickId, Diet = diet };
                    diet.SicknessDiets.Add (temp);
                }
            }
            _context.SaveChanges ();
            return Ok (id.Count);
        }

        [HttpPost ("AddSleepRate")]
        public IActionResult AddSleepRate (int userId, int sleepRateId) {
            var diet = _context.Diets.Where (x => x.UserId == userId && x.RequestComplete != true).FirstOrDefault ();
            if (diet == null) {
                return BadRequest ("رژیم قابل ویرایش وجود ندارد .");
            }

            diet.SleepRateId = sleepRateId;
            _context.SaveChanges ();
            return Ok (sleepRateId);
        }

        [HttpPost ("AddWaterRate")]
        public IActionResult AddWaterRate (int userId, int waterRateId) {
            var diet = _context.Diets.Where (x => x.UserId == userId && x.RequestComplete != true).FirstOrDefault ();
            if (diet == null) {
                return BadRequest ("رژیم قابل ویرایش وجود ندارد .");
            }
            diet.WaterRateId = waterRateId;
            _context.SaveChanges ();
            return Ok (waterRateId);
        }

        [HttpPost ("AddAllergies")]
        public IActionResult AddAllergies (int userId, List<int> id) {
            var diet = _context.Diets.Include (x => x.AllergyDiets).Where (x => x.UserId == userId && x.RequestComplete != true).FirstOrDefault ();
            if (diet == null) {
                return BadRequest ("رژیم قابل ویرایش وجود ندارد .");
            }
            diet.AllergyDiets.Clear ();
            if (id != null && id.Count != 0) {

                foreach (int allergyId in id) {
                    AllergyDiet temp = new AllergyDiet { AllergyId = allergyId, Diet = diet };
                    diet.AllergyDiets.Add (temp);
                }
            }
            _context.SaveChanges ();
            return Ok (id.Count);
        }

        [HttpPost ("AddBadHabits")]
        public IActionResult AddBadHabits (int userId, List<int> id) {
            var diet = _context.Diets.Include (x => x.BadHabitDiets).Where (x => x.UserId == userId && x.RequestComplete != true).FirstOrDefault ();
            if (diet == null) {
                return BadRequest ("رژیم قابل ویرایش وجود ندارد .");
            }
            diet.BadHabitDiets.Clear ();
            if (id != null && id.Count != 0) {

                foreach (int habitId in id) {
                    BadHabitDiet temp = new BadHabitDiet { BadHabitId = habitId, Diet = diet };
                    diet.BadHabitDiets.Add (temp);
                }
            }
            _context.SaveChanges ();
            return Ok (id.Count);
        }

        [HttpPost ("AddProteins")]
        public IActionResult AddProteins (int userId, List<int> id) {
            var diet = _context.Diets.Include (x => x.ProteinDiets).Where (x => x.UserId == userId && x.RequestComplete != true).FirstOrDefault ();
            if (diet == null) {
                return BadRequest ("رژیم قابل ویرایش وجود ندارد .");
            }
            diet.ProteinDiets.Clear ();
            if (id != null && id.Count != 0) {

                foreach (int proteinId in id) {
                    ProteinDiet temp = new ProteinDiet { ProteinId = proteinId, Diet = diet };
                    diet.ProteinDiets.Add (temp);
                }
            }
            _context.SaveChanges ();
            return Ok (id.Count);
        }

        [HttpPost ("AddQuestions")]
        public IActionResult AddQuestions (int userId, List<int> questionIds, List<int> values) {
            var diet = _context.Diets.Include (x => x.QuestionDiets).Where (x => x.UserId == userId && x.RequestComplete != true).FirstOrDefault ();
            if (diet == null) {
                return BadRequest ("رژیم قابل ویرایش وجود ندارد .");
            }
            diet.QuestionDiets.Clear ();
            if (questionIds != null && questionIds.Count != 0) {
                for (int i = 0; i < questionIds.Count; i++) {
                    QuestionDiet temp = new QuestionDiet { QuestionId = questionIds[i], Diet = diet, ResponseValue = values[i] };
                    diet.QuestionDiets.Add (temp);
                }

            }
            _context.SaveChanges ();
            return Ok (questionIds.Count);
        }

        [HttpPost ("AddActivity")]
        public IActionResult AddActivity (int userId, int activityId) {
            var diet = _context.Diets.Where (x => x.UserId == userId && x.RequestComplete != true).FirstOrDefault ();
            if (diet == null) {
                return BadRequest ("رژیم قابل ویرایش وجود ندارد .");
            }

            diet.ActivityRateId = activityId;
            _context.SaveChanges ();
            return Ok (activityId);
        }

        [HttpPost ("AddSickDiscription")]
        public IActionResult AddSickDiscription (int userId, string description) {
            var diet = _context.Diets.Include (x => x.SicknessDiets).Where (x => x.UserId == userId && x.RequestComplete != true).FirstOrDefault ();
            if (diet == null) {
                return BadRequest ("رژیم قابل ویرایش وجود ندارد .");
            }
            diet.SicknessDescription = description;
            int dietId = _context.SaveChanges ();
            return Ok (dietId);
        }

        [HttpPost ("AddAllergyDiscription")]
        public IActionResult AddAllergyDiscription (int userId, string description) {
            var diet = _context.Diets.Include (x => x.SicknessDiets).Where (x => x.UserId == userId && x.RequestComplete != true).FirstOrDefault ();
            if (diet == null) {
                return BadRequest ("رژیم قابل ویرایش وجود ندارد .");
            }
            diet.AllergyDescription = description;
            int dietId = _context.SaveChanges ();
            return Ok (dietId);
        }

        [HttpPost ("AddMedicationDiscription")]
        public IActionResult AddMedicationDiscription (int userId, string description) {
            var diet = _context.Diets.Include (x => x.SicknessDiets).Where (x => x.UserId == userId && x.RequestComplete != true).FirstOrDefault ();
            if (diet == null) {
                return BadRequest ("رژیم قابل ویرایش وجود ندارد .");
            }
            diet.TakingMedicationDescription = description;
            int dietId = _context.SaveChanges ();
            return Ok (dietId);
        }

        [HttpPost ("AddActivityDiscription")]
        public IActionResult AddActivityDiscription (int userId, string description) {
            var diet = _context.Diets.Include (x => x.SicknessDiets).Where (x => x.UserId == userId && x.RequestComplete != true).FirstOrDefault ();
            if (diet == null) {
                return BadRequest ("رژیم قابل ویرایش وجود ندارد .");
            }
            diet.ActivityRateDescription = description;
            int dietId = _context.SaveChanges ();
            return Ok (dietId);
        }
    }
}