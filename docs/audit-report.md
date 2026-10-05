# JamesThew.com - Audit Report & Walkthrough

## 1. Progress Table & Completion

| Area | Screen / Page | Route | Layout | Status |
|---|---|---|---|---|
| **Public** | Home | `/Home/Index` (or `/`) | `_PublicNavbar` | S2 |
| | Chef James | `/About/ChefJames` | `_PublicNavbar` | S1 |
| | Cookery Classes | `/About/Classes` | `_PublicNavbar` | S1 |
| | Our Mission | `/About/Mission` | `_PublicNavbar` | S1 |
| | Contact Us | `/Contact/Index` | `_PublicNavbar` | S1 |
| | Announcements | `/Announcement/Index` | `_PublicNavbar` | S1 |
| | Terms of Use | `/Home/Terms` | `_PublicNavbar` | S1 |
| | Privacy Policy | `/Home/Privacy` | `_PublicNavbar` | S1 |
| | FAQ | `/Faq/Index` | `_PublicNavbar` | S1 |
| | Site Feedback | `/Feedback/SiteFeedback` | `_PublicNavbar` | S1 |
| **Contests** | Active Contests | `/Contest/Active` | `_PublicNavbar` | S1 |
| | Submit Entry | `/Contest/Submit` | `_PublicNavbar` | S1 |
| | Winners | `/Contest/Winners` | `_PublicNavbar` | S1 |
| **Recipes** | Free Recipes | `/Recipe/Free` | `_PublicNavbar` | S2 |
| | Premium Recipes | `/Recipe/Premium` | `_PublicNavbar` | S2 |
| | Recipe Details | `/Recipe/Details` | `_PublicNavbar` | S1 |
| **Tips** | Free Tips | `/Tip/Free` | `_PublicNavbar` | S2 |
| | Premium Tips | `/Tip/Premium` | `_PublicNavbar` | S2 |
| | Tip Details | `/Tip/Details` | `_PublicNavbar` | S1 |
| **Auth** | Login | `/Account/Login` | `_PublicNavbar` | S2 |
| | Join Now (Register) | `/Account/Register` | `_PublicNavbar` | S2 |
| | Plans | `/Account/Plans` | `_PublicNavbar` | S1 |
| | Forgot Password | `/Account/ForgotPassword` | `_PublicNavbar` | S0 |
| | Reset Password | `/Account/ResetPassword` | `_PublicNavbar` | S0 |
| **Member** | Dashboard (Welcome) | `/Dashboard/Index` | `_MemberNavbar` | S1 |
| | Profile Settings | `/Dashboard/ProfileSettings` | `_MemberNavbar` | S1 |
| | My Recipes | `/Dashboard/MyRecipes` | `_MemberNavbar` | S1 |
| | Add Recipe | `/Dashboard/AddRecipe` | `_MemberNavbar` | S1 |
| | My Tips | `/Dashboard/MyTips` | `_MemberNavbar` | S1 |
| | Add Tip | `/Dashboard/AddTip` | `_MemberNavbar` | S1 |
| | Subscription | `/Dashboard/Subscription` | `_MemberNavbar` | S1 |
| | My Contest Entries| `/Dashboard/MyContestEntries` | `_MemberNavbar` | S1 |
| **Admin** | Dashboard | `/Admin/Dashboard` | `_AdminNavbar` | S1 |
| | Manage Recipes | `/Admin/Recipes` | `_AdminNavbar` | S1 |
| | Edit Recipe (Form)| `/Admin/RecipeForm` | `_AdminNavbar` | S1 |
| | Manage Tips | `/Admin/Tips` | `_AdminNavbar` | S1 |
| | Edit Tip (Form) | `/Admin/TipForm` | `_AdminNavbar` | S1 |
| | Manage Contests | `/Admin/Contests` | `_AdminNavbar` | S1 |
| | Manage Entries | `/Admin/Entries` | `_AdminNavbar` | S1 |
| | Announcements | `/Admin/Announcements` | `_AdminNavbar` | S1 |
| | Members | `/Admin/Members` | `_AdminNavbar` | S1 |
| | Feedback | `/Admin/Feedback` | `_AdminNavbar` | S1 |

**Completion %:**
- **Overall:** ~20% (Mostly UI shells, minimal backend logic)
- **Public UI:** 50% (Static pages built, dynamic data on a few pages)
- **Auth:** 30% (Login/Register controllers exist, but roles/cookies are incomplete)
- **Member Dashboard:** 10% (Static UI shell only)
- **Admin:** 10% (Static UI shell only)
- **Database:** 10% (EF Context and Models created, but migration failed locally due to missing SQL LocalDB, so no tables or data exist on this machine)
- **Security:** 5% (Basic `[Authorize]` attributes added, but no anti-forgery, no robust role checking)
- **Testing:** 0%
- **Docs:** 80%

