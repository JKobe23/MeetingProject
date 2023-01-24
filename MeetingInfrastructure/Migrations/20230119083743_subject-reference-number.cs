using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MeetingInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class subjectreferencenumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeMeeting_Employees_employeesID",
                table: "EmployeeMeeting");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeMeeting_Meetings_meetingsId",
                table: "EmployeeMeeting");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Positions_positionID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetingSubject_Meetings_meetingsId",
                table: "MeetingSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetingSubject_Subjects_subjectsID",
                table: "MeetingSubject");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Subjects",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "description",
                table: "Subjects",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "decision",
                table: "Subjects",
                newName: "Decision");

            migrationBuilder.RenameColumn(
                name: "title",
                table: "Positions",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "level",
                table: "Positions",
                newName: "Level");

            migrationBuilder.RenameColumn(
                name: "subjectsID",
                table: "MeetingSubject",
                newName: "SubjectsID");

            migrationBuilder.RenameColumn(
                name: "meetingsId",
                table: "MeetingSubject",
                newName: "MeetingsId");

            migrationBuilder.RenameIndex(
                name: "IX_MeetingSubject_subjectsID",
                table: "MeetingSubject",
                newName: "IX_MeetingSubject_SubjectsID");

            migrationBuilder.RenameColumn(
                name: "refNumber",
                table: "Meetings",
                newName: "RefNumber");

            migrationBuilder.RenameColumn(
                name: "notes",
                table: "Meetings",
                newName: "Notes");

            migrationBuilder.RenameColumn(
                name: "location",
                table: "Meetings",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "date",
                table: "Meetings",
                newName: "Date");

            migrationBuilder.RenameColumn(
                name: "positionID",
                table: "Employees",
                newName: "PositionID");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Employees",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_positionID",
                table: "Employees",
                newName: "IX_Employees_PositionID");

            migrationBuilder.RenameColumn(
                name: "meetingsId",
                table: "EmployeeMeeting",
                newName: "MeetingsId");

            migrationBuilder.RenameColumn(
                name: "employeesID",
                table: "EmployeeMeeting",
                newName: "EmployeesID");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeMeeting_meetingsId",
                table: "EmployeeMeeting",
                newName: "IX_EmployeeMeeting_MeetingsId");

            migrationBuilder.AddColumn<string>(
                name: "RefNumber",
                table: "Subjects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeMeeting_Employees_EmployeesID",
                table: "EmployeeMeeting",
                column: "EmployeesID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeMeeting_Meetings_MeetingsId",
                table: "EmployeeMeeting",
                column: "MeetingsId",
                principalTable: "Meetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Positions_PositionID",
                table: "Employees",
                column: "PositionID",
                principalTable: "Positions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingSubject_Meetings_MeetingsId",
                table: "MeetingSubject",
                column: "MeetingsId",
                principalTable: "Meetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingSubject_Subjects_SubjectsID",
                table: "MeetingSubject",
                column: "SubjectsID",
                principalTable: "Subjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeMeeting_Employees_EmployeesID",
                table: "EmployeeMeeting");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeMeeting_Meetings_MeetingsId",
                table: "EmployeeMeeting");

            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Positions_PositionID",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetingSubject_Meetings_MeetingsId",
                table: "MeetingSubject");

            migrationBuilder.DropForeignKey(
                name: "FK_MeetingSubject_Subjects_SubjectsID",
                table: "MeetingSubject");

            migrationBuilder.DropColumn(
                name: "RefNumber",
                table: "Subjects");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Subjects",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Subjects",
                newName: "description");

            migrationBuilder.RenameColumn(
                name: "Decision",
                table: "Subjects",
                newName: "decision");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Positions",
                newName: "title");

            migrationBuilder.RenameColumn(
                name: "Level",
                table: "Positions",
                newName: "level");

            migrationBuilder.RenameColumn(
                name: "SubjectsID",
                table: "MeetingSubject",
                newName: "subjectsID");

            migrationBuilder.RenameColumn(
                name: "MeetingsId",
                table: "MeetingSubject",
                newName: "meetingsId");

            migrationBuilder.RenameIndex(
                name: "IX_MeetingSubject_SubjectsID",
                table: "MeetingSubject",
                newName: "IX_MeetingSubject_subjectsID");

            migrationBuilder.RenameColumn(
                name: "RefNumber",
                table: "Meetings",
                newName: "refNumber");

            migrationBuilder.RenameColumn(
                name: "Notes",
                table: "Meetings",
                newName: "notes");

            migrationBuilder.RenameColumn(
                name: "Location",
                table: "Meetings",
                newName: "location");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "Meetings",
                newName: "date");

            migrationBuilder.RenameColumn(
                name: "PositionID",
                table: "Employees",
                newName: "positionID");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Employees",
                newName: "name");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_PositionID",
                table: "Employees",
                newName: "IX_Employees_positionID");

            migrationBuilder.RenameColumn(
                name: "MeetingsId",
                table: "EmployeeMeeting",
                newName: "meetingsId");

            migrationBuilder.RenameColumn(
                name: "EmployeesID",
                table: "EmployeeMeeting",
                newName: "employeesID");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeMeeting_MeetingsId",
                table: "EmployeeMeeting",
                newName: "IX_EmployeeMeeting_meetingsId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeMeeting_Employees_employeesID",
                table: "EmployeeMeeting",
                column: "employeesID",
                principalTable: "Employees",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeMeeting_Meetings_meetingsId",
                table: "EmployeeMeeting",
                column: "meetingsId",
                principalTable: "Meetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Positions_positionID",
                table: "Employees",
                column: "positionID",
                principalTable: "Positions",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingSubject_Meetings_meetingsId",
                table: "MeetingSubject",
                column: "meetingsId",
                principalTable: "Meetings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MeetingSubject_Subjects_subjectsID",
                table: "MeetingSubject",
                column: "subjectsID",
                principalTable: "Subjects",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
