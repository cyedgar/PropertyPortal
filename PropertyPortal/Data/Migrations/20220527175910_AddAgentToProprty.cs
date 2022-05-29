using Microsoft.EntityFrameworkCore.Migrations;

namespace PropertyPortal.Data.Migrations
{
    public partial class AddAgentToProprty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AgentId",
                table: "Property",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Property_AgentId",
                table: "Property",
                column: "AgentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Property_AspNetUsers_AgentId",
                table: "Property",
                column: "AgentId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Property_AspNetUsers_AgentId",
                table: "Property");

            migrationBuilder.DropIndex(
                name: "IX_Property_AgentId",
                table: "Property");

            migrationBuilder.DropColumn(
                name: "AgentId",
                table: "Property");
        }
    }
}
