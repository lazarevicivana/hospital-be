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
    [Migration("20230108135801_Initial")]
    partial class Initial
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
                            Id = new Guid("ddab025c-8f72-40da-8e29-6d6da98f4bf6"),
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
                            Id = new Guid("6a8baa54-66a8-468c-8b41-c91755e025af"),
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
                            Id = new Guid("e2b0cc0d-f5de-4354-ab73-f41af32cfdf7"),
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
                            Id = new Guid("90e94e16-1ce4-427f-91cc-80b632e2e0d2"),
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
                            Id = new Guid("3822f730-047a-4938-a50f-475dd5efaea2"),
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
                            Id = new Guid("2531106b-7123-4aa0-9201-a2863bd917af"),
                            BloodBankName = "Moja Banka Krvi",
                            GeneratePeriod = "ONE_MONTH",
                            NextDateForSending = new DateTime(2023, 1, 8, 14, 58, 0, 767, DateTimeKind.Local).AddTicks(7530),
                            SendPeriod = "EVERY_TWO_MINUT"
                        },
                        new
                        {
                            Id = new Guid("cb35fd83-7320-4907-830b-99cbbddef943"),
                            BloodBankName = "Nova banka",
                            GeneratePeriod = "TWO_MONTH",
                            NextDateForSending = new DateTime(2023, 1, 8, 14, 58, 0, 775, DateTimeKind.Local).AddTicks(9252),
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
                            Id = new Guid("ac6612d1-2735-4811-9af9-79176037120e"),
                            Amount = 10,
                            BloodType = 0,
                            TenderId = new Guid("f32f4f84-1540-461e-b678-433ecb5948d1")
                        },
                        new
                        {
                            Id = new Guid("5f734986-dfb0-42c9-8d34-b4305b356b84"),
                            Amount = 0,
                            BloodType = 1,
                            TenderId = new Guid("f32f4f84-1540-461e-b678-433ecb5948d1")
                        },
                        new
                        {
                            Id = new Guid("8c4e5c95-5b2d-4e0e-8544-493f4c8bb2a8"),
                            Amount = 5,
                            BloodType = 2,
                            TenderId = new Guid("f32f4f84-1540-461e-b678-433ecb5948d1")
                        },
                        new
                        {
                            Id = new Guid("fde4030b-97e2-444e-824a-29d81eff2410"),
                            Amount = 0,
                            BloodType = 3,
                            TenderId = new Guid("f32f4f84-1540-461e-b678-433ecb5948d1")
                        },
                        new
                        {
                            Id = new Guid("88889b90-f039-4dc0-acd3-3da9be1391f9"),
                            Amount = 12,
                            BloodType = 4,
                            TenderId = new Guid("f32f4f84-1540-461e-b678-433ecb5948d1")
                        },
                        new
                        {
                            Id = new Guid("fff8d771-db77-4d27-bc58-d8838a8bf172"),
                            Amount = 7,
                            BloodType = 5,
                            TenderId = new Guid("f32f4f84-1540-461e-b678-433ecb5948d1")
                        },
                        new
                        {
                            Id = new Guid("a57d80f6-2c71-4d2e-b4a6-54aaff9258ae"),
                            Amount = 10,
                            BloodType = 6,
                            TenderId = new Guid("f32f4f84-1540-461e-b678-433ecb5948d1")
                        },
                        new
                        {
                            Id = new Guid("27a2df87-cc14-4ccf-b088-355bbb68025f"),
                            Amount = 0,
                            BloodType = 7,
                            TenderId = new Guid("f32f4f84-1540-461e-b678-433ecb5948d1")
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
                            Id = new Guid("f32f4f84-1540-461e-b678-433ecb5948d1"),
                            DeadlineDate = new DateTime(2023, 1, 28, 14, 58, 0, 776, DateTimeKind.Local).AddTicks(1193),
                            HasDeadline = true,
                            PublishedDate = new DateTime(2023, 1, 8, 14, 58, 0, 776, DateTimeKind.Local).AddTicks(1581),
                            Status = 0
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
                                    BloodBankId = new Guid("ddab025c-8f72-40da-8e29-6d6da98f4bf6"),
                                    Value = "2GxSFNAg5ki181v9vs3v19qIHr704nh27h4GcPC9+64="
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
