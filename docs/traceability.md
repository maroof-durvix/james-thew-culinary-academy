# Traceability Matrix

| Req ID | Description | Route | Controller.Action | View | Service | Table | Status |
|---|---|---|---|---|---|---|---|
| **AUTH** | | | | | | | |
| FR-AUTH-01 | Register page fields (Name, Email, Phone, Pass) | `/Account/Register` | `AccountController.Register` | `Register.cshtml` | `AuthService` | `Users` | Planned |
| FR-AUTH-02 | Select plan (Monthly/Yearly) | `/Account/Register` | `AccountController.Register` | `Register.cshtml` | `AuthService` | `Subscriptions` | Planned |
| FR-AUTH-03 | Simulated payment fields | `/Account/Register` | `AccountController.Register` | `Register.cshtml` | `PaymentService` (mock) | N/A | Planned |
| FR-AUTH-04 | Accept Terms & Conditions | `/Account/Register` | `AccountController.Register` | `Register.cshtml` | `AuthService` | N/A | Planned |
| FR-AUTH-05 | Create account after payment, save dates | `/Account/Register` | `AccountController.Register` | `Register.cshtml` | `AuthService`, `SubscriptionService` | `Users`, `Subscriptions` | Planned |
| FR-AUTH-06 | Login with Email, Password, Remember Me | `/Account/Login` | `AccountController.Login` | `Login.cshtml` | `AuthService` | `Users` | Planned |
| FR-AUTH-07 | Forgot Password send reset link | `/Account/ForgotPassword` | `AccountController.ForgotPassword` | `ForgotPassword.cshtml` | `AuthService` | `PasswordResetTokens` | Planned |
| FR-AUTH-08 | Plans page with benefits | `/Account/Plans` | `AccountController.Plans` | `Plans.cshtml` | N/A | N/A | Planned |
| FR-AUTH-09 | Navbar changes by role | All | N/A | `_Layout.cshtml`, `_Navbar.cshtml` | N/A | N/A | Planned |
| FR-AUTH-10 | Membership expiry logic | `/Account/Login`, All | `AccountController.Login`, filters | N/A | `SubscriptionService` | `Subscriptions` | Planned |
| FR-AUTH-11 | Passwords hashed | `/Account/Register`, `/Account/Login` | `AccountController` | N/A | `AuthService` | `Users` | Planned |
| FR-AUTH-12 | Free Register | `/Account/RegisterFree` | `AccountController.RegisterFree` | `RegisterFree.cshtml` | `AuthService` | `Users` | Planned |
| FR-AUTH-13 | Upgrade/Renew flow for Free users and expired members | `/Dashboard/Subscription` | `DashboardController.Subscription` | `Subscription.cshtml` | `SubscriptionService`, `PaymentService` | `Subscriptions` | Planned |
| **PROFILE** | | | | | | | |
| FR-PRF-01 | Profile page header (avatar, info, status) | `/Dashboard/Profile` | `DashboardController.Profile` | `Profile.cshtml` | `UserService`, `SubscriptionService` | `Users`, `Subscriptions` | Planned |
| FR-PRF-02 | Edit profile info & password | `/Dashboard/Profile` | `DashboardController.Profile` (POST) | `Profile.cshtml` | `UserService` | `Users` | Planned |
| FR-PRF-03 | Profile Settings has Personal Information and Change Password tabs; posted recipes/tips/entries live on their own dashboard pages | `/Dashboard/Profile` | `DashboardController.Profile` | `Profile.cshtml` | N/A | N/A | Planned |
| FR-PRF-04 | Posted items listed with actions/status | `/Dashboard/*` | `DashboardController` | `MyRecipes.cshtml`, etc | `RecipeService`, `TipService`, `ContestService` | `Recipes`, `Tips`, `ContestEntries` | Planned |
| **RECIPES** | | | | | | | |
| FR-REC-01 | Free Recipes page | `/Recipe/Free` | `RecipeController.Free` | `Free.cshtml` | `RecipeService` | `Recipes` | Planned |
| FR-REC-02 | All Recipes page (blurred for guests) | `/Recipe/Premium` | `RecipeController.Premium` | `Premium.cshtml` | `RecipeService` | `Recipes` | Planned |
| FR-REC-03 | Search by keyword and category filters | `/Recipe/Free`, `/Recipe/Premium` | `RecipeController` | `Free.cshtml`, `Premium.cshtml` | `RecipeService` | `Recipes` | Planned |
| FR-REC-04 | Category pages | `/Recipe/Premium`, `/Recipe/Free` | `RecipeController` | `Premium.cshtml`, `Free.cshtml` | `RecipeService` | `Recipes` | Planned |
| FR-REC-05 | Recipe Details page | `/Recipe/Details/{id}` | `RecipeController.Details` | `Details.cshtml` | `RecipeService` | `Recipes` | Planned |
| FR-REC-06 | Premium recipe lock/blur for guests | `/Recipe/Details/{id}` | `RecipeController.Details` | `Details.cshtml` | `RecipeService`, `AuthService` | `Recipes` | Planned |
| FR-REC-07 | Display and submit recipe feedback | `/Recipe/Details/{id}` | `RecipeController.AddFeedback` (POST) | `Details.cshtml` | `FeedbackService` | `RecipeFeedbacks` | Planned |
| FR-REC-08 | Submit Recipe form fields | `/Dashboard/AddRecipe` | `DashboardController.AddRecipe` (POST) | `AddRecipe.cshtml` | `RecipeService` | `Recipes` | Planned |
| FR-REC-09 | Admin sets access type; Member defaults Premium | `/Dashboard/AddRecipe`, `/Admin/RecipeForm`| `DashboardController.AddRecipe`, `AdminController.RecipeForm` (POST) | `AddRecipe.cshtml`, `RecipeForm.cshtml` | `RecipeService` | `Recipes` | Planned |
| FR-REC-10 | My Recipes list with actions | `/Dashboard/MyRecipes` | `DashboardController.MyRecipes` | `MyRecipes.cshtml` | `RecipeService` | `Recipes` | Planned |
| FR-REC-11 | Image upload restrictions (5 MB JPG/PNG) | `/Dashboard/AddRecipe` | `DashboardController.AddRecipe` | `AddRecipe.cshtml` | `FileService` | N/A | Planned |
| FR-REC-12 | Edit Recipe | `/Dashboard/EditRecipe/{id}` | `DashboardController.EditRecipe` (POST) | `AddRecipe.cshtml` | `RecipeService` | `Recipes` | Planned |
| FR-REC-13 | Delete Recipe | `/Dashboard/DeleteRecipe/{id}` | `DashboardController.DeleteRecipe` (POST) | N/A | `RecipeService` | `Recipes` | Planned |
| **TIPS** | | | | | | | |
| FR-TIP-01 | Free Tips page | `/Tip/Free` | `TipController.Free` | `Free.cshtml` | `TipService` | `Tips` | Planned |
| FR-TIP-02 | All Tips page | `/Tip/Premium` | `TipController.Premium` | `Premium.cshtml` | `TipService` | `Tips` | Planned |
| FR-TIP-03 | Submit Tip form | `/Dashboard/AddTip` | `DashboardController.AddTip` (POST) | `AddTip.cshtml` | `TipService` | `Tips` | Planned |
| FR-TIP-04 | My Tips list with actions | `/Dashboard/MyTips` | `DashboardController.MyTips` | `MyTips.cshtml` | `TipService` | `Tips` | Planned |
| FR-TIP-05 | Edit Tip | `/Dashboard/EditTip/{id}` | `DashboardController.EditTip` (POST) | `AddTip.cshtml` | `TipService` | `Tips` | Planned |
| FR-TIP-06 | Delete Tip | `/Dashboard/DeleteTip/{id}` | `DashboardController.DeleteTip` (POST) | N/A | `TipService` | `Tips` | Planned |
| **CONTESTS**| | | | | | | |
| FR-CON-01 | Admin create contest | `/Admin/Contests/Create` | `AdminController.CreateContest` (POST) | `ContestForm.cshtml` | `ContestService` | `Contests` | Planned |
| FR-CON-02 | Active Contests page | `/Contest/Active` | `ContestController.Active` | `Active.cshtml` | `ContestService` | `Contests` | Planned |
| FR-CON-03 | Submit Contest Entry (Guests enter Name/Email) | `/Contest/Submit` | `ContestController.Submit` (POST) | `Submit.cshtml` | `ContestService` | `ContestEntries` | Planned |
| FR-CON-04 | Recipe entry and Tip entry fields | `/Contest/Submit` | `ContestController.Submit` | `Submit.cshtml` | `ContestService` | `ContestEntries` | Planned |
| FR-CON-05 | Entries only for active contests before deadline| `/Contest/Submit` | `ContestController.Submit` | `Submit.cshtml` | `ContestService` | `ContestEntries`, `Contests` | Planned |
| FR-CON-06 | Admin view all entries | `/Admin/Entries` | `AdminController.Entries` | `Entries.cshtml` | `ContestService` | `ContestEntries` | Planned |
| FR-CON-07 | Admin close or delete contest | `/Admin/Contests/Delete/{id}` | `AdminController.DeleteContest` (POST) | N/A | `ContestService` | `Contests` | Planned |
| FR-CON-08 | Admin select winner and publish | `/Admin/Entries/SelectWinner/{id}` | `AdminController.SelectWinner` (POST) | N/A | `ContestService`, `AnnouncementService` | `ContestEntries`, `Announcements` | Planned |
| FR-CON-09 | Contest Winners page | `/Contest/Winners` | `ContestController.Winners` | `Winners.cshtml` | `ContestService` | `Contests`, `ContestEntries` | Planned |
| FR-CON-10 | Admin cannot submit contest entries | `/Contest/Submit` | `ContestController.Submit` | N/A | `ContestService` | N/A | Planned |
| **ANNOUNCE**| | | | | | | |
| FR-ANN-01 | Announcements page display | `/Announcement/Index` | `AnnouncementController.Index` | `Index.cshtml` | `AnnouncementService` | `Announcements` | Planned |
| FR-ANN-02 | Publish winner creates announcement | `/Admin/Entries/SelectWinner/{id}` | `AdminController.SelectWinner` (POST) | N/A | `AnnouncementService` | `Announcements` | Planned |
| FR-ANN-03 | Admin post general announcements | `/Admin/Announcements/Create` | `AdminController.CreateAnnouncement` (POST) | `Announcements.cshtml` | `AnnouncementService` | `Announcements` | Planned |
| FR-ANN-04 | Admin edit announcement | `/Admin/Announcements/Edit/{id}` | `AdminController.EditAnnouncement` (POST) | `Announcements.cshtml` | `AnnouncementService` | `Announcements` | Planned |
| FR-ANN-05 | Admin delete announcement | `/Admin/Announcements/Delete/{id}` | `AdminController.DeleteAnnouncement` (POST) | N/A | `AnnouncementService` | `Announcements` | Planned |
| **FEEDBACK**| | | | | | | |
| FR-FBK-01 | Site Feedback form | `/Feedback/SiteFeedback` | `FeedbackController.SiteFeedback` (POST) | `SiteFeedback.cshtml` | `FeedbackService` | `SiteFeedbacks` | Planned |
| FR-FBK-02 | Recipe Feedback | `/Recipe/Details/{id}` | `RecipeController.AddFeedback` (POST) | `Details.cshtml` | `FeedbackService` | `RecipeFeedbacks` | Planned |
| FR-FBK-03 | Admin view/delete feedback | `/Admin/Feedbacks/Delete/{id}` | `AdminController.DeleteFeedback` (POST) | N/A | `FeedbackService` | `SiteFeedbacks`, `RecipeFeedbacks`| Planned |
| FR-FBK-04 | Show selected feedback on Home | `/Home/Index` | `HomeController.Index` | `Index.cshtml` | `FeedbackService` | `SiteFeedbacks` | Planned |
| **FAQ & CNT**| | | | | | | |
| FR-FAQ-01 | FAQ page accordion | `/Faq/Index` | `FaqController.Index` | `Index.cshtml` | `FaqService` | `Faqs` | Planned |
| FR-CNT-01 | Contact page details and form | `/Contact/Index` | `ContactController.Index` | `Index.cshtml` | `ContactService` | `ContactMessages` | Planned |
| FR-CNT-02 | Submitted inquiries saved | `/Contact/Index` | `ContactController.Index` (POST) | `Index.cshtml` | `ContactService` | `ContactMessages` | Planned |
| **ADMIN** | | | | | | | |
| FR-ADM-01 | Admin Dashboard summary | `/Admin/Dashboard` | `AdminController.Dashboard` | `Dashboard.cshtml` | `StatsService` | All | Planned |
| FR-ADM-02 | Manage Recipes | `/Admin/Recipes` | `AdminController.Recipes` | `Recipes.cshtml` | `RecipeService` | `Recipes` | Planned |
| FR-ADM-03 | Manage Tips | `/Admin/Tips` | `AdminController.Tips` | `Tips.cshtml` | `TipService` | `Tips` | Planned |
| FR-ADM-04 | Manage Contests | `/Admin/Contests` | `AdminController.Contests` | `Contests.cshtml` | `ContestService` | `Contests` | Planned |
| FR-ADM-05 | Announce Winner | `/Admin/Entries` | `AdminController.SelectWinner` | `Entries.cshtml` | `ContestService` | `ContestEntries` | Planned |
| FR-ADM-06 | View Feedbacks | `/Admin/Feedbacks` | `AdminController.Feedbacks` | `Feedbacks.cshtml` | `FeedbackService` | `SiteFeedbacks`, `RecipeFeedbacks` | Planned |
| FR-ADM-07 | Manage Users | `/Admin/Users` | `AdminController.Users` | `Users.cshtml` | `UserService` | `Users`, `Subscriptions` | Planned |
| FR-ADM-08 | Block/Unblock User | `/Admin/Users/ToggleBlock/{id}` | `AdminController.ToggleBlockUser` (POST) | N/A | `UserService` | `Users` | Planned |
| FR-ADM-09 | Admin Profile | `/Admin/Profile` | `AdminController.Profile` | `Profile.cshtml` | `UserService` | `Users` | Planned |
| FR-ADM-10 | Admin menu items | `/Admin/*` | `AdminController` | `_AdminLayout.cshtml` | N/A | N/A | Planned |

