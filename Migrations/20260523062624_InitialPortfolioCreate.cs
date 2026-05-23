using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DenzelDev.Migrations
{
    /// <inheritdoc />
    public partial class InitialPortfolioCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Blogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ContentMarkdown = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BannerImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PublishedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReadTimeMinutes = table.Column<int>(type: "int", nullable: false),
                    IsPublished = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Blogs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ContactMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Subject = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactMessages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Slug = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    ShortDescription = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    FullDescriptionMarkdown = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    GithubUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    LiveUrl = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Tags = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Category = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ProficiencyPercent = table.Column<int>(type: "int", nullable: false),
                    IconClass = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Blogs",
                columns: new[] { "Id", "BannerImageUrl", "ContentMarkdown", "CreatedAt", "IsPublished", "PublishedDate", "ReadTimeMinutes", "Slug", "Title" },
                values: new object[,]
                {
                    { 1, "https://images.unsplash.com/photo-1607799279861-4dd421887fb3?q=80&w=800&auto=format&fit=crop", "# Mastering Serverless .NET\n\nWhile Vercel is highly optimized for frontend frameworks and serverless Node.js, we can host complete ASP.NET Core architectures using serverless wrapper runtimes like `vercel-dotnet` or serverless functions proxy gateways.\n\n### In this article we cover:\n1. Setting up your `vercel.json` configurations.\n2. Overcoming cold startup times.\n3. Managing connection pool lifetimes inside stateless serverless blocks.\n4. Configuring environment variable secrets safely.", new DateTime(2026, 4, 15, 0, 0, 0, 0, DateTimeKind.Utc), true, new DateTime(2026, 4, 15, 0, 0, 0, 0, DateTimeKind.Utc), 6, "architecting-aspnet-core-serverless-vercel", "Architecting ASP.NET Core for Serverless Deployment on Vercel" },
                    { 2, "https://images.unsplash.com/photo-1550751827-4bd374c3f58b?q=80&w=800&auto=format&fit=crop", "# Styling Premium Web Shaders\n\nGlassmorphism creates unmatched depth on modern dark-mode interfaces. By leveraging modern backdrop filter effects in combination with thin translucent borders, we can make our cards feel floating and premium.\n\n```css\n.glass-card {\n  background: rgba(18, 24, 36, 0.6);\n  backdrop-filter: blur(12px);\n  border: 1px solid rgba(255, 255, 255, 0.08);\n}\n```\n\nThis article outlines exact steps to layer glassmorphic effects on top of standard Bootstrap columns without breaking flexbox flows.", new DateTime(2026, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), true, new DateTime(2026, 5, 2, 0, 0, 0, 0, DateTimeKind.Utc), 4, "designing-frost-glass-shaders-tailwind-bootstrap", "Designing Frost-Glass Shaders with Raw Tailwind and Bootstrap 5" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Category", "CreatedAt", "FullDescriptionMarkdown", "GithubUrl", "ImageUrl", "LiveUrl", "ShortDescription", "Slug", "Tags", "Title" },
                values: new object[,]
                {
                    { 1, "Full-Stack", new DateTime(2026, 1, 10, 0, 0, 0, 0, DateTimeKind.Utc), "# EventList Management System\n\nThis application utilizes a stateless, strict **Model-View-Presenter (MVP)** structural design pattern with native ADO.NET and Tailwind CSS.\n\n### Key Features\n- Dynamic budget sheet registers.\n- Timeline coordination sheets.\n- Task allocation matrices.\n- Heavy-weight performance optimization.", "https://github.com/Denz14-RDI/Hackathon.git", "https://images.unsplash.com/photo-1540575467063-178a50c2df87?q=80&w=600&auto=format&fit=crop", "https://eventlist-demo.vercel.app", "An enterprise-grade, web-based planning platform tailored for student councils, academic organizations, and campus clubs.", "eventlist-planning-system", "C#,MVP,ADO.NET,SQL Server,Tailwind", "EventList Planning System" },
                    { 2, "Full-Stack", new DateTime(2026, 2, 20, 0, 0, 0, 0, DateTimeKind.Utc), "# Premium Portfolio System\n\nDesigned for maximum elegance, using a custom dark mode palette with cyber-mint accents and micro-animations.\n\n### Highlights\n- Custom **glassmorphism** card shaders.\n- Responsive career timeline nodes.\n- Complete CMS back-office CRUD for blogs and projects.\n- SEO-optimized slug matching.", "https://github.com/Denz14-RDI/Hackathon.git", "https://images.unsplash.com/photo-1460925895917-afdab827c52f?q=80&w=600&auto=format&fit=crop", "https://denzeldev-portfolio.vercel.app", "A highly performance-optimized, glassmorphic portfolio styled over Bootstrap 5 and backed by ASP.NET Core MVC and SQL Server.", "minimalist-developer-portfolio", "C#,ASP.NET Core,EF Core,SQL Server,Bootstrap 5", "Minimalist Developer Portfolio" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Category", "IconClass", "Name", "ProficiencyPercent" },
                values: new object[,]
                {
                    { 1, "Languages", "bi bi-filetype-cs", "C# / .NET", 92 },
                    { 2, "Languages", "bi bi-database", "SQL / T-SQL", 88 },
                    { 3, "Languages", "bi bi-filetype-js", "TypeScript / JS", 85 },
                    { 4, "Frameworks", "bi bi-bootstrap", "ASP.NET Core MVC", 90 },
                    { 5, "Frameworks", "bi bi-diagram-3", "EF Core ORM", 88 },
                    { 6, "Frameworks", "bi bi-bootstrap-reboot", "Bootstrap 5", 95 },
                    { 7, "Databases & Devops", "bi bi-database-fill", "SQL Server", 85 },
                    { 8, "Databases & Devops", "bi bi-box-seam", "Docker Containers", 80 },
                    { 9, "Databases & Devops", "bi bi-cloud-check", "Vercel / Azure", 82 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_Slug",
                table: "Blogs",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Projects_Slug",
                table: "Projects",
                column: "Slug",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Blogs");

            migrationBuilder.DropTable(
                name: "ContactMessages");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Skills");
        }
    }
}
