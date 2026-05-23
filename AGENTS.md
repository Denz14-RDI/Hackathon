# Agent Orchestrator Framework & Prioritized Project Backlog (`AGENTS.md`)

This document serves as the **Lead AI Orchestration Spec** and **Project Execution Roadmap** for the Minimalist Full-Stack Portfolio. It details the specialized AI subagent personas, explains collaboration protocols, and outlines an **AI-driven, dependency-based Task Prioritization Matrix** to guide the step-by-step assembly of the platform.

---

## 1. Agent Architecture & Specialized Personas

To build this full-stack portfolio efficiently, the Lead Orchestrator delegates tasks to specialized agent roles, each with clear boundaries:

```text
                        ┌──────────────────────────┐
                        │    Lead Orchestrator     │
                        │   (Antigravity Agent)    │
                        └────────────┬─────────────┘
                                     │
         ┌───────────────────────────┼───────────────────────────┐
         ▼                           ▼                           ▼
┌──────────────────┐        ┌──────────────────┐        ┌──────────────────┐
│Database Architect│        │Backend MVC Engine│        │ Frontend Stylist │
│ SQL Server / EF  │        │   C# Controllers │        │Bootstrap / CSS   │
└──────────────────┘        └──────────────────┘        └──────────────────┘
         │                           │                           │
         └───────────────────────────┼───────────────────────────┘
                                     ▼
                        ┌──────────────────────────┐
                        │   Deployment & QA Lead   │
                        │ Vercel Config / E2E test │
                        └──────────────────────────┘
```

### 1.1 Persona Directory
1.  **Lead Orchestrator (Antigravity Agent)**:
    *   *Responsibility*: Manages user alignment, schedules tasks, enforces file structure, coordinates handoffs between subagents, and monitors overall progress.
2.  **Database Architect Agent**:
    *   *Responsibility*: Formulates EF Core entity models, manages SQL Server database connection configurations, writes migrations, and defines development database seeds.
3.  **Backend MVC Engine Agent**:
    *   *Responsibility*: Writes clean C# controllers, constructs data repository abstractions, handles dynamic route logic, and compiles utility services (e.g., Markdown-to-HTML parsing).
4.  **Frontend Stylist Agent**:
    *   *Responsibility*: Manages typography, Bootstrap integration, responsive layout files, CSS custom tokens, glassmorphism cards, timelines, and subtle micro-interactions.
5.  **Deployment & QA Lead Agent**:
    *   *Responsibility*: Configures `vercel.json` serverless endpoints, validates Docker scripts, executes E2E element accessibility, verifies semantic HTML tags, and tests validation rules.

---

## 2. AI Task Prioritization Matrix (Roadmap)

To construct a full-stack MVC application, **database and core models must be established first** to prevent rewriting data layers later. The following task backlog is ordered dynamically by **technical dependency prioritization**:

### Phase 1: Core Foundation & Data Persistent Layer (MUST-HAVE / High Priority)
> [!IMPORTANT]
> The database and data repositories must be finalized first. All backend logic and frontend displays directly rely on this layer.

| Code | Task Title | Primary Assigned Agent | Technical Dependency |
| :--- | :--- | :--- | :--- |
| **T-1.1** | **Entity Models Setup** | Database Architect | None |
| **T-1.2** | **EF Core & DbContext Setup** | Database Architect | T-1.1 |
| **T-1.3** | **SQL Server Migrations & Seed** | Database Architect | T-1.2 |
| **T-1.4** | **Repository Abstractions** | Backend MVC Engine | T-1.3 |

#### Phase 1 Action Checklist
*   [ ] **T-1.1**: Define models `Project.cs`, `Blog.cs`, `Skill.cs`, `ContactMessage.cs` with validation annotations.
*   [ ] **T-1.2**: Register `ApplicationDbContext` in `Program.cs`. Ensure connection strings pull safely from env variables.
*   [ ] **T-1.3**: Run `dotnet ef migrations add InitialCreate` and setup dynamic data seeding for core skills and initial placeholder projects/blogs.
*   [ ] **T-1.4**: Define repository interfaces (`IPortfolioRepository`) to encapsulate database calls for modularity.

---

### Phase 2: MVC Engine, Routing & Admin Dashboard (SHOULD-HAVE / Medium Priority)
> [!NOTE]
> Setting up dynamic controllers and administrative controls secures functional operations before laying down the rich UI styles.

| Code | Task Title | Primary Assigned Agent | Technical Dependency |
| :--- | :--- | :--- | :--- |
| **T-2.1** | **Dynamic Route Mapping** | Backend MVC Engine | T-1.4 |
| **T-2.2** | **Markdown Render Services** | Backend MVC Engine | None |
| **T-2.3** | **Contact CTA Form Capture** | Backend MVC Engine | T-1.3 |
| **T-2.4** | **Admin Authentication & CRUD** | Backend MVC Engine | T-1.4 |

#### Phase 2 Action Checklist
*   [ ] **T-2.1**: Implement `ProjectsController` and `BlogsController` serving semantic sluggified routes (e.g., `/projects/{slug}`).
*   [ ] **T-2.2**: Integrate `Markdig` library to convert markdown entries into safe HTML for display pages.
*   [ ] **T-2.3**: Set up standard `POST /contact` endpoint with verification token filtering (`[ValidateAntiForgeryToken]`) storing user submissions.
*   [ ] **T-2.4**: Create a protected `/admin` dashboard containing CRUD actions (Create, Read, Update, Delete) with secure password verification.

---

### Phase 3: Visual Polish, SEO & Vercel Deployment (COULD-HAVE / Polish Priority)
> [!TIP]
> With the logic and storage fully functional, the styling layer can be wrapped around the system to deliver the final premium look.

| Code | Task Title | Primary Assigned Agent | Technical Dependency |
| :--- | :--- | :--- | :--- |
| **T-3.1** | **Bootstrap & Custom Glassmorphic Styles** | Frontend Stylist | None |
| **T-3.2** | **Home, Timelines & Grid Layouts** | Frontend Stylist | T-2.1 |
| **T-3.3** | **SEO Optimization & semantic IDs** | Frontend Stylist | T-3.2 |
| **T-3.4** | **Vercel Serverless Hosting Config** | Deployment Lead | T-2.1 |

#### Phase 3 Action Checklist
*   [ ] **T-3.1**: Build `wwwroot/css/site.css` containing custom dark HSL variables, `.glass-card` classes, and keyframe hover transitions.
*   [ ] **T-3.2**: Refactor standard Razor pages (`Index.cshtml`, `_Layout.cshtml`) implementing responsive grids, timeline items, and skills tags.
*   [ ] **T-3.3**: Ensure correct headings structure (single `<h1>` per page), custom meta descriptions, and unique `id` attributes on all form variables for automated tests.
*   [ ] **T-3.4**: Configure `vercel.json` for compilation via `.NET` runtime integration, or prepare fallback settings for a containerized deployment on Render/Azure.

---

## 3. Communication & Handoff Protocols
To maintain strict project files cleanliness, agents must adhere to the following rules during execution:
1.  **Read-Before-Write**: Always read existing interfaces or models using `view_file` to ensure database context uniformity.
2.  **No Placeholders**: Never write functions with empty `throw new NotImplementedException()`. Provide robust default behavior.
3.  **Local Dev Running**: Execute `dotnet run` after major milestones to verify compiling succeeds before proposing deployments.
