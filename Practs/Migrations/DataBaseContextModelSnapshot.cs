﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Practs.Data;

#nullable disable

namespace Practs.Migrations
{
    [DbContext(typeof(DataBaseContext))]
    partial class DataBaseContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Practs.Modules.Main.T001", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("BURKS")
                        .HasMaxLength(4)
                        .HasColumnType("character varying(4)");

                    b.Property<string>("BUTXT")
                        .HasMaxLength(25)
                        .HasColumnType("character varying(25)");

                    b.HasKey("Id");

                    b.ToTable("T001", (string)null);
                });

            modelBuilder.Entity("Practs.Modules.Main.ZINMM_SOF_LOT_H", b =>
                {
                    b.Property<int>("LOT_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("LOT_ID"));

                    b.Property<string>("CALC_NDS")
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)");

                    b.Property<string>("EKORG")
                        .HasMaxLength(4)
                        .HasColumnType("character varying(4)");

                    b.Property<decimal>("FINAN_LIMIT_WOVAT")
                        .HasColumnType("numeric");

                    b.Property<decimal>("FINAN_LIMIT_WVAT")
                        .HasColumnType("numeric");

                    b.Property<string>("KONKURS_ID")
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)");

                    b.Property<string>("LOT_NAME")
                        .HasMaxLength(132)
                        .HasColumnType("character varying(132)");

                    b.Property<string>("LOT_NR")
                        .HasMaxLength(30)
                        .HasColumnType("character varying(30)");

                    b.Property<string>("VAT_RATE")
                        .HasMaxLength(2)
                        .HasColumnType("character varying(2)");

                    b.HasKey("LOT_ID");

                    b.ToTable("ZINMM_SOF_LOT_H", (string)null);
                });

            modelBuilder.Entity("Practs.Modules.Main.ZTINMM_TK_H", b =>
                {
                    b.Property<int>("KONKURS_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("KONKURS_ID"));

                    b.Property<string>("BURKS")
                        .HasMaxLength(4)
                        .HasColumnType("character varying(4)");

                    b.Property<DateTime>("CRT_DATE")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeSpan>("CRT_TIME")
                        .HasColumnType("interval");

                    b.Property<string>("CRT_USER")
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)");

                    b.Property<string>("KONKURS_NAME")
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<string>("KONKURS_NR")
                        .HasMaxLength(40)
                        .HasColumnType("character varying(40)");

                    b.Property<string>("ORG_KEY")
                        .HasMaxLength(3)
                        .HasColumnType("character varying(3)");

                    b.Property<string>("STAT")
                        .HasMaxLength(5)
                        .HasColumnType("character varying(5)");

                    b.HasKey("KONKURS_ID");

                    b.ToTable("ZTINMM_TK_H", (string)null);
                });

            modelBuilder.Entity("Practs.Modules.Main.ZTINMM_TK_OFR", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DELIVER_DATE")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeSpan>("DELIVER_TIME")
                        .HasColumnType("interval");

                    b.Property<string>("KONKURS_ID")
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)");

                    b.Property<string>("LIFNR")
                        .HasMaxLength(10)
                        .HasColumnType("character varying(10)");

                    b.Property<string>("LIFNR_NAME")
                        .HasMaxLength(132)
                        .HasColumnType("character varying(132)");

                    b.Property<string>("LOT_ID")
                        .HasMaxLength(12)
                        .HasColumnType("character varying(12)");

                    b.Property<DateTime>("OFR_DATE")
                        .HasColumnType("timestamp with time zone");

                    b.Property<TimeSpan>("OFR_TIME")
                        .HasColumnType("interval");

                    b.Property<decimal>("PRICE_NDS")
                        .HasColumnType("numeric");

                    b.Property<decimal>("PRICE_S_NDS")
                        .HasColumnType("numeric");

                    b.Property<int>("TABIX")
                        .HasMaxLength(5)
                        .HasColumnType("integer");

                    b.Property<string>("WIN_FLG")
                        .HasMaxLength(1)
                        .HasColumnType("character varying(1)");

                    b.HasKey("Id");

                    b.ToTable("ZTINMM_TK_OFR", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
