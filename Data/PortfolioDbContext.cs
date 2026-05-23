using System;
using Microsoft.EntityFrameworkCore;
using DenzelDev.Models;

namespace DenzelDev.Data
{
    public class PortfolioDbContext : DbContext
    {
        public PortfolioDbContext(DbContextOptions<PortfolioDbContext> options) : base(options)
        {
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<ContactMessage> ContactMessages { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Slugs to be Unique for Clean SEO Routing
            modelBuilder.Entity<Project>()
                .HasIndex(p => p.Slug)
                .IsUnique();

            modelBuilder.Entity<Blog>()
                .HasIndex(b => b.Slug)
                .IsUnique();

            // Seed Skill Matrix Data
            modelBuilder.Entity<Skill>().HasData(
                new Skill { Id = 1, Name = "C# / .NET", Category = "Languages", ProficiencyPercent = 92, IconClass = "bi bi-filetype-cs" },
                new Skill { Id = 2, Name = "SQL / T-SQL", Category = "Languages", ProficiencyPercent = 88, IconClass = "bi bi-database" },
                new Skill { Id = 3, Name = "TypeScript / JS", Category = "Languages", ProficiencyPercent = 85, IconClass = "bi bi-filetype-js" },
                new Skill { Id = 4, Name = "ASP.NET Core MVC", Category = "Frameworks", ProficiencyPercent = 90, IconClass = "bi bi-bootstrap" },
                new Skill { Id = 5, Name = "EF Core ORM", Category = "Frameworks", ProficiencyPercent = 88, IconClass = "bi bi-diagram-3" },
                new Skill { Id = 6, Name = "Bootstrap 5", Category = "Frameworks", ProficiencyPercent = 95, IconClass = "bi bi-bootstrap-reboot" },
                new Skill { Id = 7, Name = "SQL Server", Category = "Databases & Devops", ProficiencyPercent = 85, IconClass = "bi bi-database-fill" },
                new Skill { Id = 8, Name = "Docker Containers", Category = "Databases & Devops", ProficiencyPercent = 80, IconClass = "bi bi-box-seam" },
                new Skill { Id = 9, Name = "Vercel / Azure", Category = "Databases & Devops", ProficiencyPercent = 82, IconClass = "bi bi-cloud-check" }
            );

            // Seed Portfolio Project Data
            modelBuilder.Entity<Project>().HasData(
                new Project
                {
                    Id = 1,
                    Title = "EventList Planning System",
                    Slug = "eventlist-planning-system",
                    ShortDescription = "An enterprise-grade, web-based planning platform tailored for student councils, academic organizations, and campus clubs.",
                    FullDescriptionMarkdown = "# EventList Management System\n\nThis application utilizes a stateless, strict **Model-View-Presenter (MVP)** structural design pattern with native ADO.NET and Tailwind CSS.\n\n### Key Features\n- Dynamic budget sheet registers.\n- Timeline coordination sheets.\n- Task allocation matrices.\n- Heavy-weight performance optimization.",
                    ImageUrl = "https://images.unsplash.com/photo-1540575467063-178a50c2df87?q=80&w=600&auto=format&fit=crop",
                    GithubUrl = "https://github.com/Denz14-RDI/Hackathon.git",
                    LiveUrl = "https://eventlist-demo.vercel.app",
                    Category = "Full-Stack",
                    Tags = "C#,MVP,ADO.NET,SQL Server,Tailwind",
                    CreatedAt = new DateTime(2026, 1, 10, 0, 0, 0, DateTimeKind.Utc)
                },
                new Project
                {
                    Id = 2,
                    Title = "Minimalist Developer Portfolio",
                    Slug = "minimalist-developer-portfolio",
                    ShortDescription = "A highly performance-optimized, glassmorphic portfolio styled over Bootstrap 5 and backed by ASP.NET Core MVC and SQL Server.",
                    FullDescriptionMarkdown = "# Premium Portfolio System\n\nDesigned for maximum elegance, using a custom dark mode palette with cyber-mint accents and micro-animations.\n\n### Highlights\n- Custom **glassmorphism** card shaders.\n- Responsive career timeline nodes.\n- Complete CMS back-office CRUD for blogs and projects.\n- SEO-optimized slug matching.",
                    ImageUrl = "https://images.unsplash.com/photo-1460925895917-afdab827c52f?q=80&w=600&auto=format&fit=crop",
                    GithubUrl = "https://github.com/Denz14-RDI/Hackathon.git",
                    LiveUrl = "https://denzeldev-portfolio.vercel.app",
                    Category = "Full-Stack",
                    Tags = "C#,ASP.NET Core,EF Core,SQL Server,Bootstrap 5",
                    CreatedAt = new DateTime(2026, 2, 20, 0, 0, 0, DateTimeKind.Utc)
                }
            );

            // Seed Technical Blogs Data
            modelBuilder.Entity<Blog>().HasData(
                new Blog
                {
                    Id = 1,
                    Title = "Architecting ASP.NET Core for Serverless Deployment on Vercel",
                    Slug = "architecting-aspnet-core-serverless-vercel",
                    ContentMarkdown = "# Mastering Serverless .NET\n\nWhile Vercel is highly optimized for frontend frameworks and serverless Node.js, we can host complete ASP.NET Core architectures using serverless wrapper runtimes like `vercel-dotnet` or serverless functions proxy gateways.\n\n### In this article we cover:\n1. Setting up your `vercel.json` configurations.\n2. Overcoming cold startup times.\n3. Managing connection pool lifetimes inside stateless serverless blocks.\n4. Configuring environment variable secrets safely.",
                    BannerImageUrl = "https://images.unsplash.com/photo-1607799279861-4dd421887fb3?q=80&w=800&auto=format&fit=crop",
                    PublishedDate = new DateTime(2026, 4, 15, 0, 0, 0, DateTimeKind.Utc),
                    ReadTimeMinutes = 6,
                    IsPublished = true,
                    CreatedAt = new DateTime(2026, 4, 15, 0, 0, 0, DateTimeKind.Utc)
                },
                new Blog
                {
                    Id = 2,
                    Title = "Designing Frost-Glass Shaders with Raw Tailwind and Bootstrap 5",
                    Slug = "designing-frost-glass-shaders-tailwind-bootstrap",
                    ContentMarkdown = "# Styling Premium Web Shaders\n\nGlassmorphism creates unmatched depth on modern dark-mode interfaces. By leveraging modern backdrop filter effects in combination with thin translucent borders, we can make our cards feel floating and premium.\n\n```css\n.glass-card {\n  background: rgba(18, 24, 36, 0.6);\n  backdrop-filter: blur(12px);\n  border: 1px solid rgba(255, 255, 255, 0.08);\n}\n```\n\nThis article outlines exact steps to layer glassmorphic effects on top of standard Bootstrap columns without breaking flexbox flows.",
                    BannerImageUrl = "https://images.unsplash.com/photo-1550751827-4bd374c3f58b?q=80&w=800&auto=format&fit=crop",
                    PublishedDate = new DateTime(2026, 5, 2, 0, 0, 0, DateTimeKind.Utc),
                    ReadTimeMinutes = 4,
                    IsPublished = true,
                    CreatedAt = new DateTime(2026, 5, 2, 0, 0, 0, DateTimeKind.Utc)
                }
            );

            // Configure Relationships and Cascade Deletes for Event management tables
            modelBuilder.Entity<Budget>()
                .HasOne(b => b.Event)
                .WithMany(e => e.Budgets)
                .HasForeignKey(b => b.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TaskItem>()
                .HasOne(t => t.Event)
                .WithMany(e => e.TaskItems)
                .HasForeignKey(t => t.EventId)
                .OnDelete(DeleteBehavior.Cascade);

            // Seed Mock Event data
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    Title = "National Developer Hackathon 2026",
                    Description = "A premier 48-hour programming league challenge designed to assemble software engineering student teams to build dynamic C# applications.",
                    EventDate = new DateTime(2026, 6, 20, 0, 0, 0, DateTimeKind.Utc),
                    Location = "Manila Tech Dome Complex",
                    OrganizerName = "Student Alliance Executive Council"
                }
            );

            // Seed Budgets for Event
            modelBuilder.Entity<Budget>().HasData(
                new Budget { Id = 1, EventId = 1, ItemName = "Corporate Sponsorships", Type = "Sponsorship", Amount = 5000.00m },
                new Budget { Id = 2, EventId = 1, ItemName = "Cloud Servers Provisioning", Type = "Expense", Amount = 600.00m },
                new Budget { Id = 3, EventId = 1, ItemName = "Physical Promos & Catering", Type = "Expense", Amount = 1800.00m }
            );

            // Seed Tasks for Event
            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem { Id = 1, EventId = 1, TaskName = "Provision deployment proxy bridges", AssignedTo = "Denzel Dev", Status = "Completed", DueDate = new DateTime(2026, 6, 1, 0, 0, 0, DateTimeKind.Utc) },
                new TaskItem { Id = 2, EventId = 1, TaskName = "Coordinate judges panel", AssignedTo = "Pres. Alex", Status = "In Progress", DueDate = new DateTime(2026, 6, 12, 0, 0, 0, DateTimeKind.Utc) },
                new TaskItem { Id = 3, EventId = 1, TaskName = "Distribute promotional details", AssignedTo = "Graphics Team", Status = "Pending", DueDate = new DateTime(2026, 6, 15, 0, 0, 0, DateTimeKind.Utc) }
            );
        }
    }
}
