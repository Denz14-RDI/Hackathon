# Product Requirement Document (PRD) — Event Management System

## 1. Product Overview
The Event Management System (**EventList**) is a web-based management application designed to streamline event lifecycle planning, financial micro-tracking, and team delegation matrices for student-led school organizations (e.g., student councils, academic clubs, and interest groups).

## 2. Target Audience & Users
*   **Primary Users:** Student Organization Officers, Committee Chairs, and Project Leads.
*   **Secondary Users:** Organization Members/Assignees and Faculty Advisors (for review/auditing).

## 3. Core Functional Requirements

### FR-1: Event Creation & Scheduling
*   **System Action:** Allow authenticated organization officers to create events by defining a Title, Target Date/Time, Venue Location, and Organizer Unit.
*   **Dashboard Execution:** 
    *   **Creation View:** Input workspace containing validation barriers preventing past-date scheduling.
    *   **Upcoming Board:** Separate, read-only timeline view displaying upcoming events ordered chronologically.

### FR-2: Financial Matrix Ledger (Budget Tracking)
*   **System Action:** Provide a lightweight, sheet-style inline data matrix to track cash flows.
*   **Parameters:** Every line item must declare a clear Name, Type allocation (`Sponsorship` vs. `Expense`), and precise decimal Amount.
*   **Calculation Engine:** The UI must display a live calculated net total balance (`Sponsorships - Expenses`) directly on the tracking wrapper.

### FR-3: Operational Milestones & Task Tracking
*   **System Action:** Provide a sheet-style task assignment layout allowing project leads to split events into granular tasks.
*   **Parameters:** Tasks require a unique Task Description, an Owner Assignee name, a Target Due Date, and a Status Allocation (`Pending`, `In Progress`, `Completed`).

## 4. Non-Functional Requirements (NFRs)
*   **NFR-1 (Architecture):** Must adhere to a strict **Passive View Model-View-Presenter (MVP)** decoupling rule.
*   **NFR-2 (Performance):** Data access layers must communicate using lightweight, native ADO.NET SQL commands to prevent heavy ORM overhead.
*   **NFR-3 (UI/UX):** Layouts must be entirely responsive and styled using Tailwind CSS utility components, scaling down to mobile viewports for on-the-go student use.
