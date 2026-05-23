# Event Management System (EventList)

An enterprise-grade, web-based planning platform tailored for student councils, academic organizations, and campus clubs. Built utilizing the strict Passive View **Model-View-Presenter (MVP)** architectural pattern, this lightweight system maximizes data consistency and UI responsiveness without relying on bloated dependency tracking or heavy ORM systems.

---

## 🗺️ Architectural Topology & Pattern Structure

The codebase is organized entirely around clean separation of concerns, ensuring high readability, low database overhead, and easily isolated business components.

# Event Management System (EMS)

A streamlined web application designed to simplify event planning, budgeting, and coordination for student organizations, clubs, and councils. Built using the **Model-View-Presenter (MVP)** architecture, this application unifies scattered spreadsheets, task tracking, and financial ledgers into a single, cohesive dashboard.

---

## 1. Project Overview

### Purpose
Planning campus events often involves disconnected chat threads, manual tracking, and fragmented data. The **Event Management System (EMS)** consolidates these essential workflows into an intuitive platform, reducing administrative burden and providing real-time visibility across student project teams.

### Target Users
* **Organization Executives & Presidents:** Track high-level event progress and global budget health across multiple organizational initiatives.
* **Event Committee Heads & Project Managers:** Schedule specific timelines, handle financial itemizations, and delegate task matrices.
* **Committee Members & Support Staff:** Update real-time task completion statuses and log localized expense details.

### Scope
* **In-Scope:**
    * Interactive Event Timeline, Calendar View, & Global Project Dashboard.
    * Dynamic Budget Sheets with auto-calculating ledgers (Incomes, Sponsorships, Expenses).
    * Task Assignment Matrix accompanied by instant progress completion bars.
* **Out-of-Scope:**
    * Ticketing gateways, external merchant payment processing, or public registration portals.
    * Real-time in-app chat systems (external communication channels like Discord or Messenger remain preferred).
    * Automated cellular SMS/Email alert broadcast networks.

---

## 2. System Architecture

The application is built on the **Model-View-Presenter (MVP)** architectural pattern, separating data management from visual display rules to facilitate clean extensibility, effortless debugging, and isolated unit testing.

### Component Responsibilities
* **Model:** Encapsulates the data access layers, entities, and database communication engines (via SQL Server). Operates completely independently of UI specifications.
* **View:** The client-facing interface rendered via interactive HTML templates styled using Tailwind CSS and lightweight JavaScript. Forwards all user interactions to the Presenter without performing processing logic.
* **Presenter:** Acts as the functional operational brain. Intercepts incoming user requests from the View, updates or fetches information from the Model, and modifies UI displays according to programmatic business operations.

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
