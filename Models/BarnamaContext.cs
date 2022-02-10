using Barnama.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

public class BarnamaConntext : DbContext {
  public BarnamaConntext (DbContextOptions<BarnamaConntext> options) : base (options) { }
  // public BarnamaConntext () { }
  public static bool isMigration = true;
  protected override void OnConfiguring (DbContextOptionsBuilder options) {
    //options.UseSqlServer ("Data Source=(local);Initial Catalog=PoidsDb;Integrated Security = true;MultipleActiveResultSets=true");
    options.UseSqlServer ("server=45.139.102.219\\MSSQLSERVER2017;database=nasoomDB;user=master11641;password=Aserfg1@;");

  }
  protected override void OnModelCreating (ModelBuilder modelBuilder) {
    //many_to_many config

    //Next Config
    modelBuilder.Entity<UserRole> ()
      .HasKey (bc => new { bc.UserId, bc.RoleId });
    modelBuilder.Entity<UserRole> ()
      .HasOne (bc => bc.User)
      .WithMany (b => b.UserRoles)
      .HasForeignKey (bc => bc.UserId);
    modelBuilder.Entity<UserRole> ()
      .HasOne (bc => bc.Role)
      .WithMany (c => c.UserRoles)
      .HasForeignKey (bc => bc.RoleId);

    modelBuilder.Entity<FoodNutrient> ()
      .HasKey (bc => new { bc.FoodId, bc.NutrientId });
    modelBuilder.Entity<FoodNutrient> ()
      .HasOne (bc => bc.Food)
      .WithMany (b => b.FoodNutrients)
      .HasForeignKey (bc => bc.FoodId);
    modelBuilder.Entity<FoodNutrient> ()
      .HasOne (bc => bc.Nutrient)
      .WithMany (b => b.FoodNutrients)
      .HasForeignKey (bc => bc.NutrientId);

    modelBuilder.Entity<FoodMeel> ()
      .HasKey (bc => new { bc.FoodId, bc.MeelId });
    modelBuilder.Entity<FoodMeel> ()
      .HasOne (bc => bc.Food)
      .WithMany (b => b.FoodMeels)
      .HasForeignKey (bc => bc.FoodId);
    modelBuilder.Entity<FoodMeel> ()
      .HasOne (bc => bc.Meel)
      .WithMany (b => b.FoodMeels)
      .HasForeignKey (bc => bc.MeelId);

    modelBuilder.Entity<FoodUnit> ()
      .HasKey (bc => new { bc.FoodId, bc.UnitId });
    modelBuilder.Entity<FoodUnit> ()
      .HasOne (bc => bc.Food)
      .WithMany (b => b.FoodUnits)
      .HasForeignKey (bc => bc.FoodId);
    modelBuilder.Entity<FoodUnit> ()
      .HasOne (bc => bc.Unit)
      .WithMany (b => b.FoodUnits)
      .HasForeignKey (bc => bc.UnitId);

    modelBuilder.Entity<QuestionDiet> ()
      .HasKey (bc => new { bc.QuestionId, bc.DietId });
    modelBuilder.Entity<QuestionDiet> ()
      .HasOne (bc => bc.Question)
      .WithMany (b => b.QuestionDiets)
      .HasForeignKey (bc => bc.QuestionId);
    modelBuilder.Entity<QuestionDiet> ()
      .HasOne (bc => bc.Diet)
      .WithMany (b => b.QuestionDiets)
      .HasForeignKey (bc => bc.DietId);

    modelBuilder.Entity<ProteinDiet> ()
      .HasKey (bc => new { bc.ProteinId, bc.DietId });
    modelBuilder.Entity<ProteinDiet> ()
      .HasOne (bc => bc.Protein)
      .WithMany (b => b.ProteinDiets)
      .HasForeignKey (bc => bc.ProteinId);
    modelBuilder.Entity<ProteinDiet> ()
      .HasOne (bc => bc.Diet)
      .WithMany (b => b.ProteinDiets)
      .HasForeignKey (bc => bc.DietId);

    modelBuilder.Entity<AllergyDiet> ()
      .HasKey (bc => new { bc.AllergyId, bc.DietId });
    modelBuilder.Entity<AllergyDiet> ()
      .HasOne (bc => bc.Allergy)
      .WithMany (b => b.AllergyDiets)
      .HasForeignKey (bc => bc.AllergyId);
    modelBuilder.Entity<AllergyDiet> ()
      .HasOne (bc => bc.Diet)
      .WithMany (b => b.AllergyDiets)
      .HasForeignKey (bc => bc.DietId);

    modelBuilder.Entity<BadHabitDiet> ()
      .HasKey (bc => new { bc.BadHabitId, bc.DietId });
    modelBuilder.Entity<BadHabitDiet> ()
      .HasOne (bc => bc.BadHabit)
      .WithMany (b => b.BadHabitDiets)
      .HasForeignKey (bc => bc.BadHabitId);
    modelBuilder.Entity<BadHabitDiet> ()
      .HasOne (bc => bc.Diet)
      .WithMany (b => b.BadHabitDiets)
      .HasForeignKey (bc => bc.DietId);

    modelBuilder.Entity<SicknessDiet> ()
      .HasKey (bc => new { bc.SicknessId, bc.DietId });
    modelBuilder.Entity<SicknessDiet> ()
      .HasOne (bc => bc.Sickness)
      .WithMany (b => b.SicknessDiets)
      .HasForeignKey (bc => bc.SicknessId);
    modelBuilder.Entity<SicknessDiet> ()
      .HasOne (bc => bc.Diet)
      .WithMany (b => b.SicknessDiets)
      .HasForeignKey (bc => bc.DietId);

    modelBuilder.Entity<FatPartDiet> ()
      .HasKey (bc => new { bc.FatPartId, bc.DietId });
    modelBuilder.Entity<FatPartDiet> ()
      .HasOne (bc => bc.FatPart)
      .WithMany (b => b.FatPartDiets)
      .HasForeignKey (bc => bc.FatPartId);
    modelBuilder.Entity<FatPartDiet> ()
      .HasOne (bc => bc.Diet)
      .WithMany (b => b.FatPartDiets)
      .HasForeignKey (bc => bc.DietId);

    //*****************
  }
  public virtual DbSet<User> Users { get; set; }

