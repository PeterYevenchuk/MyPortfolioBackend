using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MyPortfolio.Core.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.CreateTable(
                name: "AboutMe",
                schema: "public",
                columns: table => new
                {
                    AboutMeID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Surname = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Age = table.Column<byte>(type: "smallint", nullable: false),
                    Location = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Position = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PhotoMeUrl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutMe", x => x.AboutMeID);
                });

            migrationBuilder.CreateTable(
                name: "Certificates",
                schema: "public",
                columns: table => new
                {
                    CertificateID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    CertificatePdf = table.Column<byte[]>(type: "bytea", nullable: false),
                    AboutMeID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certificates", x => x.CertificateID);
                    table.ForeignKey(
                        name: "FK_Certificates_AboutMe_AboutMeID",
                        column: x => x.AboutMeID,
                        principalSchema: "public",
                        principalTable: "AboutMe",
                        principalColumn: "AboutMeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Educations",
                schema: "public",
                columns: table => new
                {
                    EducationID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Rang = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Speciality = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    University = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DateStart = table.Column<DateOnly>(type: "date", nullable: false),
                    DateFinish = table.Column<DateOnly>(type: "date", nullable: true),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    AboutMeID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Educations", x => x.EducationID);
                    table.ForeignKey(
                        name: "FK_Educations_AboutMe_AboutMeID",
                        column: x => x.AboutMeID,
                        principalSchema: "public",
                        principalTable: "AboutMe",
                        principalColumn: "AboutMeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Experiences",
                schema: "public",
                columns: table => new
                {
                    ExperienceID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Place = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Company = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Position = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    DateStart = table.Column<DateOnly>(type: "date", nullable: false),
                    DateFinish = table.Column<DateOnly>(type: "date", nullable: true),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    AboutMeID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Experiences", x => x.ExperienceID);
                    table.ForeignKey(
                        name: "FK_Experiences_AboutMe_AboutMeID",
                        column: x => x.AboutMeID,
                        principalSchema: "public",
                        principalTable: "AboutMe",
                        principalColumn: "AboutMeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                schema: "public",
                columns: table => new
                {
                    ProjectID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    PhotoProjectUrl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Description = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    GitHubUrl = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    AboutMeID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectID);
                    table.ForeignKey(
                        name: "FK_Projects_AboutMe_AboutMeID",
                        column: x => x.AboutMeID,
                        principalSchema: "public",
                        principalTable: "AboutMe",
                        principalColumn: "AboutMeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                schema: "public",
                columns: table => new
                {
                    SkillID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    MySkill = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    AboutMeID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.SkillID);
                    table.ForeignKey(
                        name: "FK_Skills_AboutMe_AboutMeID",
                        column: x => x.AboutMeID,
                        principalSchema: "public",
                        principalTable: "AboutMe",
                        principalColumn: "AboutMeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SocialLinks",
                schema: "public",
                columns: table => new
                {
                    SocialLinkID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn),
                    Name = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    URL = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    AboutMeID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialLinks", x => x.SocialLinkID);
                    table.ForeignKey(
                        name: "FK_SocialLinks_AboutMe_AboutMeID",
                        column: x => x.AboutMeID,
                        principalSchema: "public",
                        principalTable: "AboutMe",
                        principalColumn: "AboutMeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certificates_AboutMeID",
                schema: "public",
                table: "Certificates",
                column: "AboutMeID");

            migrationBuilder.CreateIndex(
                name: "IX_Educations_AboutMeID",
                schema: "public",
                table: "Educations",
                column: "AboutMeID");

            migrationBuilder.CreateIndex(
                name: "IX_Experiences_AboutMeID",
                schema: "public",
                table: "Experiences",
                column: "AboutMeID");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_AboutMeID",
                schema: "public",
                table: "Projects",
                column: "AboutMeID");

            migrationBuilder.CreateIndex(
                name: "IX_Skills_AboutMeID",
                schema: "public",
                table: "Skills",
                column: "AboutMeID");

            migrationBuilder.CreateIndex(
                name: "IX_SocialLinks_AboutMeID",
                schema: "public",
                table: "SocialLinks",
                column: "AboutMeID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certificates",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Educations",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Experiences",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Projects",
                schema: "public");

            migrationBuilder.DropTable(
                name: "Skills",
                schema: "public");

            migrationBuilder.DropTable(
                name: "SocialLinks",
                schema: "public");

            migrationBuilder.DropTable(
                name: "AboutMe",
                schema: "public");
        }
    }
}
