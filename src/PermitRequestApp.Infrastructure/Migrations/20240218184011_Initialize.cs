using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PermitRequestApp.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initialize : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ADUsers",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserType = table.Column<int>(type: "int", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ADUsers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ADUsers_ADUsers_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "ADUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CumulativeLeaveRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LeaveType = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TotalHours = table.Column<int>(type: "int", nullable: true),
                    Year = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CumulativeLeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CumulativeLeaveRequests_ADUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ADUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FormNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RequestNumber = table.Column<int>(type: "int", nullable: false),
                    LeaveType = table.Column<int>(type: "int", nullable: false),
                    Reason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WorkflowStatus = table.Column<int>(type: "int", nullable: false),
                    AssignedUserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LastModifiedById = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_ADUsers_AssignedUserId",
                        column: x => x.AssignedUserId,
                        principalTable: "ADUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeaveRequests_ADUsers_CreatedById",
                        column: x => x.CreatedById,
                        principalTable: "ADUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_LeaveRequests_ADUsers_LastModifiedById",
                        column: x => x.LastModifiedById,
                        principalTable: "ADUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CumulativeLeaveRequestId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_ADUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "ADUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Notifications_CumulativeLeaveRequests_CumulativeLeaveRequestId",
                        column: x => x.CumulativeLeaveRequestId,
                        principalTable: "CumulativeLeaveRequests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ADUsers_ManagerId",
                table: "ADUsers",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_CumulativeLeaveRequests_UserId",
                table: "CumulativeLeaveRequests",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_AssignedUserId",
                table: "LeaveRequests",
                column: "AssignedUserId");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_CreatedById",
                table: "LeaveRequests",
                column: "CreatedById");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LastModifiedById",
                table: "LeaveRequests",
                column: "LastModifiedById");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_CumulativeLeaveRequestId",
                table: "Notifications",
                column: "CumulativeLeaveRequestId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "CumulativeLeaveRequests");

            migrationBuilder.DropTable(
                name: "ADUsers");
        }
    }
}
