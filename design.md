---

### File 3: `design.md`
```markdown
# UI/UX System Design Document — ClubEvent Pro

## 1. Design Philosophy & System Framework
The design aims to turn standard corporate enterprise software into a clean, modern interface styled entirely with utility classes from **Tailwind CSS**. It relies heavily on high whitespace padding and strict borders to mimic high-density spreadsheet forms while keeping the design clean and spacious.

## 2. Color System & Token Mapping
The interface uses a deliberate, high-contrast color scheme to clearly separate operational controls from data tracking matrices:

| System Layer | Color Target | Tailwind Token | Application Purpose |
|---|---|---|---|
| **Primary Theme** | Royal Indigo | `bg-indigo-600` | Navigation frames, form submission actions, focus accents. |
| **Canvas** | Soft Slate | `bg-gray-50` | Full-page background to reduce eye strain. |
| **Panels** | True White | `bg-white` | Isolated foreground cards housing working modules. |
| **Data Rows** | Cool Gray | `bg-gray-100` | Header tables and zebra striping for tabular readouts. |
| **Alert/Success** | Emerald Green | `text-green-700` | Live spreadsheet calculation net surpluses. |

## 3. Responsive Screen Layout Framework

### 3.1 Desktop Viewports (`lg:grid-cols-3`)
*   **Left Axis Container (Width: 1/3):** Sticky configuration form capturing input parameters (Event creation pipeline).
*   **Right Workspace Container (Width: 2/3):** Dynamic layout containing spreadsheet rows for financial and milestone entries, loaded instantly using context selectors.

### 3.2 Mobile/Tablet Viewports (Default Fallback)
*   The system drops down into a stacked vertical interface. The Event Creation Panel slides above the management workspace, letting student leaders plan events on mobile screens without annoying horizontal scrolling.
