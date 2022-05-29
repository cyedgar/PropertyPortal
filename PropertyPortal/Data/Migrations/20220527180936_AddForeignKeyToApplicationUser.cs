using Microsoft.EntityFrameworkCore.Migrations;

namespace PropertyPortal.Data.Migrations
{
    public partial class AddForeignKeyToApplicationUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_AspNetUsers_AgentId",
                table: "Property");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_AspNetUsers_AgentId",
                table: "Transaction");

            migrationBuilder.RenameColumn(
                name: "AgentId",
                table: "Transaction",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_AgentId",
                table: "Transaction",
                newName: "IX_Transaction_UserId");

            migrationBuilder.RenameColumn(
                name: "AgentId",
                table: "Property",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Property_AgentId",
                table: "Property",
                newName: "IX_Property_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Property_AspNetUsers_UserId",
                table: "Property",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_AspNetUsers_UserId",
                table: "Transaction",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_AspNetUsers_UserId",
                table: "Property");

            migrationBuilder.DropForeignKey(
                name: "FK_Transaction_AspNetUsers_UserId",
                table: "Transaction");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Transaction",
                newName: "AgentId");

            migrationBuilder.RenameIndex(
                name: "IX_Transaction_UserId",
                table: "Transaction",
                newName: "IX_Transaction_AgentId");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Property",
                newName: "AgentId");

            migrationBuilder.RenameIndex(
                name: "IX_Property_UserId",
                table: "Property",
                newName: "IX_Property_AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Property_AspNetUsers_AgentId",
                table: "Property",
                column: "AgentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Transaction_AspNetUsers_AgentId",
                table: "Transaction",
                column: "AgentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
