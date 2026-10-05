# JamesThewDB Database Documentation

## ER Diagram

```mermaid
erDiagram
    Users ||--o{ Subscriptions : has
    Users ||--o{ Recipes : authors
    Users ||--o{ Tips : authors
    Users ||--o{ ContestEntries : submits
    Users ||--o{ RecipeFeedbacks : writes
    Users ||--o{ PasswordResetTokens : requests

    Users {
        int Id PK
        string FullName
        string Email
        string Phone
        string PasswordHash
        string Role "Free/Member/Admin"
        string AvatarPath
        bool IsBlocked
        datetime CreatedAt
    }
    PasswordResetTokens {
        int Id PK
        int UserId FK
        string TokenHash
        datetime ExpiresAt
        datetime UsedAt
    }
    Subscriptions {
        int Id PK
        int UserId FK
        string Plan "Monthly/Yearly"
        decimal Amount
        datetime StartDate
        datetime ExpiryDate
        string PaymentStatus "Pending/Success/Failed"
        datetime CreatedAt
    }
    Categories ||--o{ Recipes : categorizes
    Categories ||--o{ Tips : categorizes
    Categories ||--o{ ContestEntries : categorizes
    Categories {
        int Id PK
        string Name
    }
    Recipes ||--o{ RecipeFeedbacks : receives
    Recipes {
        int Id PK
        string Title
        int CategoryId FK
        string Ingredients
        string Procedure
        int PrepMinutes
        int CookMinutes
        string ImagePath
        string Access "Free/Premium"
        int AuthorId FK
        datetime CreatedAt
        datetime UpdatedAt
    }
    Tips {
        int Id PK
        string Title
        int CategoryId FK
        string Description
        string ImagePath
        string Access "Free/Premium"
        int AuthorId FK
        datetime CreatedAt
    }
    Contests ||--o{ ContestEntries : accepts
    Contests ||--o{ Announcements : has
    Contests {
        int Id PK
        string Title
        string Description
        string EntryType "Recipe/Tip/Both"
        string Prize
        datetime StartDate
        datetime EndDate
        string Status "Active/Closed"
        datetime CreatedAt
    }
    ContestEntries ||--o| Announcements : winner_of
    ContestEntries {
        int Id PK
        int ContestId FK
        int UserId FK "nullable"
        string GuestName
        string GuestEmail
        string EntryType
        string Title
        int CategoryId FK "nullable"
        string Ingredients
        string Procedure
        string Description
        string ImagePath
        string Status "Pending/Winner"
        datetime SubmittedAt
    }
    Announcements {
        int Id PK
        string Type "Winner/Update/NewContest"
        string Title
        string Message
        int ContestId FK "nullable"
        int WinnerEntryId FK "nullable"
        datetime PostedAt
    }
    RecipeFeedbacks {
        int Id PK
        int RecipeId FK
        int UserId FK "nullable"
        string Name
        string Email
        int Rating
        string Comment
        datetime CreatedAt
    }
    SiteFeedbacks {
        int Id PK
        string Name
        string Email
        string Subject
        string Category
        int Rating
        string Comments
        bool ShowOnHome
        datetime CreatedAt
    }
    ContactMessages {
        int Id PK
        string Name
        string Email
        string Message
        datetime CreatedAt
    }
    Faqs {
        int Id PK
        string Question
        string Answer
        int DisplayOrder
    }
```

## Data Dictionary

### Users
- **Id**: int, Primary Key.
- **FullName**: string, max length 100, required.
- **Email**: string, max length 255, required, unique.
- **Phone**: string, max length 20, nullable.
- **PasswordHash**: string, required.
- **Role**: string, max length 20, required (Free, Member, Admin).
- **AvatarPath**: string, max length 255, nullable.
- **IsBlocked**: bool, required.
- **CreatedAt**: datetime, required.

### PasswordResetTokens
- **Id**: int, Primary Key.
- **UserId**: int, Foreign Key to Users.
- **TokenHash**: string, max length 255, required.
- **ExpiresAt**: datetime, required.
- **UsedAt**: datetime, nullable.

