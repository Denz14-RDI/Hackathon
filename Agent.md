# AI Co-Pilot Orchestrator Framework (Agents.md)

This document maps out the specific execution instructions, roles, and boundaries for AI assistant systems (**Gemini**, **Gemini AI Studio**, and **Nano Banana**) used during the development of this codebase.

## 1. AI Co-Pilot Directory & Core Assignments

### Agent A: Gemini (System Architect & Peer Reviewer)
*   **Role:** Oversees pattern isolation and core code reviews.
*   **Operational Boundary:** Enforces the structural separation between View Interfaces (`IView`) and Data Models. Prevents presentation logic from bleeding into raw ADO.NET processing stacks.

### Agent B: Gemini AI Studio (Rapid Prototyping Engine)
*   **Role:** Generates clean Boilerplate templates, parameterized SQL scripts, and raw structural layouts.
*   **Operational Boundary:** Outputs highly optimized, functional backend code frames. It completely avoids heavy external ORM abstractions to comply with the project's native C# constraint.

### Agent C: Nano Banana (Edge UI / Tailwind Styling Assistant)
*   **Role:** Curates utility classes, front-end scripting, and ensures mobile-first UI responsiveness.
*   **Operational Boundary:** Restricts visual components strictly to pure Tailwind CSS utilities. It completely prevents custom style block contamination inside client views.

## 2. Collaborative Code Assembly Instructions

To maintain code quality across generations, all AI modules must follow this execution sequence:

```text
   [Gemini AI Studio]  ──► Generates raw backend repositories & parameterized SQL
            │
            ▼
     [Nano Banana]     ──► Wraps data into inline Tailwind spreadsheet matrix blocks
            │
            ▼
        [Gemini]       ──► Audits the complete structure to ensure pure MVP compliance
