﻿// <auto-generated />
using System;
using System.Collections.Generic;
using IntegrationLibrary.BloodSubscription.Model;
using IntegrationLibrary.Settings;
using IntegrationLibrary.Tender.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace IntegrationLibrary.Migrations
{
    [DbContext(typeof(IntegrationDbContext))]
    [Migration("20230112164531_pcg")]
    partial class pcg
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("IntegrationLibrary.BloodBank.BloodBank", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("ServerAddress")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("BloodBanks");

                    b.HasData(
                        new
                        {
                            Id = new Guid("c4d6151d-9120-4c9d-a628-95010dfac4be"),
                            Email = "aas@gmail.com",
                            Name = "BloodBank",
                            Password = "VNEXwZIHrujyvlg0wnmHM2FkQ52BKSkUTv5Gobgj4MeeAADy",
                            ServerAddress = "localhost"
                        });
                });

            modelBuilder.Entity("IntegrationLibrary.BloodRequests.Model.BloodRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<Guid>("BloodBankId")
                        .HasColumnType("uuid");

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<DateTime>("Date")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("DoctorUsername")
                        .HasColumnType("text");

                    b.Property<string>("Reason")
                        .HasColumnType("text");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int>("Type")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("BloodRequests");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5688fe01-ed76-4692-b3e5-17974d3484d7"),
                            Amount = 10.0,
                            BloodBankId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Comment = "",
                            Date = new DateTime(2022, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorUsername = "Ilija",
                            Reason = "Operacija",
                            Status = 2,
                            Type = 5
                        },
                        new
                        {
                            Id = new Guid("3ab06b3c-b579-47df-a4fd-7d9faaf175f3"),
                            Amount = 20.0,
                            BloodBankId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Comment = "",
                            Date = new DateTime(2022, 12, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorUsername = "Ilija",
                            Reason = "Transfuzija",
                            Status = 2,
                            Type = 3
                        },
                        new
                        {
                            Id = new Guid("137f67b5-1a37-4f69-bda8-c5194436b056"),
                            Amount = 20.0,
                            BloodBankId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Comment = "",
                            Date = new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorUsername = "Ilija",
                            Reason = "Transfuzija",
                            Status = 2,
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("8385b40b-4ed1-45a8-a84d-c8b3ace4fc93"),
                            Amount = 5.0,
                            BloodBankId = new Guid("00000000-0000-0000-0000-000000000000"),
                            Comment = "",
                            Date = new DateTime(2023, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DoctorUsername = "Ilija",
                            Reason = "Zalihe",
                            Status = 2,
                            Type = 6
                        });
                });

            modelBuilder.Entity("IntegrationLibrary.BloodSubscription.Model.AmountOfBloodType", b =>
                {
                    b.Property<int>("amount")
                        .HasColumnType("integer");

                    b.Property<int>("bloodType")
                        .HasColumnType("integer");

                    b.ToTable("AmountOfBloodType");
                });

            modelBuilder.Entity("IntegrationLibrary.BloodSubscription.Model.MounthlyBloodSubscription", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<List<AmountOfBloodType>>("amountOfBloodTypes")
                        .HasColumnType("jsonb");

                    b.Property<Guid>("bloodBankId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("dateAndTimeOfSubscription")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("id");

                    b.ToTable("BloodSubscriptions");
                });

            modelBuilder.Entity("IntegrationLibrary.ConfigureGenerateAndSend.Model.ConfigureGenerateAndSend", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("BloodBankName")
                        .HasColumnType("text");

                    b.Property<string>("GeneratePeriod")
                        .HasColumnType("text");

                    b.Property<DateTime>("NextDateForSending")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("SendPeriod")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ConfigureGenerateAndSend");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8bb25d4d-1c06-4ed0-8a13-200f63702149"),
                            BloodBankName = "Moja Banka Krvi",
                            GeneratePeriod = "ONE_MONTH",
                            NextDateForSending = new DateTime(2023, 1, 12, 17, 45, 31, 7, DateTimeKind.Local).AddTicks(6384),
                            SendPeriod = "EVERY_TWO_MINUT"
                        },
                        new
                        {
                            Id = new Guid("e2739915-75ee-479a-9ab7-7c50792ca94a"),
                            BloodBankName = "Nova banka",
                            GeneratePeriod = "TWO_MONTH",
                            NextDateForSending = new DateTime(2023, 1, 12, 17, 45, 31, 16, DateTimeKind.Local).AddTicks(577),
                            SendPeriod = "ONE_MONTH"
                        });
                });

            modelBuilder.Entity("IntegrationLibrary.NewsFromBloodBank.Model.NewsFromBloodBank", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("apiKey")
                        .HasColumnType("text");

                    b.Property<string>("base64image")
                        .HasColumnType("text");

                    b.Property<string>("bloodBankName")
                        .HasColumnType("text");

                    b.Property<string>("content")
                        .HasColumnType("text");

                    b.Property<int>("newsStatus")
                        .HasColumnType("integer");

                    b.Property<string>("title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("NewsFromBloodBank");
                });

            modelBuilder.Entity("IntegrationLibrary.Tender.Model.BloodUnitAmount", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("Amount")
                        .HasColumnType("integer");

                    b.Property<int>("BloodType")
                        .HasColumnType("integer");

                    b.Property<Guid>("TenderId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("TenderId");

                    b.ToTable("BloodUnitAmounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("33a3e7bb-a1f6-48dc-87d1-4fe4f682a0e0"),
                            Amount = 10,
                            BloodType = 0,
                            TenderId = new Guid("7ca10354-6187-4a5e-bfa7-9bfd17ca049f")
                        },
                        new
                        {
                            Id = new Guid("894f892a-cbee-4adb-a61c-c64f941577fe"),
                            Amount = 0,
                            BloodType = 1,
                            TenderId = new Guid("7ca10354-6187-4a5e-bfa7-9bfd17ca049f")
                        },
                        new
                        {
                            Id = new Guid("8f10b275-b110-4088-8a72-f81a37aa09f4"),
                            Amount = 5,
                            BloodType = 2,
                            TenderId = new Guid("7ca10354-6187-4a5e-bfa7-9bfd17ca049f")
                        },
                        new
                        {
                            Id = new Guid("7a25d2b8-6222-4883-b9e2-f3994931bb91"),
                            Amount = 0,
                            BloodType = 3,
                            TenderId = new Guid("7ca10354-6187-4a5e-bfa7-9bfd17ca049f")
                        },
                        new
                        {
                            Id = new Guid("d2bb6f60-b052-41ed-bf08-1c54a1017232"),
                            Amount = 12,
                            BloodType = 4,
                            TenderId = new Guid("7ca10354-6187-4a5e-bfa7-9bfd17ca049f")
                        },
                        new
                        {
                            Id = new Guid("34c84d1d-9178-437b-af16-528d51da1326"),
                            Amount = 7,
                            BloodType = 5,
                            TenderId = new Guid("7ca10354-6187-4a5e-bfa7-9bfd17ca049f")
                        },
                        new
                        {
                            Id = new Guid("d539f3e9-3f47-40b2-b2bd-9eb41a70b21d"),
                            Amount = 10,
                            BloodType = 6,
                            TenderId = new Guid("7ca10354-6187-4a5e-bfa7-9bfd17ca049f")
                        },
                        new
                        {
                            Id = new Guid("5bcfc684-27f1-4fa6-a0db-30964885778d"),
                            Amount = 0,
                            BloodType = 7,
                            TenderId = new Guid("7ca10354-6187-4a5e-bfa7-9bfd17ca049f")
                        },
                        new
                        {
                            Id = new Guid("9b913f15-e903-4b29-bacb-fc318c6e2b22"),
                            Amount = 7,
                            BloodType = 5,
                            TenderId = new Guid("9c9d914b-8dd3-4a73-b3f5-ebe2cc3947f4")
                        },
                        new
                        {
                            Id = new Guid("19e7fc7a-594c-4859-900c-2dde9c1781fa"),
                            Amount = 10,
                            BloodType = 6,
                            TenderId = new Guid("9c9d914b-8dd3-4a73-b3f5-ebe2cc3947f4")
                        },
                        new
                        {
                            Id = new Guid("2c9d5d0f-f2c0-486a-8e05-2eb88ba6a086"),
                            Amount = 0,
                            BloodType = 7,
                            TenderId = new Guid("9c9d914b-8dd3-4a73-b3f5-ebe2cc3947f4")
                        });
                });

            modelBuilder.Entity("IntegrationLibrary.Tender.Model.Tender", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("DeadlineDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("HasDeadline")
                        .HasColumnType("boolean");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<IEnumerable<TenderOffer>>("TenderOffer")
                        .HasColumnType("jsonb");

                    b.Property<TenderOffer>("Winner")
                        .HasColumnType("jsonb");

                    b.HasKey("Id");

                    b.ToTable("Tenders");

                    b.HasData(
                        new
                        {
                            Id = new Guid("7ca10354-6187-4a5e-bfa7-9bfd17ca049f"),
                            DeadlineDate = new DateTime(2023, 2, 1, 17, 45, 31, 16, DateTimeKind.Local).AddTicks(2836),
                            HasDeadline = true,
                            PublishedDate = new DateTime(2023, 1, 12, 17, 45, 31, 16, DateTimeKind.Local).AddTicks(3283),
                            Status = 0
                        },
                        new
                        {
                            Id = new Guid("9c9d914b-8dd3-4a73-b3f5-ebe2cc3947f4"),
                            DeadlineDate = new DateTime(2023, 1, 11, 17, 45, 31, 16, DateTimeKind.Local).AddTicks(3987),
                            HasDeadline = true,
                            PublishedDate = new DateTime(2023, 1, 8, 17, 45, 31, 16, DateTimeKind.Local).AddTicks(4002),
                            Status = 2
                        });
                });

            modelBuilder.Entity("IntegrationLibrary.Tender.Model.TenderOffer", b =>
                {
                    b.Property<string>("BloodBankName")
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("RealizationDate")
                        .HasColumnType("timestamp without time zone");

                    b.ToTable("TenderOffer");
                });

            modelBuilder.Entity("IntegrationLibrary.BloodBank.BloodBank", b =>
                {
                    b.OwnsOne("IntegrationLibrary.BloodBank.Model.ApiKey", "ApiKey", b1 =>
                        {
                            b1.Property<Guid>("BloodBankId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Value")
                                .HasColumnType("text");

                            b1.HasKey("BloodBankId");

                            b1.ToTable("BloodBanks");

                            b1.WithOwner()
                                .HasForeignKey("BloodBankId");

                            b1.HasData(
                                new
                                {
                                    BloodBankId = new Guid("c4d6151d-9120-4c9d-a628-95010dfac4be"),
                                    Value = "43fk0+gMyg60ABOS1Nvf9u7QyRlFURUw2uKa6FhC688="
                                });
                        });

                    b.Navigation("ApiKey");
                });

            modelBuilder.Entity("IntegrationLibrary.Tender.Model.BloodUnitAmount", b =>
                {
                    b.HasOne("IntegrationLibrary.Tender.Model.Tender", "Tender")
                        .WithMany("BloodUnitAmount")
                        .HasForeignKey("TenderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tender");
                });

            modelBuilder.Entity("IntegrationLibrary.Tender.Model.Tender", b =>
                {
                    b.Navigation("BloodUnitAmount");
                });
#pragma warning restore 612, 618
        }
    }
}
