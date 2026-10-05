# Technical Decisions & Conflict Resolutions

## Database Provider
- **Conflict**: The SRS specified SQL Server, but some initial instructions or patterns suggested SQLite.
- **Resolution**: SQL Server (LocalDB/localhost) is used definitively for the `JamesThewDB` database, matching the user's environment and final instructions.

## Fonts
- **Conflict**: Stitch screens use "Outfit" for headings and body, but previous generic planning suggested "EB Garamond" or others.
- **Resolution**: Implemented the Exact font mappings found in Stitch ("Outfit") via Google Fonts in the `_Layout.cshtml` and CSS variables, ensuring 1-to-1 visual matching.

## Route Mappings
- **Resolution**: Routes explicitly map as per Phase B requirements:
  - Home -> `/Home/Index`
  - Chef James -> `/About/ChefJames`
  - Cookery Classes -> `/About/Classes`
  - Our Mission -> `/About/Mission`
  - Free Recipes -> `/Recipe/Free`
  - Premium Recipes -> `/Recipe/Premium` (handles both Guest-locked and Member-unlocked states depending on User Role)
  - Recipe Details -> `/Recipe/Details/{id}`
  - Free Tips -> `/Tip/Free`
  - Premium Tips -> `/Tip/Premium`

## Seeding
- **Resolution**: The `DbInitializer` is fully idempotent and explicitly seeds exact row counts defined by the SRS (4 Categories, 12 Recipes, 8 Tips, 3 Contests, etc.) referencing test users.

## Subscriptions and Access Control
- **Resolution**: Handled cleanly via the `Access` property ("Free"/"Premium") on Recipes and Tips, cross-checked against the `Users.Role` (Free, Member, Admin) dynamically.

## Contest Entries for Guests
- **Conflict**: SRS needed both logged-in users and guests to submit entries.
- **Resolution**: `ContestEntries` table has a nullable `UserId`, paired with `GuestName` and `GuestEmail` to store unauthenticated submissions.
