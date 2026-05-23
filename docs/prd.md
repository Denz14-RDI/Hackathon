# Product Requirements Document (PRD) — Minimalist Full-Stack Developer Portfolio & Blog

## 1. Product Overview
The **Minimalist Full-Stack Developer Portfolio & Blog** is a premium, professional web-based platform designed to highlight professional identity, career milestones, technical expertise, leadership activities, and write-ups (blogs). The application is built using the **MVC ASP.NET Core Web App** framework with **SQL Server** as the persistent relational database, styled using **Bootstrap** with custom minimalist styling, and prepared for serverless deployment on **Vercel**.

### Key Vision
To deliver a high-performance, responsive, and visually stunning digital home that acts as an active resume, project showroom, and blogging medium, supported by a secure, lightweight CMS admin panel for dynamic updates.

---

## 2. Core Functional Requirements (FR)

### FR-1: Hero Section (Minimalistic Entry)
*   **System Action:** Display a high-impact, clean introduction when landing on the root route (`/`).
*   **Aesthetics:** High typographic hierarchy, clean whitespace, subtle typing text or fade-in animation, and dual call-to-actions ("View Projects" linking to the projects route, and "Contact Me" smooth-scrolling to the contact footer).

### FR-2: About & Professional Background (Timeline)
*   **System Action:** Show a narrative of professional experience, career milestones, and educational background.
*   **UI Component:** A sleek, vertical or horizontal interactive timeline featuring dates, company/institution logos (or icons), job titles, and brief bullet achievements.

### FR-3: Technical Skills Matrix
*   **System Action:** Categorize and display technical proficiencies dynamically.
*   **Parameters:** Categorized by domain (e.g., Languages, Frameworks, Cloud & Databases, Devops/Tools). Use clean, badge-like structures or minimal progressive percentage bars that animate on scroll.

### FR-4: Dedicated Projects Route (`/projects`)
*   **System Action:** A separate, dedicated route/tab displaying all projects, loaded dynamically from SQL Server.
*   **Filter Matrix:** Client-side and server-side filtering by category (e.g., Full-Stack, Mobile, AI/ML).
*   **Project Detail View (`/projects/{slug}`):** A clean modal or sub-page showing:
    *   Dynamic gallery or featured image.
    *   Project description with markdown support.
    *   Tags (tech stack list).
    *   Live link and GitHub repository link.

### FR-5: Dedicated Blogs Route (`/blogs`)
*   **System Action:** A separate, dedicated route/tab showcasing dynamic technical blogs/articles.
*   **Blog Listing:** Articles displayed in a minimalistic grid or list format with title, publication date, reading time estimation, category, and an excerpt.
*   **Blog Detail View (`/blogs/{slug}`):** Read-only article layout optimized for high typography readability (large readable fonts, markdown support, code syntax highlighting).

### FR-6: Leadership & Community Section
*   **System Action:** Showcase student leadership, community mentoring, event organization, or speaking engagements.
*   **UI Component:** A highly visual section with card structures or a clean slider exhibiting event title, role, dates, achievements, and impact metrics.

### FR-7: Contact Form & CTA
*   **System Action:** Allow visitors to directly send messages.
*   **Form Parameters:** Fields for Name, Email, Subject, and Message, with strict frontend and backend model validation.
*   **Database Log:** Store messages in a `ContactMessages` SQL Server database table.
*   **Admin Visibility:** Display inquiries in the secure Admin CMS Panel.

### FR-8: Admin CMS Dashboard (Back-Office)
*   **System Action:** A secure, password-protected admin control panel (`/admin`) for dynamic management of data without manual SQL queries.
*   **Admin CRUD Operations:**
    *   **Manage Projects:** Add, Edit, Delete projects (fields: Title, Slug, ShortDescription, DetailedMarkdownContent, BannerImageURL, RepoURL, LiveURL, Category, TechStackTags).
    *   **Manage Blogs:** Add, Edit, Delete articles (fields: Title, Slug, ContentHtml/Markdown, Author, BannerImageURL, PublishedDate, ReadTimeMinutes, Status: Draft/Published).
    *   **View Inquiries:** Read and mark contact inquiries as resolved.
*   **Security:** Simple, secure session-based authentication using an environment variable admin password, or ASP.NET Core cookie authentication to keep dependencies minimal.

---

## 3. Non-Functional Requirements (NFR)

### NFR-1: Visual Aesthetic & Performance
*   **Theme:** Modern, sleek, minimalistic dark-theme-first palette. Uses deep grays, blacks, glassmorphic elements (`backdrop-filter`), sharp sans-serif typography (e.g., *Inter* or *Outfit*), and micro-animations.
*   **Responsiveness:** Perfect scaling from 320px (mobile) to ultra-wide desktop viewports using Bootstrap’s flexbox-based grid, layered with custom CSS.
*   **Performance:** Fast loading speeds (PageSpeed Score > 90/100) via server-side rendering (SSR) of ASP.NET Core, optimized asset loading, and minimal runtime dependencies.

### NFR-2: Search Engine Optimization (SEO) & Testing
*   **SEO Integration:** 
    *   Dynamic meta titles and tags tailored per route and blog post.
    *   Search-engine-friendly URLs (slugs instead of ID parameters, e.g., `/projects/my-awesome-portfolio` instead of `/projects/details?id=5`).
    *   Valid semantic HTML5 elements (`<header>`, `<main>`, `<section>`, `<footer>`, `<article>`).
*   **Semantic Unique IDs:** Unique, descriptive `id` attributes on all forms, filters, and CTA buttons to facilitate reliable E2E browser and unit testing.

### NFR-3: Secure Data & Deployment
*   **Data Integrity:** Prevent SQL Injection using Entity Framework Core parameterized commands or standard ORM behaviors. Use anti-forgery tokens (`[ValidateAntiForgeryToken]`) on all POST operations.
*   **Hosting Compatibility:** Configure codebase to run efficiently in a serverless environment (such as Vercel serverless functions with a custom .NET hosting wrapper, or Render/Azure as robust alternatives) using connection string configurations stored safely in environment variables.
