using System;
using System.Linq;
using JamesThew.Web.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace JamesThew.Web.Data
{
    public static class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new JamesThewDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<JamesThewDbContext>>()))
            {
                // Note: database creation might fail if LocalDB is missing in the environment.
                try {
                    context.Database.Migrate();
                } catch { } // Ignore if unable to migrate

                // Seed Categories
                if (!context.Categories.Any())
                {
                    context.Categories.AddRange(
                        new Category { Name = "Breakfast" },
                        new Category { Name = "Fast Food" },
                        new Category { Name = "Healthy" },
                        new Category { Name = "Soups" },
                        new Category { Name = "Beef" },
                        new Category { Name = "Sea Foods" },
                        new Category { Name = "Cakes" }
                    );
                    context.SaveChanges();
                }

                // Seed Admin User
                if (!context.Users.Any())
                {
                    context.Users.Add(new User
                    {
                        FullName = "James Thew",
                        Email = "james@jamesthew.com",
                        PasswordHash = "Admin@123", // Note: In real app, this should be hashed
                        Role = "Admin",
                        IsBlocked = false,
                        CreatedAt = DateTime.UtcNow
                    });
                    context.SaveChanges();
                }

                // Seed Recipes
                if (!context.Recipes.Any())
                {
                    var healthyCategory = context.Categories.FirstOrDefault(c => c.Name == "Healthy");
                    var admin = context.Users.FirstOrDefault(u => u.Role == "Admin");

                    if (healthyCategory != null && admin != null)
                    {
                        context.Recipes.AddRange(
                            new Recipe
                            {
                                Title = "Grilled Salmon with Asparagus",
                                CategoryId = healthyCategory.Id,
                                Ingredients = "Salmon, Asparagus, Olive Oil, Lemon",
                                Procedure = "Grill salmon and asparagus. Serve with lemon.",
                                PrepMinutes = 10,
                                CookMinutes = 20,
                                ImagePath = "healthy-recipe-1.jpg",
                                Access = "Free",
                                AuthorId = admin.Id
                            },
                            new Recipe
                            {
                                Title = "Quinoa Salad Bowl",
                                CategoryId = healthyCategory.Id,
                                Ingredients = "Quinoa, Avocado, Tomatoes, Cucumber",
                                Procedure = "Mix all ingredients together.",
                                PrepMinutes = 15,
                                CookMinutes = 0,
                                ImagePath = "healthy-recipe-2.jpg",
                                Access = "Premium",
                                AuthorId = admin.Id
                            }
                        );
                        context.SaveChanges();
                    }
                }

                // Seed Faqs
                if (!context.Faqs.Any())
                {
                    context.Faqs.AddRange(
                        new Faq
                        {
                            Question = "How do I subscribe for premium recipes?",
                            Answer = "You can subscribe by going to the pricing page and selecting a plan.",
                            DisplayOrder = 1
                        },
                        new Faq
                        {
                            Question = "Can I submit my own recipes?",
                            Answer = "Yes, you can participate in our contests and submit your recipes.",
                            DisplayOrder = 2
                        }
                    );
                    context.SaveChanges();
                }
            }
        }
    }
}
