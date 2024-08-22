using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioSiteApi.Migrations
{
    /// <inheritdoc />
    public partial class GettingSkillsWithProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MediaUrls",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "SkillNames",
                table: "projects");

            migrationBuilder.AddColumn<int>(
                name: "ProjectId2",
                table: "skill_project",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SkillId2",
                table: "skill_project",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MediaId2",
                table: "media_project",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId2",
                table: "media_project",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProjectId2",
                table: "skill_project");

            migrationBuilder.DropColumn(
                name: "SkillId2",
                table: "skill_project");

            migrationBuilder.DropColumn(
                name: "MediaId2",
                table: "media_project");

            migrationBuilder.DropColumn(
                name: "ProjectId2",
                table: "media_project");

            migrationBuilder.AddColumn<List<string>>(
                name: "MediaUrls",
                table: "projects",
                type: "text[]",
                nullable: false);

            migrationBuilder.AddColumn<List<string>>(
                name: "SkillNames",
                table: "projects",
                type: "text[]",
                nullable: false);
        }
    }
}
