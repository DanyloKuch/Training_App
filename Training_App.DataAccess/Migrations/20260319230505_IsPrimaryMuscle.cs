using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Training_App.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class IsPrimaryMuscle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPrimary",
                table: "ExerciseMuscles",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPrimary",
                table: "ExerciseMuscles");
        }
    }
}
