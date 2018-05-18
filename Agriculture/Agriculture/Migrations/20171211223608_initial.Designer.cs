using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Agriculture.Models;

namespace Agriculture.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20171211223608_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Agriculture.Models.Entities.Crop", b =>
                {
                    b.Property<int>("CropId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("CropImage");

                    b.Property<string>("Name");

                    b.Property<string>("PesticidesUsed");

                    b.Property<float>("Price");

                    b.HasKey("CropId");

                    b.ToTable("Crops");
                });

            modelBuilder.Entity("Agriculture.Models.Entities.CropsFeedback", b =>
                {
                    b.Property<int>("CropsFeedbackId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CropId");

                    b.Property<string>("Feedback");

                    b.Property<int?>("Rating");

                    b.Property<DateTime?>("ThisDateTime");

                    b.HasKey("CropsFeedbackId");

                    b.ToTable("CropsFeedbacks");
                });

            modelBuilder.Entity("Agriculture.Models.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("LastName");

                    b.Property<string>("Password");

                    b.Property<string>("PasswordHash");

                    b.Property<int>("PrivilegeId");

                    b.Property<string>("Salt");

                    b.HasKey("CustomerId");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("Agriculture.Models.Entities.Season", b =>
                {
                    b.Property<int>("SeasonId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("SeasonId");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("Agriculture.Models.Entities.SeasonCrop", b =>
                {
                    b.Property<int>("SeasonCropId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CropId");

                    b.Property<int>("SeasonId");

                    b.HasKey("SeasonCropId");

                    b.HasIndex("CropId");

                    b.HasIndex("SeasonId");

                    b.ToTable("SeasonCrop");
                });

            modelBuilder.Entity("Agriculture.Models.Entities.SeasonCrop", b =>
                {
                    b.HasOne("Agriculture.Models.Entities.Crop", "Crop")
                        .WithMany("CategoryCrops")
                        .HasForeignKey("CropId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Agriculture.Models.Entities.Season", "Category")
                        .WithMany("SeasonCrops")
                        .HasForeignKey("SeasonId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
