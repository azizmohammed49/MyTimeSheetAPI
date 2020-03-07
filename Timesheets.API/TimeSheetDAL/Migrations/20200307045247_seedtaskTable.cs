using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheetDAL.Migrations
{
    public partial class seedtaskTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
                INSERT INTO Task Values('Sick Leave', 'Apply this task on sick leave.')
                INSERT INTO Task Values('Scrum Ceremonies', 'Scrum meetings, standup, sprint plannig, grooming etc.')
                INSERT INTO Task Values('Internal Meeting', 'Meetings Meetings.')
                INSERT INTO Task Values('Development', 'Development tasks, features, change requets.')
                INSERT INTO Task Values('Bug Fixes', 'You know what it means.')
                  GO  ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
