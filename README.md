# Event Management System (ClubEvent Pro)

An enterprise-grade, web-based planning platform tailored for student councils, academic organizations, and campus clubs. Built utilizing the strict Passive View **Model-View-Presenter (MVP)** architectural pattern, this lightweight system maximizes data consistency and UI responsiveness without relying on bloated dependency tracking or heavy ORM systems.

---

## 🗺️ Architectural Topology & Pattern Structure

The codebase is organized entirely around clean separation of concerns, ensuring high readability, low database overhead, and easily isolated business components.

```text
EventManagementSystem/
│
├── Database/
│   └── Schema.sql                 # Data Definition Language (DDL) and constraints
│
├── Models/                        # Core Domain Entities & ADO.NET Repositories
│   ├── Event.cs                   # Handles baseline event metadata lifecycle
│   ├── Budget.cs                  # Sheet-style accounting (Sponsorships/Expenses)
│   ├── TaskItem.cs                # Handles workflow updates and deadlines
│   └── DataContext.cs             # Native Connection lifecycle manager
│
├── Views/                         # UI Contracts (Decouples presenter from UI framework)
│   ├── IEventView.cs
│   ├── IBudgetView.cs
│   └── ITaskView.cs
│
├── Presenters/                    # Command & Data routing pipeline controllers
│   ├── EventPresenter.cs
│   ├── BudgetPresenter.cs
│   └── TaskPresenter.cs
│
└── WebRoot/                       # Client Delivery Files (SPA/Dynamic Dashboard)
    ├── index.html                 # Core Responsive Interface (Tailwind CSS)
    └── js/
        ├── api.js                 # Low-level service communication layer
        └── app.js                 # UI event handling & DOM binding engine
