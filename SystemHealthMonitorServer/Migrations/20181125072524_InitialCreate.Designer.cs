﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SystemHealthMonitorServer;

namespace SystemHealthMonitorServer.Migrations
{
    [DbContext(typeof(SystemHealthMonitorContext))]
    [Migration("20181125072524_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SystemHealthMonitorServer.Report", b =>
                {
                    b.Property<int>("ReportId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("MachineName");

                    b.Property<DateTime>("Timestamp");

                    b.HasKey("ReportId");

                    b.ToTable("Reports");
                });

            modelBuilder.Entity("SystemHealthMonitorServer.ReportInformation", b =>
                {
                    b.Property<int>("ReportInformationId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int?>("ReportId");

                    b.Property<string>("Status");

                    b.Property<int>("Type");

                    b.HasKey("ReportInformationId");

                    b.HasIndex("ReportId");

                    b.ToTable("ReportInformation");
                });

            modelBuilder.Entity("SystemHealthMonitorServer.ReportInformation", b =>
                {
                    b.HasOne("SystemHealthMonitorServer.Report", "Report")
                        .WithMany("ReportInformation")
                        .HasForeignKey("ReportId");
                });
#pragma warning restore 612, 618
        }
    }
}
