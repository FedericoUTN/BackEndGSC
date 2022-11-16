using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LoanAPI.Migrations
{
    public partial class fixentities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Persons_PersonId",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Things_ThingId",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Addresses_AddressId",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Persons",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ThingId",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Loans",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Persons_PersonId",
                table: "Loans",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Things_ThingId",
                table: "Loans",
                column: "ThingId",
                principalTable: "Things",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Addresses_AddressId",
                table: "Persons",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Persons_PersonId",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Loans_Things_ThingId",
                table: "Loans");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Addresses_AddressId",
                table: "Persons");

            migrationBuilder.AlterColumn<int>(
                name: "AddressId",
                table: "Persons",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "ThingId",
                table: "Loans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PersonId",
                table: "Loans",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Persons_PersonId",
                table: "Loans",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Loans_Things_ThingId",
                table: "Loans",
                column: "ThingId",
                principalTable: "Things",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Addresses_AddressId",
                table: "Persons",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }
    }
}
