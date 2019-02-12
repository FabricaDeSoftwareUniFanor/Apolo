﻿// <auto-generated />
using ApoloWebApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace ApoloWebApi.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20190212141340_add Tabela Antropometria")]
    partial class addTabelaAntropometria
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApoloWebApi.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("ApoloWebApi.Data.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("BirthDate");

                    b.Property<string>("Name");

                    b.Property<string>("Occupation");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Persons");
                });

            modelBuilder.Entity("ApoloWebApi.Data.VO.Evaluations.Anamnese", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<string>("DiabetesHipoglicemia");

                    b.Property<string>("DistAlergico");

                    b.Property<string>("DistCardiaco");

                    b.Property<string>("DistPlmonar");

                    b.Property<string>("DoresFrequentes");

                    b.Property<string>("Eplepsia");

                    b.Property<string>("HipertensaoHipotensao");

                    b.Property<string>("Historico");

                    b.Property<string>("InfluAtvdFisica");

                    b.Property<string>("IntervCirurgica");

                    b.Property<string>("Objetivos");

                    b.Property<int>("PatientId");

                    b.Property<string>("ProblArticular");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Anamneses");
                });

            modelBuilder.Entity("ApoloWebApi.Data.VO.Evaluations.Antropometria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<float>("Abdominal");

                    b.Property<float>("AxilaMedia");

                    b.Property<float>("Biceps");

                    b.Property<float>("BracoDContraido");

                    b.Property<float>("BracoDRelaxado");

                    b.Property<float>("BracoEContraido");

                    b.Property<float>("BracoERelaxado");

                    b.Property<float>("Cintura");

                    b.Property<float>("CinturaMenorP");

                    b.Property<float>("CinturaUmbilical");

                    b.Property<float>("Coxa");

                    b.Property<float>("CoxaD");

                    b.Property<float>("CoxaE");

                    b.Property<DateTime>("Date");

                    b.Property<float>("DiametroFemur");

                    b.Property<float>("DiametroRadio");

                    b.Property<float>("Estatura");

                    b.Property<float>("Gordura");

                    b.Property<float>("IMC");

                    b.Property<float>("IMCMax");

                    b.Property<float>("IMCMed");

                    b.Property<float>("IMCMin");

                    b.Property<float>("JacksonPollock");

                    b.Property<float>("MassaMagra");

                    b.Property<float>("Panturrilha");

                    b.Property<float>("PanturrilhaD");

                    b.Property<float>("PanturrilhaE");

                    b.Property<int>("PatientId");

                    b.Property<float>("Peitoral");

                    b.Property<float>("Peso");

                    b.Property<float>("PesoGordura");

                    b.Property<float>("PesoMuscular");

                    b.Property<float>("PesoOsseo");

                    b.Property<float>("PesoResidual");

                    b.Property<float>("Quadril");

                    b.Property<float>("Subescapular");

                    b.Property<float>("SupraIliaca");

                    b.Property<float>("TonicidadeMusc");

                    b.Property<float>("ToraxLinhaMamilos");

                    b.Property<float>("ToraxMesmoEsternal");

                    b.Property<float>("Triceps");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Antropometrias");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("ApoloWebApi.Data.Person", b =>
                {
                    b.HasOne("ApoloWebApi.Data.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("ApoloWebApi.Data.VO.Evaluations.Anamnese", b =>
                {
                    b.HasOne("ApoloWebApi.Data.Person", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ApoloWebApi.Data.VO.Evaluations.Antropometria", b =>
                {
                    b.HasOne("ApoloWebApi.Data.Person", "Patient")
                        .WithMany()
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("ApoloWebApi.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("ApoloWebApi.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ApoloWebApi.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("ApoloWebApi.Data.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
