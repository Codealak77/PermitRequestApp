﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PermitRequestApp.Infrastructure.Data;

#nullable disable

namespace PermitRequestApp.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240218184011_Initialize")]
    partial class Initialize
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PermitRequestApp.Core.Models.ADUser.ADUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("UserType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.ToTable("ADUsers");
                });

            modelBuilder.Entity("PermitRequestApp.Core.Models.CumulativeLeaveRequest.CumulativeLeaveRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LeaveType")
                        .HasColumnType("int");

                    b.Property<int?>("TotalHours")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CumulativeLeaveRequests");
                });

            modelBuilder.Entity("PermitRequestApp.Core.Models.LeaveRequest.LeaveRequest", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AssignedUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CreatedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FormNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("LastModifiedById")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LeaveType")
                        .HasColumnType("int");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequestNumber")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("WorkflowStatus")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AssignedUserId");

                    b.HasIndex("CreatedById");

                    b.HasIndex("LastModifiedById");

                    b.ToTable("LeaveRequests");
                });

            modelBuilder.Entity("PermitRequestApp.Core.Models.Notification.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("CumulativeLeaveRequestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CumulativeLeaveRequestId");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("PermitRequestApp.Core.Models.ADUser.ADUser", b =>
                {
                    b.HasOne("PermitRequestApp.Core.Models.ADUser.ADUser", "Manager")
                        .WithMany()
                        .HasForeignKey("ManagerId");

                    b.Navigation("Manager");
                });

            modelBuilder.Entity("PermitRequestApp.Core.Models.CumulativeLeaveRequest.CumulativeLeaveRequest", b =>
                {
                    b.HasOne("PermitRequestApp.Core.Models.ADUser.ADUser", "ADUser")
                        .WithMany("CumulativeLeaveRequestList")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ADUser");
                });

            modelBuilder.Entity("PermitRequestApp.Core.Models.LeaveRequest.LeaveRequest", b =>
                {
                    b.HasOne("PermitRequestApp.Core.Models.ADUser.ADUser", "AssignedUser")
                        .WithMany("AssignedToMeList")
                        .HasForeignKey("AssignedUserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("PermitRequestApp.Core.Models.ADUser.ADUser", "CreatedBy")
                        .WithMany("CreatedByMeList")
                        .HasForeignKey("CreatedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("PermitRequestApp.Core.Models.ADUser.ADUser", "LastModifiedBy")
                        .WithMany("ModifiedByMeList")
                        .HasForeignKey("LastModifiedById")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("AssignedUser");

                    b.Navigation("CreatedBy");

                    b.Navigation("LastModifiedBy");
                });

            modelBuilder.Entity("PermitRequestApp.Core.Models.Notification.Notification", b =>
                {
                    b.HasOne("PermitRequestApp.Core.Models.CumulativeLeaveRequest.CumulativeLeaveRequest", "CumulativeLeaveRequest")
                        .WithMany("NotificationList")
                        .HasForeignKey("CumulativeLeaveRequestId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("PermitRequestApp.Core.Models.ADUser.ADUser", "ADUser")
                        .WithMany("NotificationList")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("ADUser");

                    b.Navigation("CumulativeLeaveRequest");
                });

            modelBuilder.Entity("PermitRequestApp.Core.Models.ADUser.ADUser", b =>
                {
                    b.Navigation("AssignedToMeList");

                    b.Navigation("CreatedByMeList");

                    b.Navigation("CumulativeLeaveRequestList");

                    b.Navigation("ModifiedByMeList");

                    b.Navigation("NotificationList");
                });

            modelBuilder.Entity("PermitRequestApp.Core.Models.CumulativeLeaveRequest.CumulativeLeaveRequest", b =>
                {
                    b.Navigation("NotificationList");
                });
#pragma warning restore 612, 618
        }
    }
}
