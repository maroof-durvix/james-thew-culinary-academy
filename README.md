# JamesThew.com — Haute Cuisine Academy & Culinary Portal

[![.NET 10.0](https://img.shields.io/badge/.NET-10.0%20LTS-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![ASP.NET Core MVC](https://img.shields.io/badge/ASP.NET%20Core-MVC-2088FF?logo=.net&logoColor=white)](https://learn.microsoft.com/aspnet/core)
[![Entity Framework Core](https://img.shields.io/badge/EF%20Core-10.0-6C257E?logo=nuget&logoColor=white)](https://learn.microsoft.com/ef/core/)
[![Tailwind CSS](https://img.shields.io/badge/Tailwind_CSS-3.x-06B6D4?logo=tailwindcss&logoColor=white)](https://tailwindcss.com/)
[![Security](https://img.shields.io/badge/Security-BCrypt%20%2B%20RBAC-10B981?logo=shield&logoColor=white)]()

A bespoke, production-grade culinary academy and subscription-gated web platform created for world-renowned Chef James Thew. Built with **ASP.NET Core 10.0 MVC**, **Entity Framework Core**, and a dark luxury emerald design system powered by customized **Tailwind CSS**.

---

## 🍽️ Project Highlights

- **Bespoke Culinary Vault:** Bifurcated access to public Free Recipes and secluded VIP Michelin-grade Master Formulas.
- **Automated Subscription Lifecycle:** Real-time expiration enforcement for Monthly ($10) and Yearly ($100) memberships. Expired members are automatically locked out and redirected to an instant mock Recharge portal.
- **Culinary Contests Engine:** Seasonal competitions with dish photography uploads, entry categorization, admin adjudication, and automated winner victory tributes.
- **Kitchencraft Tips & Tricks:** Curated chef notes, heat control techniques, emulsion secrets, and culinary knife skills.
- **Dual-Layer Validation:** Enforced regex verification across client HTML5 attributes and server-side C# controllers on Name, Email, and Phone fields to prevent malformed or spam submissions.
- **Executive Admin Command Center:** Full CRUD control for recipes, tips, contests, announcements, FAQs, and member management (block/unblock/promote).
- **Dark Luxury Aesthetic:** Immersive palette featuring Deep Forest Emerald (`#071311`), Saffron Copper (`#D98A56`), frosted glassmorphism backdrops, and WCAG-compliant high-contrast typography.

---

## 🛠️ Technology Stack

| Layer | Technology |
| :--- | :--- |
| **Backend Framework** | ASP.NET Core 10.0 (MVC Pattern) |
| **Language** | C# 14.0 (.NET 10 SDK) |
| **ORM / Data Access** | Entity Framework Core 10.0 with LINQ |
| **Database** | Microsoft SQL Server / LocalDB (`(localdb)\MSSQLLocalDB`) |
| **Authentication** | Cookie Authentication with Claims (`ClaimsPrincipal`) |
| **Password Hashing** | BCrypt.Net-Next (12-round Salted Hashing) |
| **Frontend Styling** | Tailwind CSS with custom theme tokens & micro-animations |
| **Typography** | Syne (Headlines) & Plus Jakarta Sans (Body) |
| **Icons** | Google Material Symbols |

---

## 🚀 Getting Started

### Prerequisites
- [.NET 10.0 SDK](https://dotnet.microsoft.com/download/dotnet/10.0) or later
- Microsoft SQL Server LocalDB (included with Visual Studio or installed standalone)
- PowerShell 5.1+ / Terminal


### 1. Restore Dependencies
```bash
dotnet restore
```

### 2. Build the Application
```bash
dotnet build
```

### 3. Run the Web Application
```bash
dotnet run --launch-profile http
```
The application will automatically initialize the database schema, seed categories, master recipes, tips, contests, FAQs, and default accounts.

Open your browser and navigate to:
**`http://localhost:5090`**

---

## 🔐 Default Seed Credentials

| Role | Email Address | Password | Privileges |
| :--- | :--- | :--- | :--- |
| **Portal Administrator** | `admin@jamesthew.com` | `Admin@123` | Full Admin Command Center (`/Admin`), User Management, Contest Winner Crowning, Content CRUD |
| **VIP Member (Active)** | `member@jamesthew.com` | `Member@123` | Premium Recipe & Tip Vault, Personal Studio (`/Dashboard`), Contest Participation |

> **Note on Membership Expiry:** Free tier accounts are intentionally disabled. When a paid member's plan expires, login is denied with a prompt directing them to `/Plans/Recharge` to renew their subscription.

---

## 📂 Project Directory Structure

```text
JamesThew/
├── PROJECT_DOCUMENTATION.md      # Comprehensive academic & technical report
├── README.md                     # Developer & deployment guide
└── JamesThew.Web/
    ├── Controllers/              # MVC Controllers
    │   ├── AboutController.cs    # Chef James biography & academy classes
    │   ├── AdminController.cs    # Management suite & KPI analytics
    │   ├── AnnouncementsController.cs # Filterable bulletins
    │   ├── AuthController.cs     # Cookie auth, BCrypt, registration & expiry gate
    │   ├── ContestsController.cs # Seasonal competitions & entry submission
    │   ├── DashboardController.cs# Personal member studio & profile settings
    │   ├── HelpController.cs     # Contact concierge, feedback & FAQs
    │   ├── HomeController.cs     # Landing page & curated features
    │   ├── LegalController.cs    # Terms of service & privacy policies
    │   ├── PlansController.cs    # Subscription pricing & recharge gateway
    │   ├── RecipesController.cs  # Free & Premium recipes, details, reviews
    │   └── TipsController.cs     # Kitchen tricks & culinary discipline tips
    ├── Data/
    │   ├── DbInitializer.cs      # Database seeder (recipes, tips, contests, users)
    │   └── JamesThewDbContext.cs # EF Core DbContext & relationship mappings
    ├── Models/
    │   └── Entities/             # Domain models (User, Subscription, Recipe, etc.)
    ├── ViewModels/               # DTOs & form binding models
    ├── Views/                    # Razor .cshtml templates
    │   ├── Admin/                # Admin dashboards & CRUD views
    │   ├── Auth/                 # Login, Register, Forgot Password
    │   ├── Contests/             # Contest listing & entry forms
    │   ├── Dashboard/            # Member studio, recipes, tips, profile
    │   ├── Help/                 # Contact & Feedback forms
    │   ├── Plans/                # Membership tiers & recharge portal
    │   ├── Recipes/              # Recipe vault & step-by-step procedures
    │   ├── Shared/               # Master layout, footer, and navigation bars
    │   └── Tips/                 # Master tips views
    ├── wwwroot/                  # Static assets (Tailwind, icons, uploads, favicon)
    ├── Program.cs                # Dependency injection & HTTP pipeline configuration
    └── appsettings.json          # Database connection strings & logging config
```

---

## 🛡️ Security & Quality Architecture

1. **Password Encryption:** Zero plaintext passwords. Uses industry-standard BCrypt hashing with auto-generated salts.
2. **Subscription Access Gating:** Login pipeline queries `Subscriptions` table to verify `ExpiryDate > DateTime.UtcNow` and payment status.
3. **Dual-Layer Regex Validation:**
   - **Name:** `^[a-zA-Z\s]{2,50}$` (Letters & spaces only).
   - **Email:** `^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$` (Strict RFC-compliant domain and TLD).
   - **Phone:** `^[\+]?[0-9\s\-]{7,16}$` (Numeric characters with optional country code).
4. **CSRF Protection:** Every state-modifying POST request validates `[ValidateAntiForgeryToken]`.
5. **SQL Injection Defense:** All queries compiled via Entity Framework Core parameterized SQL.
6. **XSS Shielding:** Server-rendered outputs automatically HTML-encoded by the Razor engine.

---

## 🧪 Testing & Audit Verification

The platform has passed a rigorous 67-point automated health audit across all public, member, and admin endpoints with a **100% pass rate**.

---

## 📄 License & Intellectual Property

Academic & educational project developed under the Haute Cuisine curriculum.  
All culinary branding, recipes, and academy intellectual properties are registered under **Chef James Thew Haute Cuisine Academy**.
