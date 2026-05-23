# System Design Document (SDD) — Event Management System

## 1. Structural Architecture (Passive View MVP)
The application utilizes a stateless, strict **Model-View-Presenter (MVP)** structural design pattern. 

```text
       ┌───────────────┐              ┌───────────────────┐
       │     View      │ ◄──────────  │     Presenter     │
       │ (IEventView)  │  Bind Data   │  (EventPresenter) │
       └───────┬───────┘              └─────────┬─────────┘
               │                                │
               │ User Action                    │ Read / Write
               ▼                                ▼
     ┌───────────────────┐            ┌───────────────────┐
     │    HTTP Router    ├──────────► │       Model       │
     │  (API Web Hand.)  │  Triggers  │    (Event.cs)     │
     └───────────────────┘            └───────────────────┘
