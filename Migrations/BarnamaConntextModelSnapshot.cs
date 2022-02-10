﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LeitnerApi.Migrations
{
    [DbContext(typeof(BarnamaConntext))]
    partial class BarnamaConntextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ActivityRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ActivityRates");
                });

            modelBuilder.Entity("Allergy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Allergies");
                });

            modelBuilder.Entity("AllergyDiet", b =>
                {
                    b.Property<int>("AllergyId")
                        .HasColumnType("int");

                    b.Property<int>("DietId")
                        .HasColumnType("int");

                    b.HasKey("AllergyId", "DietId");

                    b.HasIndex("DietId");

                    b.ToTable("AllergyDiet");
                });

            modelBuilder.Entity("BadHabit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("BadHabits");
                });

            modelBuilder.Entity("BadHabitDiet", b =>
                {
                    b.Property<int>("BadHabitId")
                        .HasColumnType("int");

                    b.Property<int>("DietId")
                        .HasColumnType("int");

                    b.HasKey("BadHabitId", "DietId");

                    b.HasIndex("DietId");

                    b.ToTable("BadHabitDiet");
                });

            modelBuilder.Entity("Diet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActivityRateDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ActivityRateId")
                        .HasColumnType("int");

                    b.Property<double?>("Age")
                        .HasColumnType("float");

                    b.Property<string>("AllergyDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("GenderId")
                        .HasColumnType("int");

                    b.Property<int?>("GoalId")
                        .HasColumnType("int");

                    b.Property<double?>("Height")
                        .HasColumnType("float");

                    b.Property<bool?>("RequestComplete")
                        .HasColumnType("bit");

                    b.Property<string>("SicknessDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SleepRateId")
                        .HasColumnType("int");

                    b.Property<string>("TakingMedicationDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int?>("WaterRateId")
                        .HasColumnType("int");

                    b.Property<double?>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("ActivityRateId");

                    b.HasIndex("GenderId");

                    b.HasIndex("GoalId");

                    b.HasIndex("SleepRateId");

                    b.HasIndex("UserId");

                    b.HasIndex("WaterRateId");

                    b.ToTable("Diets");
                });

            modelBuilder.Entity("Discount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BazarProductId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Desciption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Percentage")
                        .HasColumnType("float");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UsageRestrictions")
                        .HasColumnType("int");

                    b.Property<string>("UserNames")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Discounts");
                });

            modelBuilder.Entity("FatPart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FatParts");
                });

            modelBuilder.Entity("FatPartDiet", b =>
                {
                    b.Property<int>("FatPartId")
                        .HasColumnType("int");

                    b.Property<int>("DietId")
                        .HasColumnType("int");

                    b.HasKey("FatPartId", "DietId");

                    b.HasIndex("DietId");

                    b.ToTable("FatPartDiet");
                });

            modelBuilder.Entity("Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("GroupId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GroupId");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("FoodImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMainImage")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.ToTable("FoodImages");
                });

            modelBuilder.Entity("FoodMeel", b =>
                {
                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int>("MeelId")
                        .HasColumnType("int");

                    b.HasKey("FoodId", "MeelId");

                    b.HasIndex("MeelId");

                    b.ToTable("FoodMeels");
                });

            modelBuilder.Entity("FoodNutrient", b =>
                {
                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int>("NutrientId")
                        .HasColumnType("int");

                    b.HasKey("FoodId", "NutrientId");

                    b.HasIndex("NutrientId");

                    b.ToTable("FoodNutrients");
                });

            modelBuilder.Entity("FoodUnit", b =>
                {
                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<int>("UnitId")
                        .HasColumnType("int");

                    b.Property<double?>("Calcium")
                        .HasColumnType("float");

                    b.Property<double?>("Calorie")
                        .HasColumnType("float");

                    b.Property<double?>("Carbohydrate")
                        .HasColumnType("float");

                    b.Property<double?>("Fat")
                        .HasColumnType("float");

                    b.Property<double?>("Iron")
                        .HasColumnType("float");

                    b.Property<double?>("Magnesium")
                        .HasColumnType("float");

                    b.Property<double?>("Phosphor")
                        .HasColumnType("float");

                    b.Property<double?>("Potassium")
                        .HasColumnType("float");

                    b.Property<double?>("Protein")
                        .HasColumnType("float");

                    b.Property<double?>("Sfa")
                        .HasColumnType("float");

                    b.Property<double?>("Sodium")
                        .HasColumnType("float");

                    b.Property<double?>("Sugar")
                        .HasColumnType("float");

                    b.Property<double?>("Tfa")
                        .HasColumnType("float");

                    b.Property<double?>("Umfa")
                        .HasColumnType("float");

                    b.Property<double?>("Upfa")
                        .HasColumnType("float");

                    b.HasKey("FoodId", "UnitId");

                    b.HasIndex("UnitId");

                    b.ToTable("FoodUnits");
                });

            modelBuilder.Entity("Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Genders");
                });

            modelBuilder.Entity("Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("Group", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Groups");
                });

            modelBuilder.Entity("Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("Authority")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsConfirm")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RefId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ServicePackageId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ServicePackageId");

                    b.HasIndex("UserId");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("Meel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Meels");
                });

            modelBuilder.Entity("Nutrient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMicro")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Nutrients");
                });

            modelBuilder.Entity("Protein", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Proteins");
                });

            modelBuilder.Entity("ProteinDiet", b =>
                {
                    b.Property<int>("ProteinId")
                        .HasColumnType("int");

                    b.Property<int>("DietId")
                        .HasColumnType("int");

                    b.Property<int>("ResponseValue")
                        .HasColumnType("int");

                    b.HasKey("ProteinId", "DietId");

                    b.HasIndex("DietId");

                    b.ToTable("ProteinDiets");
                });

            modelBuilder.Entity("Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("QuestionDiet", b =>
                {
                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("DietId")
                        .HasColumnType("int");

                    b.Property<int>("ResponseValue")
                        .HasColumnType("int");

                    b.HasKey("QuestionId", "DietId");

                    b.HasIndex("DietId");

                    b.ToTable("QuestionDiets");
                });

            modelBuilder.Entity("Recipe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("FoodId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FoodId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("ServicePackage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("BazarProductId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Desciption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("DiscountId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("ExpireAfterBuyInDays")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsAdviserType")
                        .HasColumnType("bit");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DiscountId");

                    b.ToTable("ServicePackages");
                });

            modelBuilder.Entity("Sickness", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sicknesses");
                });

            modelBuilder.Entity("SicknessDiet", b =>
                {
                    b.Property<int>("SicknessId")
                        .HasColumnType("int");

                    b.Property<int>("DietId")
                        .HasColumnType("int");

                    b.HasKey("SicknessId", "DietId");

                    b.HasIndex("DietId");

                    b.ToTable("SicknessDiet");
                });

            modelBuilder.Entity("SleepRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SleepRates");
                });

            modelBuilder.Entity("Unit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Units");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Family")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FcmToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageProfileUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IntroducedUserPhone")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("WaterRate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WaterRates");
                });

            modelBuilder.Entity("AllergyDiet", b =>
                {
                    b.HasOne("Allergy", "Allergy")
                        .WithMany("AllergyDiets")
                        .HasForeignKey("AllergyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Diet", "Diet")
                        .WithMany("AllergyDiets")
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Allergy");

                    b.Navigation("Diet");
                });

            modelBuilder.Entity("BadHabitDiet", b =>
                {
                    b.HasOne("BadHabit", "BadHabit")
                        .WithMany("BadHabitDiets")
                        .HasForeignKey("BadHabitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Diet", "Diet")
                        .WithMany("BadHabitDiets")
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BadHabit");

                    b.Navigation("Diet");
                });

            modelBuilder.Entity("Diet", b =>
                {
                    b.HasOne("ActivityRate", "ActivityRate")
                        .WithMany()
                        .HasForeignKey("ActivityRateId");

                    b.HasOne("Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");

                    b.HasOne("Goal", "Goal")
                        .WithMany()
                        .HasForeignKey("GoalId");

                    b.HasOne("SleepRate", "SleepRate")
                        .WithMany()
                        .HasForeignKey("SleepRateId");

                    b.HasOne("User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WaterRate", "WaterRate")
                        .WithMany()
                        .HasForeignKey("WaterRateId");

                    b.Navigation("ActivityRate");

                    b.Navigation("Gender");

                    b.Navigation("Goal");

                    b.Navigation("SleepRate");

                    b.Navigation("User");

                    b.Navigation("WaterRate");
                });

            modelBuilder.Entity("FatPartDiet", b =>
                {
                    b.HasOne("Diet", "Diet")
                        .WithMany("FatPartDiets")
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FatPart", "FatPart")
                        .WithMany("FatPartDiets")
                        .HasForeignKey("FatPartId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diet");

                    b.Navigation("FatPart");
                });

            modelBuilder.Entity("Food", b =>
                {
                    b.HasOne("Group", "Group")
                        .WithMany("Foods")
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Group");
                });

            modelBuilder.Entity("FoodImage", b =>
                {
                    b.HasOne("Food", "Food")
                        .WithMany("FoodImages")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");
                });

            modelBuilder.Entity("FoodMeel", b =>
                {
                    b.HasOne("Food", "Food")
                        .WithMany("FoodMeels")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Meel", "Meel")
                        .WithMany("FoodMeels")
                        .HasForeignKey("MeelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("Meel");
                });

            modelBuilder.Entity("FoodNutrient", b =>
                {
                    b.HasOne("Food", "Food")
                        .WithMany("FoodNutrients")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Nutrient", "Nutrient")
                        .WithMany("FoodNutrients")
                        .HasForeignKey("NutrientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("Nutrient");
                });

            modelBuilder.Entity("FoodUnit", b =>
                {
                    b.HasOne("Food", "Food")
                        .WithMany("FoodUnits")
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Unit", "Unit")
                        .WithMany("FoodUnits")
                        .HasForeignKey("UnitId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("Unit");
                });

            modelBuilder.Entity("Invoice", b =>
                {
                    b.HasOne("ServicePackage", "ServicePackage")
                        .WithMany()
                        .HasForeignKey("ServicePackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "User")
                        .WithMany("Invoices")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ServicePackage");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProteinDiet", b =>
                {
                    b.HasOne("Diet", "Diet")
                        .WithMany("ProteinDiets")
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Protein", "Protein")
                        .WithMany("ProteinDiets")
                        .HasForeignKey("ProteinId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diet");

                    b.Navigation("Protein");
                });

            modelBuilder.Entity("QuestionDiet", b =>
                {
                    b.HasOne("Diet", "Diet")
                        .WithMany("QuestionDiets")
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Question", "Question")
                        .WithMany("QuestionDiets")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diet");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("Recipe", b =>
                {
                    b.HasOne("Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Food");
                });

            modelBuilder.Entity("ServicePackage", b =>
                {
                    b.HasOne("Discount", "Discount")
                        .WithMany("servicePackages")
                        .HasForeignKey("DiscountId");

                    b.Navigation("Discount");
                });

            modelBuilder.Entity("SicknessDiet", b =>
                {
                    b.HasOne("Diet", "Diet")
                        .WithMany("SicknessDiets")
                        .HasForeignKey("DietId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sickness", "Sickness")
                        .WithMany("SicknessDiets")
                        .HasForeignKey("SicknessId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Diet");

                    b.Navigation("Sickness");
                });

            modelBuilder.Entity("UserRole", b =>
                {
                    b.HasOne("Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Allergy", b =>
                {
                    b.Navigation("AllergyDiets");
                });

            modelBuilder.Entity("BadHabit", b =>
                {
                    b.Navigation("BadHabitDiets");
                });

            modelBuilder.Entity("Diet", b =>
                {
                    b.Navigation("AllergyDiets");

                    b.Navigation("BadHabitDiets");

                    b.Navigation("FatPartDiets");

                    b.Navigation("ProteinDiets");

                    b.Navigation("QuestionDiets");

                    b.Navigation("SicknessDiets");
                });

            modelBuilder.Entity("Discount", b =>
                {
                    b.Navigation("servicePackages");
                });

            modelBuilder.Entity("FatPart", b =>
                {
                    b.Navigation("FatPartDiets");
                });

            modelBuilder.Entity("Food", b =>
                {
                    b.Navigation("FoodImages");

                    b.Navigation("FoodMeels");

                    b.Navigation("FoodNutrients");

                    b.Navigation("FoodUnits");
                });

            modelBuilder.Entity("Group", b =>
                {
                    b.Navigation("Foods");
                });

            modelBuilder.Entity("Meel", b =>
                {
                    b.Navigation("FoodMeels");
                });

            modelBuilder.Entity("Nutrient", b =>
                {
                    b.Navigation("FoodNutrients");
                });

            modelBuilder.Entity("Protein", b =>
                {
                    b.Navigation("ProteinDiets");
                });

            modelBuilder.Entity("Question", b =>
                {
                    b.Navigation("QuestionDiets");
                });

            modelBuilder.Entity("Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("Sickness", b =>
                {
                    b.Navigation("SicknessDiets");
                });

            modelBuilder.Entity("Unit", b =>
                {
                    b.Navigation("FoodUnits");
                });

            modelBuilder.Entity("User", b =>
                {
                    b.Navigation("Invoices");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
