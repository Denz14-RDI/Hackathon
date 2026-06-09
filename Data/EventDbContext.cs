using System;
using Microsoft.EntityFrameworkCore;
using DenzelDev.Models;

namespace DenzelDev.Data
{
    public class EventDbContext : DbContext
    {
        public EventDbContext(DbContextOptions<EventDbContext> options) : base(options)
        {
        }

        public DbSet<Event> Events { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<TaskItem> TaskItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Relationships and Cascade Deletes
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

            // Seed Mock Event 1
            modelBuilder.Entity<Event>().HasData(
                new Event
                {
                    Id = 1,
                    Title = "National Developer Hackathon 2026",
                    Description = "A premier 48-hour programming league challenge designed to assemble software engineering student teams to build dynamic C# applications.",
                    EventDate = new DateTime(2026, 6, 20, 0, 0, 0, DateTimeKind.Utc),
                    Location = "Manila Tech Dome Complex",
                    OrganizerName = "Student Alliance Executive Council"
                },
                // Seed Mock Event 2
                new Event
                {
                    Id = 2,
                    Title = "AI & Robotics Tech Summit",
                    Description = "Annual convention showcasing student robotics research, machine learning modules, and expert-led neural network workshops.",
                    EventDate = new DateTime(2026, 7, 15, 0, 0, 0, DateTimeKind.Utc),
                    Location = "Quezon Science Hall",
                    OrganizerName = "Robotics & AI Student Chapter"
                },
                // Seed Mock Event 3
                new Event
                {
                    Id = 3,
                    Title = "Student Council Leadership Seminar",
                    Description = "Leadership training conference focused on budget allocations, project delegation, and campus organization lifecycle management.",
                    EventDate = new DateTime(2026, 8, 5, 0, 0, 0, DateTimeKind.Utc),
                    Location = "Campus Audio Visual Room",
                    OrganizerName = "Office of Student Affairs"
                }
            );

            // Seed Budgets for Event 1
            modelBuilder.Entity<Budget>().HasData(
                new Budget { Id = 1, EventId = 1, ItemName = "Corporate Sponsorships", Type = "Sponsorship", Amount = 5000.00m },
                new Budget { Id = 2, EventId = 1, ItemName = "Cloud Servers Provisioning", Type = "Expense", Amount = 600.00m },
                new Budget { Id = 3, EventId = 1, ItemName = "Physical Promos & Catering", Type = "Expense", Amount = 1800.00m },
                
                // Seed Budgets for Event 2
                new Budget { Id = 4, EventId = 2, ItemName = "University Grant Funding", Type = "Sponsorship", Amount = 3500.00m },
                new Budget { Id = 5, EventId = 2, ItemName = "Sensor Kits and Arduino Boards", Type = "Expense", Amount = 1200.00m },
                new Budget { Id = 6, EventId = 2, ItemName = "Keynote Speaker Honorarium", Type = "Expense", Amount = 800.00m },

                // Seed Budgets for Event 3
                new Budget { Id = 7, EventId = 3, ItemName = "SAEC Budget Allocation", Type = "Sponsorship", Amount = 1500.00m },
                new Budget { Id = 8, EventId = 3, ItemName = "Seminar Notebooks & Badges", Type = "Expense", Amount = 350.00m }
            );

            // Seed Tasks for Event 1
            modelBuilder.Entity<TaskItem>().HasData(
                new TaskItem { Id = 1, EventId = 1, TaskName = "Provision deployment proxy bridges", AssignedTo = "Denzel Dev", Status = "Completed", DueDate = new DateTime(2026, 6, 1, 0, 0, 0, DateTimeKind.Utc) },
                new TaskItem { Id = 2, EventId = 1, TaskName = "Coordinate judges panel", AssignedTo = "Pres. Alex", Status = "In Progress", DueDate = new DateTime(2026, 6, 12, 0, 0, 0, DateTimeKind.Utc) },
                new TaskItem { Id = 3, EventId = 1, TaskName = "Distribute promotional details", AssignedTo = "Graphics Team", Status = "Pending", DueDate = new DateTime(2026, 6, 15, 0, 0, 0, DateTimeKind.Utc) },

                // Seed Tasks for Event 2
                new TaskItem { Id = 4, EventId = 2, TaskName = "Purchase sensor microchips", AssignedTo = "Engr. Clara", Status = "Completed", DueDate = new DateTime(2026, 7, 2, 0, 0, 0, DateTimeKind.Utc) },
                new TaskItem { Id = 5, EventId = 2, TaskName = "Finalize keynote presentation", AssignedTo = "Dr. Santos", Status = "Pending", DueDate = new DateTime(2026, 7, 10, 0, 0, 0, DateTimeKind.Utc) },

                // Seed Tasks for Event 3
                new TaskItem { Id = 6, EventId = 3, TaskName = "Print leadership certificates", AssignedTo = "Sec. Mark", Status = "In Progress", DueDate = new DateTime(2026, 8, 1, 0, 0, 0, DateTimeKind.Utc) }
            );
        }
    }
}
