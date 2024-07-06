﻿// <auto-generated />
using System;
using BrSolutions.Persistance.EntityFrameworkCores.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BrSolutions.Persistance.Migrations
{
    [DbContext(typeof(BrSolutionContext))]
    partial class BrSolutionContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BrSolution.Domain.Entities.App.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<int?>("LastEditUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastEditedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ModuleId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("LastEditUserId");

                    b.HasIndex("ModuleId");

                    b.HasIndex("UserId");

                    b.ToTable("Categories", "app");
                });

            modelBuilder.Entity("BrSolution.Domain.Entities.App.ExceptionLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EndpointName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExceptionMessage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ExceptionTypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HttpMethod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestBody")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestIp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RequestUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StackTrace")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("TransactionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("ExceptionLogs");
                });

            modelBuilder.Entity("BrSolution.Domain.Entities.App.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<int?>("LastEditUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastEditedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(60)
                        .HasColumnType("nvarchar(60)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("LastEditUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Modules", "app");
                });

            modelBuilder.Entity("BrSolution.Domain.Entities.App.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<int?>("LastEditUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastEditedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("LastEditUserId");

                    b.ToTable("Roles", "app");
                });

            modelBuilder.Entity("BrSolution.Domain.Entities.App.RoleSystemService", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("SystemServiceId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("RoleId", "SystemServiceId");

                    b.HasIndex("SystemServiceId");

                    b.ToTable("RoleSystemService");
                });

            modelBuilder.Entity("BrSolution.Domain.Entities.App.SystemService", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EncryptedName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EncryptedName")
                        .IsUnique();

                    b.ToTable("SystemServices", "app");
                });

            modelBuilder.Entity("BrSolution.Domain.Entities.App.UploadFile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<string>("FileName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int?>("LastEditUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastEditedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("RelativePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("LastEditUserId");

                    b.ToTable("UploadFiles", "app");
                });

            modelBuilder.Entity("BrSolution.Domain.Entities.App.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("LastEditedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<byte>("UserStatusId")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("UserStatusId");

                    b.ToTable("Users", "app");
                });

            modelBuilder.Entity("BrSolution.Domain.Entities.App.UserDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<byte>("GenderId")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("LastEditedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<int?>("UploadFileId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.HasIndex("UploadFileId")
                        .IsUnique()
                        .HasFilter("[UploadFileId] IS NOT NULL");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserDetails", "app");
                });

            modelBuilder.Entity("BrSolution.Domain.Entities.App.UserRole", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("RoleUsers", "app");
                });

            modelBuilder.Entity("BrSolution.Domain.Entities.App.UserStatus", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<byte>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("UserStatuses", "libraries");

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            CreateDate = new DateTime(2024, 7, 2, 10, 21, 28, 858, DateTimeKind.Local).AddTicks(5781),
                            Name = "Register"
                        },
                        new
                        {
                            Id = (byte)2,
                            CreateDate = new DateTime(2024, 7, 2, 10, 21, 28, 858, DateTimeKind.Local).AddTicks(5790),
                            Name = "Active"
                        },
                        new
                        {
                            Id = (byte)3,
                            CreateDate = new DateTime(2024, 7, 2, 10, 21, 28, 858, DateTimeKind.Local).AddTicks(5792),
                            Name = "Deactive"
                        });
                });

            modelBuilder.Entity("BrSolution.Domain.Entities.Libraries.Gender", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<byte>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.ToTable("Genders", "libraries");

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            CreateDate = new DateTime(2024, 7, 2, 10, 21, 28, 858, DateTimeKind.Local).AddTicks(270),
                            Name = "Male"
                        },
                        new
                        {
                            Id = (byte)2,
                            CreateDate = new DateTime(2024, 7, 2, 10, 21, 28, 858, DateTimeKind.Local).AddTicks(353),
                            Name = "Female"
                        });
                });

            modelBuilder.Entity("BrSolution.Domain.Entities.Libraries.PostStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("PostStatus");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreateDate = new DateTime(2024, 7, 2, 10, 21, 28, 857, DateTimeKind.Local).AddTicks(3642),
                            Name = "NotStarted"
                        },
                        new
                        {
                            Id = 2,
                            CreateDate = new DateTime(2024, 7, 2, 10, 21, 28, 857, DateTimeKind.Local).AddTicks(3785),
                            Name = "Progress"
                        },
                        new
                        {
                            Id = 3,
                            CreateDate = new DateTime(2024, 7, 2, 10, 21, 28, 857, DateTimeKind.Local).AddTicks(3787),
                            Name = "Stoped"
                        },
                        new
                        {
                            Id = 4,
                            CreateDate = new DateTime(2024, 7, 2, 10, 21, 28, 857, DateTimeKind.Local).AddTicks(3789),
                            Name = "Shared"
                        });
                });

            modelBuilder.Entity("BrSolution.Domain.Entities.Libraries.PostType", b =>
                {
                    b.Property<byte>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("tinyint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<byte>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("PostTypes", "libraries");

                    b.HasData(
                        new
                        {
                            Id = (byte)1,
                            CreateDate = new DateTime(2024, 7, 2, 10, 21, 28, 858, DateTimeKind.Local).AddTicks(555),
                            Name = "Carousel"
                        },
                        new
                        {
                            Id = (byte)2,
                            CreateDate = new DateTime(2024, 7, 2, 10, 21, 28, 858, DateTimeKind.Local).AddTicks(557),
                            Name = "OnePost"
                        },
                        new
                        {
                            Id = (byte)3,
                            CreateDate = new DateTime(2024, 7, 2, 10, 21, 28, 858, DateTimeKind.Local).AddTicks(559),
                            Name = "Reels"
                        });
                });

            modelBuilder.Entity("BrSolution.Domain.Entities.Marketing.PostPlan", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Caption")
                        .IsRequired()
                        .HasColumnType("nText");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreateDate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int?>("CreatedUserId")
                        .HasColumnType("int");

                    b.Property<string>("Definition")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nText");

                    b.Property<int?>("LastEditUserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("LastEditedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("PostStatusId")
                        .HasColumnType("int");

                    b.Property<DateTime>("SharedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreatedUserId");

                    b.HasIndex("LastEditUserId");

                    b.HasIndex("PostStatusId");

                    b.ToTable("PostPlans", "app");
                });

            modelBuilder.Entity("BrSolution.Domain.Entities.App.Category", b =>
                {
                    b.HasOne("BrSolution.Domain.Entities.App.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BrSolution.Domain.Entities.App.User", "LastEditUser")
                        .WithMany()
                        .HasForeignKey("LastEditUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BrSolution.Domain.Entities.App.Module", "Module")
                        .WithMany()
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BrSolution.Domain.Entities.App.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CreatedUser");

                    b.Navigation("LastEditUser");

                    b.Navigation("Module");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BrSolution.Domain.Entities.App.ExceptionLog", b =>
                {
                    b.HasOne("BrSolution.Domain.Entities.App.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BrSolution.Domain.Entities.App.Module", b =>
                {
                    b.HasOne("BrSolution.Domain.Entities.App.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BrSolution.Domain.Entities.App.User", "LastEditUser")
                        .WithMany()
                        .HasForeignKey("LastEditUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BrSolution.Domain.Entities.App.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CreatedUser");

                    b.Navigation("LastEditUser");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BrSolution.Domain.Entities.App.Role", b =>
                {
                    b.HasOne("BrSolution.Domain.Entities.App.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BrSolution.Domain.Entities.App.User", "LastEditUser")
                        .WithMany()
                        .HasForeignKey("LastEditUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CreatedUser");

                    b.Navigation("LastEditUser");
                });

            modelBuilder.Entity("BrSolution.Domain.Entities.App.RoleSystemService", b =>
                {
                    b.HasOne("BrSolution.Domain.Entities.App.Role", "Role")
                        .WithMany("RoleSystemServices")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BrSolution.Domain.Entities.App.SystemService", "SystemService")
                        .WithMany("RoleSystemServices")
                        .HasForeignKey("SystemServiceId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("SystemService");
                });

            modelBuilder.Entity("BrSolution.Domain.Entities.App.UploadFile", b =>
                {
                    b.HasOne("BrSolution.Domain.Entities.App.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BrSolution.Domain.Entities.App.User", "LastEditUser")
                        .WithMany()
                        .HasForeignKey("LastEditUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("CreatedUser");

                    b.Navigation("LastEditUser");
                });

            modelBuilder.Entity("BrSolution.Domain.Entities.App.User", b =>
                {
                    b.HasOne("BrSolution.Domain.Entities.App.UserStatus", "UserStatus")
                        .WithMany()
                        .HasForeignKey("UserStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserStatus");
                });

            modelBuilder.Entity("BrSolution.Domain.Entities.App.UserDetail", b =>
                {
                    b.HasOne("BrSolution.Domain.Entities.Libraries.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BrSolution.Domain.Entities.App.UploadFile", "UploadedFile")
                        .WithOne()
                        .HasForeignKey("BrSolution.Domain.Entities.App.UserDetail", "UploadFileId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BrSolution.Domain.Entities.App.User", "User")
                        .WithOne("UserDetail")
                        .HasForeignKey("BrSolution.Domain.Entities.App.UserDetail", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Gender");

                    b.Navigation("UploadedFile");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BrSolution.Domain.Entities.App.UserRole", b =>
                {
                    b.HasOne("BrSolution.Domain.Entities.App.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BrSolution.Domain.Entities.App.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BrSolution.Domain.Entities.Marketing.PostPlan", b =>
                {
                    b.HasOne("BrSolution.Domain.Entities.App.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BrSolution.Domain.Entities.App.User", "CreatedUser")
                        .WithMany()
                        .HasForeignKey("CreatedUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BrSolution.Domain.Entities.App.User", "LastEditUser")
                        .WithMany()
                        .HasForeignKey("LastEditUserId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("BrSolution.Domain.Entities.Libraries.PostStatus", "PostStatus")
                        .WithMany()
                        .HasForeignKey("PostStatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");

                    b.Navigation("CreatedUser");

                    b.Navigation("LastEditUser");

                    b.Navigation("PostStatus");
                });

            modelBuilder.Entity("BrSolution.Domain.Entities.App.Role", b =>
                {
                    b.Navigation("RoleSystemServices");

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("BrSolution.Domain.Entities.App.SystemService", b =>
                {
                    b.Navigation("RoleSystemServices");
                });

            modelBuilder.Entity("BrSolution.Domain.Entities.App.User", b =>
                {
                    b.Navigation("UserDetail");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
