using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortfolioSiteApi.Migrations
{
    /// <inheritdoc />
    public partial class SkillAndMediaInProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_media_project_media_MediaId1",
                table: "media_project");

            migrationBuilder.DropForeignKey(
                name: "FK_media_project_projects_ProjectId1",
                table: "media_project");

            migrationBuilder.DropForeignKey(
                name: "FK_skill_project_projects_ProjectId1",
                table: "skill_project");

            migrationBuilder.DropForeignKey(
                name: "FK_skill_project_skills_SkillId1",
                table: "skill_project");

            migrationBuilder.DropIndex(
                name: "IX_skill_project_ProjectId1",
                table: "skill_project");

            migrationBuilder.DropIndex(
                name: "IX_skill_project_SkillId1",
                table: "skill_project");

            migrationBuilder.DropIndex(
                name: "IX_media_project_MediaId1",
                table: "media_project");

            migrationBuilder.DropIndex(
                name: "IX_media_project_ProjectId1",
                table: "media_project");

            migrationBuilder.DropColumn(
                name: "ProjectId1",
                table: "skill_project");

            migrationBuilder.DropColumn(
                name: "ProjectId2",
                table: "skill_project");

            migrationBuilder.DropColumn(
                name: "SkillId1",
                table: "skill_project");

            migrationBuilder.DropColumn(
                name: "SkillId2",
                table: "skill_project");

            migrationBuilder.DropColumn(
                name: "MediaId1",
                table: "media_project");

            migrationBuilder.DropColumn(
                name: "MediaId2",
                table: "media_project");

            migrationBuilder.DropColumn(
                name: "ProjectId1",
                table: "media_project");

            migrationBuilder.DropColumn(
                name: "ProjectId2",
                table: "media_project");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectId1",
                table: "skill_project",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId2",
                table: "skill_project",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SkillId1",
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
                name: "MediaId1",
                table: "media_project",
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
                name: "ProjectId1",
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

            migrationBuilder.CreateIndex(
                name: "IX_skill_project_ProjectId1",
                table: "skill_project",
                column: "ProjectId1");

            migrationBuilder.CreateIndex(
                name: "IX_skill_project_SkillId1",
                table: "skill_project",
                column: "SkillId1");

            migrationBuilder.CreateIndex(
                name: "IX_media_project_MediaId1",
                table: "media_project",
                column: "MediaId1");

            migrationBuilder.CreateIndex(
                name: "IX_media_project_ProjectId1",
                table: "media_project",
                column: "ProjectId1");

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

            migrationBuilder.AddForeignKey(
                name: "FK_skill_project_projects_ProjectId1",
                table: "skill_project",
                column: "ProjectId1",
                principalTable: "projects",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_skill_project_skills_SkillId1",
                table: "skill_project",
                column: "SkillId1",
                principalTable: "skills",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
