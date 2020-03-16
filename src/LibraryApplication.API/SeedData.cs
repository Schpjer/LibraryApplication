using Bogus;
using LibraryApplication.Domain.AggregateModel.LibrayAggregate;
using LibraryApplication.Infastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryApplication.API
{
    public class SeedData
    {
        public async static void EnsureSeedData(string connectionString)
        {
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddDbContext<LibraryContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });



            using (var serviceProvider = services.BuildServiceProvider())
            {
                using (var scope = serviceProvider.GetRequiredService<IServiceScopeFactory>().CreateScope())
                {
                    var context = scope.ServiceProvider.GetService<LibraryContext>();
                    context.Database.EnsureCreated();

                    var categories = scope.ServiceProvider.GetServices<Category>();
                    if (!categories.Any())
                    {    
                        var categoryList = new[] { "Historical fiction", "Horror", "Mystery", "Paranormal romance" };
                        var seedCategory = new Faker<Category>()
                            .StrictMode(false)
                            .RuleFor(f => f.CategoryName, p => p.PickRandom(categoryList));

                        var categoryData = seedCategory.Generate(100);
                        context.AddRange(categoryData);
                        context.SaveChanges();

                    }
                    var books = scope.ServiceProvider.GetServices<Book>();
                    if (!books.Any())
                    {
                        var categoryListItems = await context.Categories.ToListAsync();
                        int listCount = categoryListItems.Count();
                        var authors = new[] { "Ernst Hemingway", "Mark Twain", "J.K Rowling", "Charles Dickens" };
                        var titles = new[] { "title1", "title2", "title3", "title4" };
                        var seedBooks = new Faker<Book>()
                            .StrictMode(false)
                            .RuleFor(f => f.Author, p => p.PickRandom(authors))
                            .RuleFor(f => f.Title, p => p.PickRandom(titles))
                            .RuleFor(f => f.Category, p => p.PickRandom(categoryListItems))
                            .RuleFor(f => f.Pages, p => p.PickRandom(1, 1000));

                        var bookData = seedBooks.Generate(100);
                        context.AddRange(bookData);
                        context.SaveChanges();

                        var referenceBooks = scope.ServiceProvider.GetServices<ReferenceBook>();
                       
                    }
                    if (true)
                    {
                        var categoryListItems2 = await context.Categories.ToListAsync();
                        int listCount2 = categoryListItems2.Count();
                        var authors2 = new[] { "Ernst Hemingway", "Mark Twain", "J.K Rowling", "Charles Dickens" };
                        var titles2 = new[] { "title1", "title2", "title3", "title4" };
                        var seedBooks2 = new Faker<ReferenceBook>()
                            .StrictMode(false)
                            .RuleFor(f => f.Author, p => p.PickRandom(authors2))
                            .RuleFor(f => f.Title, p => p.PickRandom(titles2))
                            .RuleFor(f => f.Category, p => p.PickRandom(categoryListItems2))
                            .RuleFor(f => f.Pages, p => p.PickRandom(1, 1000));

                        var referenceBookData = seedBooks2.Generate(100);
                        context.AddRange(referenceBookData);
                        context.SaveChanges();

                    }

                }
            }
        }
    }
}
