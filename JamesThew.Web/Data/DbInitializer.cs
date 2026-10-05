using System;
using System.Linq;
using JamesThew.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;

namespace JamesThew.Web.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new JamesThewDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<JamesThewDbContext>>()))
            {
                try {
                    context.Database.Migrate();
                } catch { } // Ignore if unable to migrate

                var now = DateTime.UtcNow;

                // 1. Categories (EXACTLY 4)
                var categoryNames = new[] { "Juices", "Vegetarian", "Non-Vegetarian", "Italian" };
                
                // Remove unwanted categories that were added by mistake in previous seed
                var unwantedCategories = context.Categories.Where(c => !categoryNames.Contains(c.Name)).ToList();
                if (unwantedCategories.Any())
                {
                    context.Categories.RemoveRange(unwantedCategories);
                    context.SaveChanges();
                }

                foreach (var catName in categoryNames)
                {
                    if (!context.Categories.Any(c => c.Name == catName))
                    {
                        context.Categories.Add(new Category { Name = catName });
                    }
                }
                context.SaveChanges();

                var cats = context.Categories.ToList();
                var cJuice = cats.First(c => c.Name == "Juices").Id;
                var cVeg = cats.First(c => c.Name == "Vegetarian").Id;
                var cNonVeg = cats.First(c => c.Name == "Non-Vegetarian").Id;
                var cItalian = cats.First(c => c.Name == "Italian").Id;

                // 2. Users & Subscriptions
                var adminEmail = "admin@jamesthew.com";
                if (!context.Users.Any(u => u.Email == adminEmail))
                {
                    context.Users.Add(new User { FullName = "Admin James", Email = adminEmail, PasswordHash = "Admin@123", Role = "Admin", IsBlocked = false, CreatedAt = now });
                }

                var freeEmail = "free@jamesthew.com";
                if (!context.Users.Any(u => u.Email == freeEmail))
                {
                    context.Users.Add(new User { FullName = "Free User", Email = freeEmail, PasswordHash = "Free@123", Role = "Free", IsBlocked = false, CreatedAt = now });
                }

                var memberEmail = "member@jamesthew.com";
                if (!context.Users.Any(u => u.Email == memberEmail))
                {
                    var activeMember = new User { FullName = "Active Member", Email = memberEmail, PasswordHash = "Member@123", Role = "Member", IsBlocked = false, CreatedAt = now.AddDays(-30) };
                    context.Users.Add(activeMember);
                    context.SaveChanges();
                    
                    context.Subscriptions.Add(new Subscription { UserId = activeMember.Id, Plan = "Monthly", Amount = 10.00m, StartDate = now.AddDays(-5), ExpiryDate = now.AddDays(25), PaymentStatus = "Paid", CreatedAt = now.AddDays(-5) });
                }

                var expiredEmail = "expired@jamesthew.com";
                if (!context.Users.Any(u => u.Email == expiredEmail))
                {
                    var expiredMember = new User { FullName = "Expired Member", Email = expiredEmail, PasswordHash = "Expired@123", Role = "Member", IsBlocked = false, CreatedAt = now.AddDays(-400) };
                    context.Users.Add(expiredMember);
                    context.SaveChanges();
                    
                    context.Subscriptions.Add(new Subscription { UserId = expiredMember.Id, Plan = "Yearly", Amount = 100.00m, StartDate = now.AddDays(-380), ExpiryDate = now.AddDays(-15), PaymentStatus = "Paid", CreatedAt = now.AddDays(-380) });
                }

                var blockedEmail = "blocked@jamesthew.com";
                if (!context.Users.Any(u => u.Email == blockedEmail))
                {
                    context.Users.Add(new User { FullName = "Blocked User", Email = blockedEmail, PasswordHash = "Blocked@123", Role = "Free", IsBlocked = true, CreatedAt = now.AddDays(-10) });
                }

                context.SaveChanges();

                var uAdmin = context.Users.First(u => u.Email == adminEmail).Id;
                var uFree = context.Users.First(u => u.Email == freeEmail).Id;
                var uMember = context.Users.First(u => u.Email == memberEmail).Id;

                // 3. Recipes (12 total: 6 Free, 6 Premium)
                if (context.Recipes.Count() < 12)
                {
                    var recipesToSeed = new List<Recipe>
                    {
                        // Juices
                        new Recipe { Title = "Fresh Orange Twist", CategoryId = cJuice, Ingredients = "Oranges, Mint, Ice", Procedure = "1. Squeeze oranges.\n2. Add mint and ice.", PrepMinutes = 5, CookMinutes = 0, ImagePath = "/images/recipe-1.jpg", Access = "Free", AuthorId = uAdmin, CreatedAt = now, UpdatedAt = now },
                        new Recipe { Title = "Green Detox Power", CategoryId = cJuice, Ingredients = "Kale, Apple, Lemon", Procedure = "1. Blend all ingredients.\n2. Serve chilled.", PrepMinutes = 10, CookMinutes = 0, ImagePath = "/images/recipe-2.jpg", Access = "Premium", AuthorId = uMember, CreatedAt = now, UpdatedAt = now },
                        new Recipe { Title = "Berry Blast Smoothie", CategoryId = cJuice, Ingredients = "Mixed berries, Yogurt", Procedure = "1. Blend berries.\n2. Mix with yogurt.", PrepMinutes = 5, CookMinutes = 0, ImagePath = "/images/recipe-3.jpg", Access = "Free", AuthorId = uAdmin, CreatedAt = now, UpdatedAt = now },
                        
                        // Vegetarian
                        new Recipe { Title = "Classic Caesar Salad", CategoryId = cVeg, Ingredients = "Lettuce, Croutons, Dressing", Procedure = "1. Chop lettuce.\n2. Mix with dressing.", PrepMinutes = 15, CookMinutes = 0, ImagePath = "/images/recipe-4.jpg", Access = "Free", AuthorId = uAdmin, CreatedAt = now, UpdatedAt = now },
                        new Recipe { Title = "Mushroom Risotto", CategoryId = cVeg, Ingredients = "Rice, Mushrooms, Parmesan", Procedure = "1. Sauté mushrooms.\n2. Cook rice slowly.\n3. Mix together.", PrepMinutes = 10, CookMinutes = 30, ImagePath = "/images/recipe-5.jpg", Access = "Premium", AuthorId = uMember, CreatedAt = now, UpdatedAt = now },
                        new Recipe { Title = "Veggie Stir Fry", CategoryId = cVeg, Ingredients = "Broccoli, Carrots, Soy Sauce", Procedure = "1. Chop vegetables.\n2. Stir fry in pan.", PrepMinutes = 15, CookMinutes = 10, ImagePath = "/images/recipe-6.jpg", Access = "Premium", AuthorId = uAdmin, CreatedAt = now, UpdatedAt = now },
                        
                        // Non-Vegetarian
                        new Recipe { Title = "Grilled Lemon Chicken", CategoryId = cNonVeg, Ingredients = "Chicken breast, Lemon, Garlic", Procedure = "1. Marinate chicken.\n2. Grill for 15 mins per side.", PrepMinutes = 20, CookMinutes = 30, ImagePath = "/images/recipe-7.jpg", Access = "Free", AuthorId = uAdmin, CreatedAt = now, UpdatedAt = now },
                        new Recipe { Title = "Beef Wellington", CategoryId = cNonVeg, Ingredients = "Beef fillet, Puff pastry, Mushrooms", Procedure = "1. Sear beef.\n2. Wrap in pastry.\n3. Bake until golden.", PrepMinutes = 40, CookMinutes = 45, ImagePath = "/images/recipe-8.jpg", Access = "Premium", AuthorId = uMember, CreatedAt = now, UpdatedAt = now },
                        new Recipe { Title = "Spicy Fish Tacos", CategoryId = cNonVeg, Ingredients = "White fish, Tortillas, Salsa", Procedure = "1. Fry fish.\n2. Assemble tacos.", PrepMinutes = 15, CookMinutes = 15, ImagePath = "/images/recipe-9.jpg", Access = "Free", AuthorId = uAdmin, CreatedAt = now, UpdatedAt = now },
                        
                        // Italian
                        new Recipe { Title = "Spaghetti Carbonara", CategoryId = cItalian, Ingredients = "Spaghetti, Eggs, Pancetta, Cheese", Procedure = "1. Boil pasta.\n2. Fry pancetta.\n3. Mix with eggs and cheese.", PrepMinutes = 10, CookMinutes = 15, ImagePath = "/images/recipe-10.jpg", Access = "Premium", AuthorId = uAdmin, CreatedAt = now, UpdatedAt = now },
                        new Recipe { Title = "Margherita Pizza", CategoryId = cItalian, Ingredients = "Pizza dough, Tomato sauce, Mozzarella, Basil", Procedure = "1. Spread sauce on dough.\n2. Add cheese and basil.\n3. Bake in hot oven.", PrepMinutes = 20, CookMinutes = 12, ImagePath = "/images/recipe-11.jpg", Access = "Premium", AuthorId = uMember, CreatedAt = now, UpdatedAt = now },
                        new Recipe { Title = "Classic Lasagna", CategoryId = cItalian, Ingredients = "Lasagna sheets, Beef ragu, Bechamel sauce", Procedure = "1. Layer sheets, meat, and sauce.\n2. Bake until bubbly.", PrepMinutes = 30, CookMinutes = 45, ImagePath = "/images/recipe-12.jpg", Access = "Free", AuthorId = uAdmin, CreatedAt = now, UpdatedAt = now }
                    };

                    foreach (var r in recipesToSeed)
                    {
                        if (!context.Recipes.Any(x => x.Title == r.Title))
                        {
                            context.Recipes.Add(r);
                        }
                    }
                    context.SaveChanges();
                }

                // 4. Tips (8 total: 4 Free, 4 Premium)
                if (context.Tips.Count() < 8)
                {
                    var tipsToSeed = new List<Tip>
                    {
                        new Tip { Title = "Juicing Hacks", CategoryId = cJuice, Description = "Roll lemons before squeezing to get more juice.", ImagePath = "/images/tip-1.jpg", Access = "Free", AuthorId = uAdmin, CreatedAt = now },
                        new Tip { Title = "Keeping greens fresh", CategoryId = cJuice, Description = "Store kale with a paper towel.", ImagePath = "/images/tip-2.jpg", Access = "Premium", AuthorId = uMember, CreatedAt = now },
                        new Tip { Title = "Perfect Pasta", CategoryId = cItalian, Description = "Always salt your pasta water like the sea.", ImagePath = "/images/tip-3.jpg", Access = "Free", AuthorId = uAdmin, CreatedAt = now },
                        new Tip { Title = "Pizza Dough Secret", CategoryId = cItalian, Description = "Let it cold ferment in the fridge overnight.", ImagePath = "/images/tip-4.jpg", Access = "Premium", AuthorId = uMember, CreatedAt = now },
                        new Tip { Title = "Crispy Veggies", CategoryId = cVeg, Description = "Dry vegetables thoroughly before roasting.", ImagePath = "/images/tip-5.jpg", Access = "Free", AuthorId = uAdmin, CreatedAt = now },
                        new Tip { Title = "Quick Pickling", CategoryId = cVeg, Description = "Use hot vinegar for a quick 30-min pickle.", ImagePath = "/images/tip-6.jpg", Access = "Premium", AuthorId = uMember, CreatedAt = now },
                        new Tip { Title = "Searing Meat", CategoryId = cNonVeg, Description = "Pat meat dry before putting it in a hot pan.", ImagePath = "/images/tip-7.jpg", Access = "Free", AuthorId = uAdmin, CreatedAt = now },
                        new Tip { Title = "Resting Steaks", CategoryId = cNonVeg, Description = "Always rest your steak for half its cooking time.", ImagePath = "/images/tip-8.jpg", Access = "Premium", AuthorId = uMember, CreatedAt = now }
                    };
                    
                    foreach (var t in tipsToSeed)
                    {
                        if (!context.Tips.Any(x => x.Title == t.Title))
                        {
                            context.Tips.Add(t);
                        }
                    }
                    context.SaveChanges();
                }

                // 5. Contests (3 total: 1 Active, 2 Closed)
                if (context.Contests.Count() < 3)
                {
                    var contestsToSeed = new List<Contest>
                    {
                        new Contest { Title = "Best Summer Juice", Description = "Submit your refreshing juice recipe.", EntryType = "Recipe", Prize = "$50 Gift Card", Status = "Active", StartDate = now.AddDays(-5), EndDate = now.AddDays(15), CreatedAt = now.AddDays(-5) },
                        new Contest { Title = "Pasta Masterclass", Description = "Show us your best Italian pasta dish.", EntryType = "Recipe", Prize = "Cookbook Set", Status = "Closed", StartDate = now.AddDays(-30), EndDate = now.AddDays(-10), CreatedAt = now.AddDays(-30) },
                        new Contest { Title = "Vegetarian Tip Contest", Description = "Share your best tip for cooking vegetables.", EntryType = "Tip", Prize = "Premium Chef Knife", Status = "Closed", StartDate = now.AddDays(-60), EndDate = now.AddDays(-40), CreatedAt = now.AddDays(-60) }
                    };

                    foreach (var c in contestsToSeed)
                    {
                        if (!context.Contests.Any(x => x.Title == c.Title))
                        {
                            context.Contests.Add(c);
                        }
                    }
                    context.SaveChanges();
                }

                // 6. ContestEntries (7 entries)
                var activeContest = context.Contests.First(c => c.Title == "Best Summer Juice");
                var pastaContest = context.Contests.First(c => c.Title == "Pasta Masterclass");
                var vegContest = context.Contests.First(c => c.Title == "Vegetarian Tip Contest");

                if (context.ContestEntries.Count() < 7)
                {
                    var entriesToSeed = new List<ContestEntry>
                    {
                        // Active Contest Entries
                        new ContestEntry { ContestId = activeContest.Id, UserId = uMember, Title = "Minty Watermelon", EntryType = "Recipe", CategoryId = cJuice, Ingredients = "Watermelon, Mint", Procedure = "Blend together", ImagePath = "/images/entry-1.jpg", Status = "Pending", SubmittedAt = now.AddDays(-2) },
                        new ContestEntry { ContestId = activeContest.Id, GuestName = "Guest Jane", GuestEmail = "jane@guest.com", Title = "Citrus Blast", EntryType = "Recipe", CategoryId = cJuice, Ingredients = "Orange, Grapefruit", Procedure = "Squeeze and mix", ImagePath = "/images/entry-2.jpg", Status = "Pending", SubmittedAt = now.AddDays(-1) },
                        new ContestEntry { ContestId = activeContest.Id, UserId = uFree, Title = "Carrot Apple Zing", EntryType = "Recipe", CategoryId = cJuice, Ingredients = "Carrot, Apple, Ginger", Procedure = "Juice together", ImagePath = "/images/entry-3.jpg", Status = "Pending", SubmittedAt = now.AddDays(-3) },
                        
                        // Pasta Contest Entries (Closed)
                        new ContestEntry { ContestId = pastaContest.Id, UserId = uMember, Title = "Pesto Penne", EntryType = "Recipe", CategoryId = cItalian, Ingredients = "Penne, Basil Pesto", Procedure = "Boil and mix", ImagePath = "/images/entry-4.jpg", Status = "Winner", SubmittedAt = now.AddDays(-20) },
                        new ContestEntry { ContestId = pastaContest.Id, GuestName = "Guest Bob", GuestEmail = "bob@guest.com", Title = "Tomato Basil Spaghetti", EntryType = "Recipe", CategoryId = cItalian, Ingredients = "Spaghetti, Tomatoes", Procedure = "Cook pasta and sauce", ImagePath = "/images/entry-5.jpg", Status = "Pending", SubmittedAt = now.AddDays(-15) },
                        
                        // Veg Tip Contest Entries (Closed)
                        new ContestEntry { ContestId = vegContest.Id, GuestName = "Guest Alice", GuestEmail = "alice@guest.com", Title = "Crispy Roast Potatoes", EntryType = "Tip", Description = "Boil with baking soda before roasting.", ImagePath = "", Status = "Winner", SubmittedAt = now.AddDays(-50) },
                        new ContestEntry { ContestId = vegContest.Id, UserId = uFree, Title = "Steaming broccoli", EntryType = "Tip", Description = "Steam for exactly 4 minutes.", ImagePath = "", Status = "Pending", SubmittedAt = now.AddDays(-45) }
                    };

                    foreach (var e in entriesToSeed)
                    {
                        if (!context.ContestEntries.Any(x => x.Title == e.Title && x.ContestId == e.ContestId))
                        {
                            context.ContestEntries.Add(e);
                        }
                    }
                    context.SaveChanges();
                }

                // 7. Announcements (5 total)
                if (context.Announcements.Count() < 5)
                {
                    var pastaWinner = context.ContestEntries.First(e => e.Title == "Pesto Penne");
                    var vegWinner = context.ContestEntries.First(e => e.Title == "Crispy Roast Potatoes");

                    var announcementsToSeed = new List<Announcement>
                    {
                        new Announcement { Type = "Winner", Title = "Pasta Masterclass Winner!", Message = "Congratulations on the amazing Pesto Penne!", ContestId = pastaContest.Id, WinnerEntryId = pastaWinner.Id, PostedAt = now.AddDays(-9) },
                        new Announcement { Type = "Winner", Title = "Vegetarian Tip Contest Winner!", Message = "Alice wins with her crispy potato tip!", ContestId = vegContest.Id, WinnerEntryId = vegWinner.Id, PostedAt = now.AddDays(-39) },
                        new Announcement { Type = "Update", Title = "Site Upgrade", Message = "We have added new fast servers!", PostedAt = now.AddDays(-25) },
                        new Announcement { Type = "Update", Title = "New Recipes Available", Message = "Check out our new Juices collection!", PostedAt = now.AddDays(-2) },
                        new Announcement { Type = "NewContest", Title = "Summer Juice Challenge is LIVE!", Message = "Submit your juice recipes now!", ContestId = activeContest.Id, PostedAt = now.AddDays(-5) }
                    };

                    foreach (var a in announcementsToSeed)
                    {
                        if (!context.Announcements.Any(x => x.Title == a.Title))
                        {
                            context.Announcements.Add(a);
                        }
                    }
                    context.SaveChanges();
                }

                // 8. RecipeFeedbacks (8 total)
                if (context.RecipeFeedbacks.Count() < 8)
                {
                    var r1 = context.Recipes.First(r => r.Title == "Fresh Orange Twist").Id;
                    var r2 = context.Recipes.First(r => r.Title == "Beef Wellington").Id;

                    var recipeFeedbacksToSeed = new List<RecipeFeedback>
                    {
                        new RecipeFeedback { RecipeId = r1, UserId = uMember, Name = "Active Member", Email = "member@jamesthew.com", Rating = 5, Comment = "Very refreshing!", CreatedAt = now.AddDays(-1) },
                        new RecipeFeedback { RecipeId = r1, UserId = null, Name = "Guest Tim", Email = "tim@guest.com", Rating = 4, Comment = "Nice and simple.", CreatedAt = now.AddDays(-2) },
                        new RecipeFeedback { RecipeId = r1, UserId = uFree, Name = "Free User", Email = "free@jamesthew.com", Rating = 5, Comment = "Loved it!", CreatedAt = now.AddDays(-3) },
                        new RecipeFeedback { RecipeId = r2, UserId = uMember, Name = "Active Member", Email = "member@jamesthew.com", Rating = 5, Comment = "A classic masterpiece.", CreatedAt = now.AddDays(-10) },
                        new RecipeFeedback { RecipeId = r2, UserId = null, Name = "Guest Sarah", Email = "sarah@guest.com", Rating = 3, Comment = "A bit hard to make.", CreatedAt = now.AddDays(-8) },
                        new RecipeFeedback { RecipeId = r2, UserId = uFree, Name = "Free User", Email = "free@jamesthew.com", Rating = 4, Comment = "Great taste!", CreatedAt = now.AddDays(-5) },
                        new RecipeFeedback { RecipeId = r1, UserId = null, Name = "Guest Mike", Email = "mike@guest.com", Rating = 5, Comment = "Perfect for summer.", CreatedAt = now.AddHours(-5) },
                        new RecipeFeedback { RecipeId = r2, UserId = null, Name = "Guest Leo", Email = "leo@guest.com", Rating = 5, Comment = "Amazing recipe.", CreatedAt = now.AddHours(-12) }
                    };

                    foreach (var f in recipeFeedbacksToSeed)
                    {
                        if (!context.RecipeFeedbacks.Any(x => x.RecipeId == f.RecipeId && x.Email == f.Email && x.Comment == f.Comment))
                        {
                            context.RecipeFeedbacks.Add(f);
                        }
                    }
                    context.SaveChanges();
                }

                // 9. SiteFeedbacks (8 total, 3 with ShowOnHome = true)
                if (context.SiteFeedbacks.Count() < 8)
                {
                    var siteFeedbacksToSeed = new List<SiteFeedback>
                    {
                        new SiteFeedback { Name = "John Doe", Email = "john@test.com", Subject = "Great site", Category = "General", Rating = 5, Comments = "Love the new design.", ShowOnHome = true, CreatedAt = now.AddDays(-2) },
                        new SiteFeedback { Name = "Alice Smith", Email = "alice@test.com", Subject = "Help with membership", Category = "Support", Rating = 4, Comments = "Had some issues logging in but it works now.", ShowOnHome = false, CreatedAt = now.AddDays(-3) },
                        new SiteFeedback { Name = "Chef Mike", Email = "mike@test.com", Subject = "Amazing recipes", Category = "Recipes", Rating = 5, Comments = "The recipes here are top tier.", ShowOnHome = true, CreatedAt = now.AddDays(-4) },
                        new SiteFeedback { Name = "Susan", Email = "susan@test.com", Subject = "Site is slow", Category = "Technical", Rating = 3, Comments = "Pages take a bit to load.", ShowOnHome = false, CreatedAt = now.AddDays(-5) },
                        new SiteFeedback { Name = "Bob", Email = "bob@test.com", Subject = "Good tips", Category = "Tips", Rating = 5, Comments = "Very useful cooking tips!", ShowOnHome = true, CreatedAt = now.AddDays(-6) },
                        new SiteFeedback { Name = "Eva", Email = "eva@test.com", Subject = "Contest questions", Category = "General", Rating = 4, Comments = "When is the next contest?", ShowOnHome = false, CreatedAt = now.AddDays(-7) },
                        new SiteFeedback { Name = "Chris", Email = "chris@test.com", Subject = "Loving it", Category = "General", Rating = 5, Comments = "Will recommend to my friends.", ShowOnHome = false, CreatedAt = now.AddDays(-8) },
                        new SiteFeedback { Name = "Diana", Email = "diana@test.com", Subject = "Subscription issue", Category = "Support", Rating = 2, Comments = "My payment failed.", ShowOnHome = false, CreatedAt = now.AddDays(-9) }
                    };

                    foreach (var sf in siteFeedbacksToSeed)
                    {
                        if (!context.SiteFeedbacks.Any(x => x.Email == sf.Email && x.Subject == sf.Subject))
                        {
                            context.SiteFeedbacks.Add(sf);
                        }
                    }
                    context.SaveChanges();
                }

                // 10. FAQs (Exactly 7)
                if (context.Faqs.Count() < 7)
                {
                    var faqsToSeed = new List<Faq>
                    {
                        new Faq { Question = "How to become the member of this site?", Answer = "Click Join Membership, choose a plan ($10/month or $100/year), complete payment and register.", DisplayOrder = 1 },
                        new Faq { Question = "Will there be any subscription charges?", Answer = "Yes. Monthly ($10) or Yearly ($100) for full access. Basic recipes remain free.", DisplayOrder = 2 },
                        new Faq { Question = "How to view the recipes and tips? Will there be any charges?", Answer = "Free recipes and tips can be viewed without charge. The full catalog requires paid membership.", DisplayOrder = 3 },
                        new Faq { Question = "I am not a registered member. Can I participate in the contest?", Answer = "Yes. General users can participate by posting recipes or tips for the contest.", DisplayOrder = 4 },
                        new Faq { Question = "How to upload or post the recipes and tips?", Answer = "Logged-in users use Submit Recipe or Submit Tip from the navbar dropdowns.", DisplayOrder = 5 },
                        new Faq { Question = "How to post a feedback?", Answer = "Post recipe feedback on the Recipe Details page, or site feedback on the Site Feedback page.", DisplayOrder = 6 },
                        new Faq { Question = "I posted a recipe or tip for a contest. How do I know the winner?", Answer = "Winners are announced on the Announcements page after Chef James reviews all submissions.", DisplayOrder = 7 }
                    };
                    
                    var existingFaqs = context.Faqs.ToList();
                    context.Faqs.RemoveRange(existingFaqs);
                    context.SaveChanges();
                    
                    context.Faqs.AddRange(faqsToSeed);
                    context.SaveChanges();
                }

                // 11. ContactMessages (1 message)
                if (!context.ContactMessages.Any())
                {
                    context.ContactMessages.Add(new ContactMessage { Name = "Test User", Email = "test@contact.com", Message = "Just testing the contact form.", CreatedAt = now });
                    context.SaveChanges();
                }
                
                // 12. PasswordResetTokens (1 token)
                if (!context.PasswordResetTokens.Any())
                {
                    context.PasswordResetTokens.Add(new PasswordResetToken { UserId = uMember, TokenHash = "dummy-token-123", ExpiresAt = now.AddHours(2) });
                    context.SaveChanges();
                }
            }
        }
    }
}