## 2. Walkthrough (Phases B-1 to B-7)
- **What was built:** The foundational ASP.NET Core MVC project was set up. We created the `JamesThewDbContext` and the Entity Framework models mapping to the SRS document requirements. We generated Razor Views for every page from the Google Stitch designs, extracting raw HTML/CSS and mapping it into `_Layout`s (`_PublicNavbar`, `_MemberNavbar`, `_AdminNavbar`). We converted the static HTML grids for Free/Premium Recipes and Tips into dynamic `@foreach` loops iterating over strongly-typed Models.
- **What works right now:** If the DB existed, the Home Page, Free Recipes, Premium Recipes, Free Tips, and Premium Tips would display real DB data. The pages will build and run (0 errors/warnings). Error routes for 403/404 and 500 exceptions are wired up.
- **What is only visual:** Almost everything else. Dashboard, Admin pages, Contact forms, Profile Settings, Contest Submission, Recipe/Tip addition - all of these are currently just static HTML mimicking the designs. They have controllers that strictly return `View()`.
- **What is broken / Unverified:**
  - **UNVERIFIED: Database and Seeded Data.** `dotnet ef database update` **FAILED** due to a missing LocalDB installation on this Windows machine (`error: 52 - Unable to locate a Local Database Runtime installation`). The database `JamesThewDB` **does NOT exist** and there is no seeded data, meaning table row counts are **0**.
- **Fonts:** The app currently uses **EB Garamond** for headings and **Inter** for body text.

## 3. Known Problems
- **Database Connection:** As mentioned, LocalDB is missing. The connection string in `appsettings.json` points to `(localdb)\mssqllocaldb` which cannot be resolved.
- **Role Verification:** Code assumes a role named "Premium" to check for unlocked content in `Premium.cshtml` (`User.IsInRole("Premium")`), but the actual SRS roles are Free, Member, and Admin. This requires a fix to map "Member" to premium content instead of "Premium".
- **Subscription Expiry Logic:** Completely missing. The database `Subscription` table exists, but there is no middleware or controller logic checking `EndDate` or `Status`.
- **Controllers returning View() only:** About, Admin, Announcement, Contact, Contest, Dashboard, Faq, Feedback, Recipe (Details only), Tip (Details only). None of these pass data to the view or accept POST data.
- **#pragma warning disable:** Used in EF Models to suppress `CS8618` (Non-nullable property must contain a non-null value). These should be fixed by correctly assigning default values or using nullable reference types where appropriate.
- **Unescaped Razor / Hardcoded Data:** Static placeholder text (e.g., "By Mariam K." or "120 mins") is still hardcoded inside `Details.cshtml` and other views.
- **Missing Anti-Forgery Tokens:** Forms (Login, Register, Add Recipe) do not contain `@Html.AntiForgeryToken()` or `[ValidateAntiForgeryToken]` on the POST methods.
- **Traceability:** `/docs/traceability.md` status column needs an update; many items marked as "Done" or "In Progress" are strictly visual.

## 4. Project Tree

- **JamesThew.Web/** - Main application folder (NEEDED)
  - **Controllers/** - (NEEDED)
    - `AccountController.cs` - Handles login/registration.
    - `...Controller.cs` - Other static controllers (need logic).
  - **Data/** - (NEEDED)
    - `JamesThewDbContext.cs` - EF Core Context.
  - **Models/Entities/** - (NEEDED)
    - `User.cs`, `Recipe.cs`, `Tip.cs`, etc. - DB Entities.
  - **ViewModels/** - (NEEDED)
    - `AccountViewModels.cs` - Models for Login/Register forms.
  - **Views/** - (NEEDED)
    - `Shared/` - Navbars, Footers, and Layouts.
    - `Home/`, `Recipe/`, `Tip/`, etc. - Page views.
  - **wwwroot/** - (NEEDED)
    - `css/site.css` - Main stylesheet (fonts, custom styles).
    - `js/site.js` - Main JavaScript.
    - `images/` - Downloaded image assets from Stitch.
    - `lib/` - Third-party libraries (Bootstrap, jQuery).
  - `Program.cs` - App entry point.
  - `appsettings.json` - Configuration (DB connection).
- **docs/** - (NEEDED)
  - `audit-report.md` - This file.
  - `progress.md` - Rebuilt progress tracker.
  - `plan.md`, `decisions.md`, `traceability.md`, `screens.md` - Project documentation.
- **tools/** - Helper Python scripts moved from root (NEEDED)
  - `extract_home.py`, `generate_admin_pages.py`, etc. - Scripts used for scaffolding.

## 5. Cleanup Summary
- Deleted root python scripts (moved to `/tools`).
- Deleted `generate_output.txt`.
- Deleted `docs/home.html` (raw HTML copy).

## 6. Repair Plan (Next Steps)

1. **[S] Fix Database Configuration:** Update `appsettings.json` to point to a valid SQL Server instance (e.g., `.\SQLEXPRESS` or another available DB) and run EF Migrations to generate the database.
2. **[S] Seed Database:** Create a `DbInitializer` to populate the DB with Admins, Members, Free users, Recipes, and Tips, so the application can be tested.
3. **[M] Fix Authorization/Roles:** Correct the Premium content check to verify if the user has an active `Member` subscription instead of a "Premium" role. Implement Subscription expiry logic.
4. **[M] Implement Identity/Auth Backend:** Secure the `Login` and `Register` endpoints. Implement cookie issuance, anti-forgery tokens, and proper password validation.
5. **[L] Implement Dashboard & Admin Controllers:** Build out the CRUD logic for Recipes, Tips, Contests, and User management. Update the views to use `@model` instead of static HTML.
6. **[L] Implement Forms & Actions:** Build out Contact Us, Feedback, Add Recipe, Add Tip, Contest Submission forms, complete with model validation.
7. **[S] UI Polish & Stitch Verification:** Cross-reference every active page with the Stitch UI to ensure pixel-perfection.
8. **[M] End-to-End Testing:** Verify the complete user journey (Guest -> Free User -> Member -> Admin).
