using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MvcMovie.Data;
using System;
using System.Linq;

namespace MvcMovie.Models;

public static class SeedData
{
    public static void Initialize(IServiceProvider serviceProvider)
    {
        using (var context = new MvcMovieContext(
            serviceProvider.GetRequiredService<
                DbContextOptions<MvcMovieContext>>()))
        {
            // Look for any movies.
            if (context.Movie.Any())
            {
                return;   // DB has been seeded
            }
            context.Movie.AddRange(
                new Movie
                {
                    Title = "Rocky Balboa",
                    ReleaseDate = DateTime.Parse("1989-2-12"),
                    Genre = "Boxing",
                    Rating = "R",
                    Price = 7.99M
                },
                new Movie
                {
                    Title = "Creed ",
                    ReleaseDate = DateTime.Parse("2017-3-13"),
                    Genre = "Boxing",
                    Rating = "R",
                    Price = 8.99M
                },
                new Movie
                {
                    Title = "Creed 2",
                    ReleaseDate = DateTime.Parse("2019-2-23"),
                    Genre = "Boxing",
                    Rating = "R",
                    Price = 9.99M
                },
                new Movie
                {
                    Title = "Forest Gump",
                    ReleaseDate = DateTime.Parse("1999-4-15"),
                    Genre = "Biopic",
                    Rating = "R",
                    Price = 3.99M
                }
            );
            context.SaveChanges();
        }
    }
}