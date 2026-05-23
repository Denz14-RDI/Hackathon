# UI/UX Design Specification — Minimalist Developer Portfolio

## 1. Visual Vibe & Aesthetic Concept
The UI follows a **premium, dark-mode first, minimalistic grid system** with **glassmorphism** visual highlights. The design avoids generic web layouts, adopting a spacious, high-contrast typography style that feels like an interactive premium developer terminal or high-end design journal.

### Design Principles
*   **Whitespace is Luxury**: Ample padding (`py-5`, `my-5`) and empty areas to let components breathe and command visual focus.
*   **Frosted Glass Elements**: Glassmorphic panels overlaying dark backgrounds to create high depth and modern structure.
*   **Micro-Accents**: Restrained color highlights. Only critical tags, active indicators, and hover details receive vibrant accent coloring, drawing the eye directly.
*   **Seamless Responsiveness**: Responsive container scaling layered seamlessly over Bootstrap 5's flex grid.

---

## 2. Design Tokens (Colors & Typography)

### 2.1 The Curated Color Palette
To create a premium look, we define HSL-based colors mapped into custom CSS properties:

```css
:root {
  /* Core Base Colors */
  --color-bg-base: hsl(222, 40%, 6%);       /* #0B0F19 - Deep Midnight Void */
  --color-bg-surface: hsl(220, 30%, 10%);   /* #121824 - Slate Card Surface */
  --color-bg-elevated: hsl(218, 25%, 15%);  /* #1C2333 - Elevated Glass Panel */

  /* Text Colors */
  --color-text-primary: hsl(210, 38%, 95%); /* #EBF1F5 - Crisp Off-White */
  --color-text-muted: hsl(215, 15%, 65%);   /* #97A2B0 - Silver Gray Muted */
  --color-text-dark: hsl(217, 10%, 40%);    /* #5B6675 - Dark Steel Gray */

  /* Accent Glow */
  --color-accent: hsl(163, 100%, 70%);      /* #64FFDA - Electric Cyber Mint */
  --color-accent-glow: rgba(100, 255, 218, 0.15);
  
  /* Borders and Dividers */
  --border-glass: rgba(255, 255, 255, 0.08);
  --border-glass-hover: rgba(255, 255, 255, 0.16);
}
```

### 2.2 Modern Typography Spec
*   **Primary Fonts**: **Inter** (sans-serif) or **Outfit** (display geometric sans-serif) loaded via Google Fonts.
*   **Headings Layout**: Heavy weights (`font-weight: 800`), tight tracking (`letter-spacing: -0.05em`).
*   **Body Content**: Clean, readable sans-serif layout (`line-height: 1.7`, `font-size: 1rem`) in Muted Silver-Gray.

---

## 3. UI Component Custom Styles (CSS)

Below are the primary custom class specs to be declared in `wwwroot/css/site.css` overriding standard Bootstrap layouts:

### 3.1 Glassmorphic Cards (`.glass-card`)
A signature card style applied to Skills, Experience timeline cards, and Project list blocks.
```css
.glass-card {
  background: rgba(18, 24, 36, 0.65);
  backdrop-filter: blur(12px);
  -webkit-backdrop-filter: blur(12px);
  border: 1px solid var(--border-glass);
  border-radius: 16px;
  padding: 2rem;
  transition: all 0.4s cubic-bezier(0.16, 1, 0.3, 1);
  box-shadow: 0 10px 30px -15px rgba(2, 12, 27, 0.7);
}

.glass-card:hover {
  transform: translateY(-6px);
  border-color: var(--border-glass-hover);
  box-shadow: 0 20px 40px -20px rgba(100, 255, 218, 0.1);
}
```

### 3.2 Premium Cyber Buttons (`.btn-premium`)
A clean, flat button with an animated neon accent border.
```css
.btn-premium {
  background: transparent;
  color: var(--color-accent);
  border: 1px solid var(--color-accent);
  padding: 0.8rem 1.8rem;
  font-family: 'Outfit', sans-serif;
  font-weight: 600;
  border-radius: 8px;
  letter-spacing: 0.05em;
  transition: all 0.3s ease;
  position: relative;
  overflow: hidden;
}

.btn-premium:hover {
  background: var(--color-accent-glow);
  box-shadow: 0 0 15px var(--color-accent-glow);
  color: var(--color-text-primary);
  transform: translateY(-2px);
}
```

---

## 4. UI Section Structuring & Wireframes

### 4.1 Hero Section
*   **Layout**: Minimalist full height (`min-vh-100 d-flex align-items-center`).
*   **Elements**:
    1.  Muted welcome tag: `[hello, world. i am]` (styled with `--color-accent` and monospace).
    2.  Large Headline: Dynamic name + short role statement (e.g., "Denzel Dev. Crafting premium full-stack architectures.").
    3.  A sub-paragraph describing core philosophy in 2 lines.
    4.  Action CTA: Dual buttons aligned side-by-side with wide gaps.

### 4.2 Professional Experience (Timeline Component)
*   **Layout**: A single centered vertical line (`border-left: 2px solid var(--border-glass)`).
*   **Interactive Node Points**: Custom-styled list items containing glass cards that appear on alternate sides or left-aligned on mobile devices.
*   **Hover Behavior**: Hovering a timeline card lights up its connecting node indicator with `--color-accent` glow.

### 4.3 Technical Skills (Minimalist Tags)
*   **Layout**: Instead of bulky grid rows, skills are mapped into clean glass badges with minimal iconography (using Devicon or Bootstrap Icons).
*   **Micro-interaction**: Soft gradient transitions when hovering individual badges.

### 4.4 Dedicated Projects Route (`/projects`)
*   **Tab Layout**: Category filters arranged as a clean segmented control tab at the top.
*   **Card Grid**: Dynamic 2-column grid of projects.
*   **Metadata Row**: A sleek footer on each project card displaying tech stack badges and active github links.

### 4.5 Blogs Route (`/blogs`)
*   **Layout**: Focus on high-quality text grid.
*   **Aesthetic**: No heavy image cards; clean typographic lists featuring publication date (`Jan 14, 2026`), article title, and dynamic reading duration markers (`5 min read`).

### 4.6 Contact Section
*   **Layout**: A clean double-column split layout. Left: direct CTA header ("Let's construct something outstanding"). Right: minimalist form.
*   **Form Inputs**: Border-bottom inputs with floating labels that highlight cyan upon active typing focus.
