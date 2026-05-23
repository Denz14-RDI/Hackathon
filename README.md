# 📅 Event Management System (EventList)

An enterprise-grade, web-based planning platform tailored for **student councils, academic organizations, and campus clubs**. Built with the strict **Passive View Model-View-Presenter (MVP)** architectural pattern, this lightweight system maximizes **data consistency** and **UI responsiveness** without relying on bloated dependency tracking or heavy ORM systems.

---

## 🗺️ 1. Project Overview

### 🎯 Purpose
Campus event planning often involves fragmented spreadsheets, scattered chat threads, and manual tracking. The **Event Management System (EventList)** consolidates these workflows into a single intuitive platform, reducing administrative burden and providing **real-time visibility** across project teams.

### 👥 Target Users
- **Organization Executives & Presidents** → Monitor overall event progress and budget health.  
- **Event Committee Heads & Project Managers** → Schedule timelines, manage finances, and delegate tasks.  
- **Committee Members & Support Staff** → Update task statuses and log localized expenses.  

### 📌 Scope
**In-Scope Features:**
- Interactive **Event Timeline**, Calendar View, and Global Dashboard.  
- Dynamic **Budget Sheets** with auto-calculating ledgers (Income, Sponsorships, Expenses).  
- Task Assignment Matrix with instant progress bars.  

**Out-of-Scope Features:**
- Ticketing gateways or external merchant payment processing.  
- Real-time in-app chat (external tools like Discord/Messenger preferred).  
- Automated SMS/Email broadcast alerts.  

---

## 🏗️ 2. System Architecture

The system follows the **MVP (Model-View-Presenter)** pattern, ensuring clean separation of concerns, extensibility, and testability.

### 🔹 Component Responsibilities
- **Model** → Encapsulates data access, entities, and SQL Server communication. Independent of UI.  
- **View** → Client-facing interface (HTML + Tailwind CSS + JS). Forwards user actions to Presenter.  
- **Presenter** → Core logic handler. Processes user requests, updates Models, and refreshes Views.  

---

## 📂 3. Codebase Structure

```text
EventManagementSystem/
│
├── Database/
│   └── Schema.sql                 # DDL scripts and constraints
│
├── Models/                        # Domain Entities & Repositories
│   ├── Event.cs                   # Event metadata lifecycle
│   ├── Budget.cs                  # Sponsorships & Expenses tracking
│   ├── TaskItem.cs                # Workflow updates & deadlines
│   └── DataContext.cs             # Connection lifecycle manager
│
├── Views/                         # UI Contracts (decoupled from framework)
│   ├── IEventView.cs
│   ├── IBudgetView.cs
│   └── ITaskView.cs
│
├── Presenters/                    # Business logic controllers
│   ├── EventPresenter.cs
│   ├── BudgetPresenter.cs
│   └── TaskPresenter.cs
│
└── WebRoot/                       # Client Delivery Files
    ├── index.html                 # Responsive Tailwind interface
    └── js/
        ├── api.js                 # Service communication layer
        └── app.js                 # UI event handling & DOM binding


