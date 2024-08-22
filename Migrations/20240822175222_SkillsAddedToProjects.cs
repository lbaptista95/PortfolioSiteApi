using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PortfolioSiteApi.Migrations
{
    /// <inheritdoc />
    public partial class SkillsAddedToProjects : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "MediaId1",
                table: "media_project",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId1",
                table: "media_project",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "skills",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skills", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "skill_project",
                columns: table => new
                {
                    project_id = table.Column<int>(type: "integer", nullable: false),
                    skill_id = table.Column<int>(type: "integer", nullable: false),
                    ProjectId1 = table.Column<int>(type: "integer", nullable: false),
                    SkillId1 = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_skill_project", x => new { x.project_id, x.skill_id });
                    table.ForeignKey(
                        name: "FK_skill_project_projects_ProjectId1",
                        column: x => x.ProjectId1,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_skill_project_projects_project_id",
                        column: x => x.project_id,
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_skill_project_skills_SkillId1",
                        column: x => x.SkillId1,
                        principalTable: "skills",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_skill_project_skills_skill_id",
                        column: x => x.skill_id,
                        principalTable: "skills",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_media_project_MediaId1",
                table: "media_project",
                column: "MediaId1");

            migrationBuilder.CreateIndex(
                name: "IX_media_project_ProjectId1",
                table: "media_project",
                column: "ProjectId1");

            migrationBuilder.CreateIndex(
                name: "IX_skill_project_ProjectId1",
                table: "skill_project",
                column: "ProjectId1");

            migrationBuilder.CreateIndex(
                name: "IX_skill_project_skill_id",
                table: "skill_project",
                column: "skill_id");

            migrationBuilder.CreateIndex(
                name: "IX_skill_project_SkillId1",
                table: "skill_project",
                column: "SkillId1");

            migrationBuilder.AddForeignKey(
                name: "FK_media_project_media_MediaId1",
                table: "media_project",
                column: "MediaId1",
                principalTable: "media",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_media_project_projects_ProjectId1",
                table: "media_project",
                column: "ProjectId1",
                principalTable: "projects",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_media_project_media_MediaId1",
                table: "media_project");

            migrationBuilder.DropForeignKey(
                name: "FK_media_project_projects_ProjectId1",
                table: "media_project");

            migrationBuilder.DropTable(
                name: "skill_project");

            migrationBuilder.DropTable(
                name: "skills");

            migrationBuilder.DropIndex(
                name: "IX_media_project_MediaId1",
                table: "media_project");

            migrationBuilder.DropIndex(
                name: "IX_media_project_ProjectId1",
                table: "media_project");

            migrationBuilder.DropColumn(
                name: "MediaUrls",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "SkillNames",
                table: "projects");

            migrationBuilder.DropColumn(
                name: "MediaId1",
                table: "media_project");

            migrationBuilder.DropColumn(
                name: "ProjectId1",
                table: "media_project");
        }
    }
}
