﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using app.Infrastructure;

#nullable disable

namespace app.Infrastructure.Migrations
{
    [DbContext(typeof(InventoryDbContext))]
    partial class InventoryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("dbo")
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("app.EntityModel.AppModels.Department", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Department", "dbo");
                });

            modelBuilder.Entity("app.EntityModel.AppModels.Grade", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("PayScale")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Grade", "dbo");
                });

            modelBuilder.Entity("app.EntityModel.CoreModel.Company", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Company", "dbo");
                });

            modelBuilder.Entity("app.EntityModel.CoreModel.MainMenu", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("OrderNo")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("MainMenu", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedBy = "System Admin",
                            CreatedOn = new DateTime(2023, 12, 6, 10, 54, 33, 793, DateTimeKind.Local).AddTicks(7143),
                            Icon = "<i class=\"fas fa-user\"></i>",
                            IsActive = true,
                            Name = "User Management",
                            OrderNo = 1
                        },
                        new
                        {
                            Id = 2L,
                            CreatedBy = "System Admin",
                            CreatedOn = new DateTime(2023, 12, 6, 10, 54, 33, 793, DateTimeKind.Local).AddTicks(7158),
                            Icon = "<i class=\"fas fa-cog\"></i>",
                            IsActive = true,
                            Name = "Configuration",
                            OrderNo = 2
                        });
                });

            modelBuilder.Entity("app.EntityModel.CoreModel.MenuItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("Action")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Controller")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Icon")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<long>("MenuId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("OrderNo")
                        .HasColumnType("int");

                    b.Property<string>("ShortName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("MenuItem", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            Action = "AddRecord",
                            Controller = "MainMenu",
                            CreatedBy = "System Admin",
                            CreatedOn = new DateTime(2023, 12, 6, 10, 54, 33, 793, DateTimeKind.Local).AddTicks(7185),
                            Icon = "<i class=\"fas fa-plus\"></i>",
                            IsActive = true,
                            MenuId = 1L,
                            Name = "Add Menu",
                            OrderNo = 1,
                            ShortName = "Add Menu"
                        },
                        new
                        {
                            Id = 2L,
                            Action = "Index",
                            Controller = "MainMenu",
                            CreatedBy = "System Admin",
                            CreatedOn = new DateTime(2023, 12, 6, 10, 54, 33, 793, DateTimeKind.Local).AddTicks(7188),
                            Icon = "<i class=\"fas fa-list\"></i>",
                            IsActive = true,
                            MenuId = 1L,
                            Name = "Main Menu List",
                            OrderNo = 2,
                            ShortName = "Main Menu List"
                        },
                        new
                        {
                            Id = 3L,
                            Action = "AddRecord",
                            Controller = "MenuItem",
                            CreatedBy = "System Admin",
                            CreatedOn = new DateTime(2023, 12, 6, 10, 54, 33, 793, DateTimeKind.Local).AddTicks(7190),
                            Icon = "<i class=\"fas fa-plus\"></i>",
                            IsActive = true,
                            MenuId = 1L,
                            Name = "Add Menu Item",
                            OrderNo = 3,
                            ShortName = "Add Menu Item"
                        },
                        new
                        {
                            Id = 4L,
                            Action = "Index",
                            Controller = "MenuItem",
                            CreatedBy = "System Admin",
                            CreatedOn = new DateTime(2023, 12, 6, 10, 54, 33, 793, DateTimeKind.Local).AddTicks(7192),
                            Icon = "<i class=\"fas fa-list\"></i>",
                            IsActive = true,
                            MenuId = 1L,
                            Name = "Menu Item List",
                            OrderNo = 4,
                            ShortName = "Menu Item List"
                        },
                        new
                        {
                            Id = 5L,
                            Action = "AddPermission",
                            Controller = "UserPermission",
                            CreatedBy = "System Admin",
                            CreatedOn = new DateTime(2023, 12, 6, 10, 54, 33, 793, DateTimeKind.Local).AddTicks(7194),
                            Icon = "<i class=\"fas fa-plus\"></i>",
                            IsActive = true,
                            MenuId = 1L,
                            Name = "Menu Permission",
                            OrderNo = 5,
                            ShortName = "Menu Permission"
                        },
                        new
                        {
                            Id = 6L,
                            Action = "AddRecord",
                            Controller = "Company",
                            CreatedBy = "System Admin",
                            CreatedOn = new DateTime(2023, 12, 6, 10, 54, 33, 793, DateTimeKind.Local).AddTicks(7199),
                            Icon = "<i class=\"fas fa-plus\"></i>",
                            IsActive = true,
                            MenuId = 2L,
                            Name = "Add Company",
                            OrderNo = 6,
                            ShortName = "Add Company"
                        },
                        new
                        {
                            Id = 7L,
                            Action = "Index",
                            Controller = "Company",
                            CreatedBy = "System Admin",
                            CreatedOn = new DateTime(2023, 12, 6, 10, 54, 33, 793, DateTimeKind.Local).AddTicks(7200),
                            Icon = "<i class=\"fas fa-list\"></i>",
                            IsActive = true,
                            MenuId = 2L,
                            Name = "Company List",
                            OrderNo = 7,
                            ShortName = "Company List"
                        });
                });

            modelBuilder.Entity("app.EntityModel.CoreModel.UserPermissions", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"), 1L, 1);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<long>("MenuItemId")
                        .HasColumnType("bigint");

                    b.Property<int>("OrderNo")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserPermissions", "dbo");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            CreatedBy = "System Admin",
                            CreatedOn = new DateTime(2023, 12, 6, 10, 54, 33, 793, DateTimeKind.Local).AddTicks(7230),
                            IsActive = true,
                            MenuItemId = 1L,
                            OrderNo = 0,
                            UserId = "0f04028e-587c-47ad-8b36-6dbd6a059fa4"
                        },
                        new
                        {
                            Id = 2L,
                            CreatedBy = "System Admin",
                            CreatedOn = new DateTime(2023, 12, 6, 10, 54, 33, 793, DateTimeKind.Local).AddTicks(7233),
                            IsActive = true,
                            MenuItemId = 2L,
                            OrderNo = 0,
                            UserId = "0f04028e-587c-47ad-8b36-6dbd6a059fa4"
                        },
                        new
                        {
                            Id = 3L,
                            CreatedBy = "System Admin",
                            CreatedOn = new DateTime(2023, 12, 6, 10, 54, 33, 793, DateTimeKind.Local).AddTicks(7234),
                            IsActive = true,
                            MenuItemId = 3L,
                            OrderNo = 0,
                            UserId = "0f04028e-587c-47ad-8b36-6dbd6a059fa4"
                        },
                        new
                        {
                            Id = 4L,
                            CreatedBy = "System Admin",
                            CreatedOn = new DateTime(2023, 12, 6, 10, 54, 33, 793, DateTimeKind.Local).AddTicks(7236),
                            IsActive = true,
                            MenuItemId = 4L,
                            OrderNo = 0,
                            UserId = "0f04028e-587c-47ad-8b36-6dbd6a059fa4"
                        },
                        new
                        {
                            Id = 5L,
                            CreatedBy = "System Admin",
                            CreatedOn = new DateTime(2023, 12, 6, 10, 54, 33, 793, DateTimeKind.Local).AddTicks(7238),
                            IsActive = true,
                            MenuItemId = 5L,
                            OrderNo = 0,
                            UserId = "0f04028e-587c-47ad-8b36-6dbd6a059fa4"
                        },
                        new
                        {
                            Id = 6L,
                            CreatedBy = "System Admin",
                            CreatedOn = new DateTime(2023, 12, 6, 10, 54, 33, 793, DateTimeKind.Local).AddTicks(7240),
                            IsActive = true,
                            MenuItemId = 6L,
                            OrderNo = 0,
                            UserId = "0f04028e-587c-47ad-8b36-6dbd6a059fa4"
                        },
                        new
                        {
                            Id = 7L,
                            CreatedBy = "System Admin",
                            CreatedOn = new DateTime(2023, 12, 6, 10, 54, 33, 793, DateTimeKind.Local).AddTicks(7241),
                            IsActive = true,
                            MenuItemId = 7L,
                            OrderNo = 0,
                            UserId = "0f04028e-587c-47ad-8b36-6dbd6a059fa4"
                        });
                });

            modelBuilder.Entity("app.Infrastructure.Auth.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Prefix")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", "dbo");

                    b.HasData(
                        new
                        {
                            Id = "0f04028e-587c-47ad-8b36-6dbd6a059fa4",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "616a2e8f-dc94-4576-8ec4-c9d75d1df6d1",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "jishan.bd46@gmail.com",
                            EmailConfirmed = true,
                            FullName = "System Admin",
                            IsActive = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "JISHAN.BD46@GMAIL.COM",
                            NormalizedUserName = "ADMINISTRATOR",
                            PasswordHash = "AQAAAAEAACcQAAAAEE8d8uAFK+zBNJ3j+s3k5c6D+OqrJJqgpV0CF42z2UDwqm/kSD/LWNXN8OAx/56YHg==",
                            PhoneNumber = "01840019826",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "37QJAUUNCSSXNFFB6ZXI6OJLHSCS5J6I",
                            TwoFactorEnabled = false,
                            UserName = "administrator",
                            UserType = 1
                        },
                        new
                        {
                            Id = "0f04028e-587c-37ad-8b36-6dbd6a059fa10",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "616a2e8f-dc94-4576-8ec4-c9d75d1df6d9",
                            CreatedOn = new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "cus.jishan@gmail.com",
                            EmailConfirmed = true,
                            FullName = "System Engineers",
                            IsActive = true,
                            LockoutEnabled = false,
                            NormalizedEmail = "CUS.JISHAN@GMAIL.COM",
                            NormalizedUserName = "CUSTOMER",
                            PasswordHash = "AQAAAAEAACcQAAAAEE8d8uAFK+zBNJ3j+s3k5c6D+OqrJJqgpV0CF42z2UDwqm/kSD/LWNXN8OAx/56YHg==",
                            PhoneNumber = "01840019826",
                            PhoneNumberConfirmed = true,
                            SecurityStamp = "37QJAUUNCSSXNFFB6ZXI6OJLHSCS5J63",
                            TwoFactorEnabled = false,
                            UserName = "Customer",
                            UserType = 2
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", "dbo");

                    b.HasData(
                        new
                        {
                            Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                            ConcurrencyStamp = "190d6b51-2737-4517-93e7-09d5f1d5381d",
                            Name = "Customer",
                            NormalizedName = "CUSTOMER"
                        },
                        new
                        {
                            Id = "2c5e174e-3b0e-446f-86af-483d56fd7210",
                            ConcurrencyStamp = "a878e564-30fd-4044-ac0a-22e86f1a8d2f",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", "dbo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", "dbo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", "dbo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", "dbo");

                    b.HasData(
                        new
                        {
                            UserId = "0f04028e-587c-47ad-8b36-6dbd6a059fa4",
                            RoleId = "2c5e174e-3b0e-446f-86af-483d56fd7210"
                        },
                        new
                        {
                            UserId = "0f04028e-587c-37ad-8b36-6dbd6a059fa10",
                            RoleId = "8e445865-a24d-4543-a6c6-9443d048cdb9"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", "dbo");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("app.Infrastructure.Auth.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("app.Infrastructure.Auth.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("app.Infrastructure.Auth.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("app.Infrastructure.Auth.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
