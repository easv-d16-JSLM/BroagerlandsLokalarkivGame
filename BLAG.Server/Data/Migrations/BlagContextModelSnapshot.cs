﻿// <auto-generated />
using BLAG.Server.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace BLAG.Server.Migrations
{
    [DbContext(typeof(BlagContext))]
    partial class BlagContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BLAG.Common.Models.AnswerMap", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("AnswerMaps");
                });

            modelBuilder.Entity("BLAG.Common.Models.AnswerNumber", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("AnswerNumbers");
                });

            modelBuilder.Entity("BLAG.Common.Models.AnswerPicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("AnswerPictures");
                });

            modelBuilder.Entity("BLAG.Common.Models.AnswerTextChoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("QuestionId");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("AnswerTextChoices");
                });

            modelBuilder.Entity("BLAG.Common.Models.QuestionBase", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("Points");

                    b.Property<int>("QuestionnaireId");

                    b.Property<TimeSpan>("Time");

                    b.HasKey("Id");

                    b.HasIndex("QuestionnaireId");

                    b.ToTable("QuestionBase");

                    b.HasDiscriminator<string>("Discriminator").HasValue("QuestionBase");
                });

            modelBuilder.Entity("BLAG.Common.Models.Questionnaire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Questionnaires");
                });

            modelBuilder.Entity("BLAG.Common.Models.QuestionText", b =>
                {
                    b.HasBaseType("BLAG.Common.Models.QuestionBase");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasMaxLength(500);

                    b.ToTable("QuestionText");

                    b.HasDiscriminator().HasValue("QuestionText");
                });

            modelBuilder.Entity("BLAG.Common.Models.AnswerMap", b =>
                {
                    b.HasOne("BLAG.Common.Models.QuestionBase", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BLAG.Common.Models.AnswerNumber", b =>
                {
                    b.HasOne("BLAG.Common.Models.QuestionBase", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BLAG.Common.Models.AnswerPicture", b =>
                {
                    b.HasOne("BLAG.Common.Models.QuestionBase", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BLAG.Common.Models.AnswerTextChoice", b =>
                {
                    b.HasOne("BLAG.Common.Models.QuestionBase", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("BLAG.Common.Models.QuestionBase", b =>
                {
                    b.HasOne("BLAG.Common.Models.Questionnaire", "Questionnaire")
                        .WithMany("Questions")
                        .HasForeignKey("QuestionnaireId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
