using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VodusAssignent_Abanoub_Ibrahim.Migrations
{
    /// <inheritdoc />
    public partial class Adding_EmailAndPhoneNumbersColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Product",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Product",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Product");
        }
    }
}