### Subscriptions
- **Id**: int, Primary Key.
- **UserId**: int, Foreign Key to Users.
- **Plan**: string, max length 50, required (Monthly/Yearly).
- **Amount**: decimal(18, 2), required.
- **StartDate**: datetime, required.
- **ExpiryDate**: datetime, required.
- **PaymentStatus**: string, max length 50, required (Pending/Success/Failed).
- **CreatedAt**: datetime, required.

### Categories
- **Id**: int, Primary Key.
- **Name**: string, max length 100, required.

### Recipes
- **Id**: int, Primary Key.
- **Title**: string, max length 200, required.
- **CategoryId**: int, Foreign Key to Categories.
- **Ingredients**: string, required.
- **Procedure**: string, required.
- **PrepMinutes**: int, required.
- **CookMinutes**: int, required.
- **ImagePath**: string, max length 255, nullable.
- **Access**: string, max length 20, required (Free, Premium).
- **AuthorId**: int, Foreign Key to Users.
- **CreatedAt**: datetime, required.
- **UpdatedAt**: datetime, required.

### Tips
- **Id**: int, Primary Key.
- **Title**: string, max length 200, required.
- **CategoryId**: int, Foreign Key to Categories.
- **Description**: string, required.
- **ImagePath**: string, max length 255, nullable.
- **Access**: string, max length 20, required (Free, Premium).
- **AuthorId**: int, Foreign Key to Users.
- **CreatedAt**: datetime, required.

### Contests
- **Id**: int, Primary Key.
- **Title**: string, max length 200, required.
- **Description**: string, required.
- **EntryType**: string, max length 50, required (Recipe/Tip/Both).
- **Prize**: string, max length 255, nullable.
- **StartDate**: datetime, required.
- **EndDate**: datetime, required.
- **Status**: string, max length 20, required (Active/Closed).
- **CreatedAt**: datetime, required.

### ContestEntries
- **Id**: int, Primary Key.
- **ContestId**: int, Foreign Key to Contests.
- **UserId**: int, Foreign Key to Users, nullable.
- **GuestName**: string, max length 100, nullable.
- **GuestEmail**: string, max length 255, nullable.
- **EntryType**: string, max length 50, required.
- **Title**: string, max length 200, required.
- **CategoryId**: int, Foreign Key to Categories, nullable.
- **Ingredients**: string, nullable.
- **Procedure**: string, nullable.
- **Description**: string, nullable.
- **ImagePath**: string, max length 255, nullable.
- **Status**: string, max length 20, required (Pending/Winner).
- **SubmittedAt**: datetime, required.

### Announcements
- **Id**: int, Primary Key.
- **Type**: string, max length 50, required (Winner/Update/NewContest).
- **Title**: string, max length 200, required.
- **Message**: string, required.
- **ContestId**: int, Foreign Key to Contests, nullable.
- **WinnerEntryId**: int, Foreign Key to ContestEntries, nullable.
- **PostedAt**: datetime, required.

### RecipeFeedbacks
- **Id**: int, Primary Key.
- **RecipeId**: int, Foreign Key to Recipes.
- **UserId**: int, Foreign Key to Users, nullable.
- **Name**: string, max length 100, nullable.
- **Email**: string, max length 255, nullable.
- **Rating**: int, required (1 to 5).
- **Comment**: string, required.
- **CreatedAt**: datetime, required.

### SiteFeedbacks
- **Id**: int, Primary Key.
- **Name**: string, max length 100, required.
- **Email**: string, max length 255, required.
- **Subject**: string, max length 200, nullable.
- **Category**: string, max length 50, required.
- **Rating**: int, required.
- **Comments**: string, required.
- **ShowOnHome**: bool, required.
- **CreatedAt**: datetime, required.

### ContactMessages
- **Id**: int, Primary Key.
- **Name**: string, max length 100, required.
- **Email**: string, max length 255, required.
- **Message**: string, required.
- **CreatedAt**: datetime, required.

### Faqs
- **Id**: int, Primary Key.
- **Question**: string, max length 500, required.
- **Answer**: string, required.
- **DisplayOrder**: int, required.
