﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SacramentMeetingPlanner.Data;

#nullable disable

namespace SacramentMeetingPlanner.Migrations
{
    [DbContext(typeof(ChurchContext))]
    partial class ChurchContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Assignments", b =>
                {
                    b.Property<int>("AssignmentsID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AssignmentsID"));

                    b.Property<int>("MeetingID")
                        .HasColumnType("int");

                    b.Property<int>("SpeakerID")
                        .HasColumnType("int");

                    b.HasKey("AssignmentsID");

                    b.HasIndex("MeetingID");

                    b.HasIndex("SpeakerID");

                    b.ToTable("Assignments", (string)null);
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Hymn", b =>
                {
                    b.Property<int>("HymnID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HymnID"));

                    b.Property<int>("Number")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HymnID");

                    b.ToTable("Hymns", (string)null);
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Meeting", b =>
                {
                    b.Property<int>("MeetingID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MeetingID"));

                    b.Property<string>("Benediction")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClosingHymn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Conducting")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Invocation")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("MeetingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Notes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumSpeakers")
                        .HasColumnType("int");

                    b.Property<string>("OpeningHymn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SacramentHymn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MeetingID");

                    b.ToTable("Meetings", (string)null);
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Selection", b =>
                {
                    b.Property<int>("SelectionID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SelectionID"));

                    b.Property<int>("HymnID")
                        .HasColumnType("int");

                    b.Property<int>("MeetingID")
                        .HasColumnType("int");

                    b.HasKey("SelectionID");

                    b.HasIndex("HymnID");

                    b.HasIndex("MeetingID");

                    b.ToTable("Selection");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Speaker", b =>
                {
                    b.Property<int>("SpeakerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SpeakerID"));

                    b.Property<int?>("MeetingID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Topic")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpeakerID");

                    b.HasIndex("MeetingID");

                    b.ToTable("Speakers", (string)null);
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Assignments", b =>
                {
                    b.HasOne("SacramentMeetingPlanner.Models.Meeting", "Meeting")
                        .WithMany("Assignments")
                        .HasForeignKey("MeetingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SacramentMeetingPlanner.Models.Speaker", "Speaker")
                        .WithMany("Assignments")
                        .HasForeignKey("SpeakerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Meeting");

                    b.Navigation("Speaker");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Selection", b =>
                {
                    b.HasOne("SacramentMeetingPlanner.Models.Hymn", "Hymn")
                        .WithMany("Selections")
                        .HasForeignKey("HymnID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SacramentMeetingPlanner.Models.Meeting", "Meeting")
                        .WithMany("Selection")
                        .HasForeignKey("MeetingID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Hymn");

                    b.Navigation("Meeting");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Speaker", b =>
                {
                    b.HasOne("SacramentMeetingPlanner.Models.Meeting", null)
                        .WithMany("Speakers")
                        .HasForeignKey("MeetingID");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Hymn", b =>
                {
                    b.Navigation("Selections");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Meeting", b =>
                {
                    b.Navigation("Assignments");

                    b.Navigation("Selection");

                    b.Navigation("Speakers");
                });

            modelBuilder.Entity("SacramentMeetingPlanner.Models.Speaker", b =>
                {
                    b.Navigation("Assignments");
                });
#pragma warning restore 612, 618
        }
    }
}