  public virtual DbSet<Role> Roles { get; set; }
  public virtual DbSet<UserRole> UserRoles { get; set; }
  public virtual DbSet<ServicePackage> ServicePackages { get; set; }
  public virtual DbSet<Discount> Discounts { get; set; }

  public virtual DbSet<Invoice> Invoices { get; set; }

  public DbSet<Group> Groups { get; set; }

  public DbSet<Food> Foods { get; set; }
  public DbSet<FoodMeel> FoodMeels { get; set; }
  public DbSet<FoodUnit> FoodUnits { get; set; }
  public DbSet<FoodNutrient> FoodNutrients { get; set; }
  public DbSet<Nutrient> Nutrients { get; set; }
  public DbSet<FoodImage> FoodImages { get; set; }
  public DbSet<Meel> Meels { get; set; }
  public DbSet<Unit> Units { get; set; }
  public DbSet<Goal> Goals { get; set; }
  public DbSet<Gender> Genders { get; set; }
  public DbSet<FatPart> FatParts { get; set; }
  public DbSet<Sickness> Sicknesses { get; set; }
  public DbSet<Allergy> Allergies { get; set; }
  public DbSet<ActivityRate> ActivityRates { get; set; }
  public DbSet<BadHabit> BadHabits { get; set; }
  public DbSet<Protein> Proteins { get; set; }
  public DbSet<Question> Questions { get; set; }
  public DbSet<Diet> Diets { get; set; }
  public DbSet<QuestionDiet> QuestionDiets { get; set; }
  public DbSet<ProteinDiet> ProteinDiets { get; set; }
  public DbSet<SleepRate> SleepRates { get; set; }
  public DbSet<WaterRate> WaterRates { get; set; }
  public DbSet<Recipe> Recipes { get; set; }

}