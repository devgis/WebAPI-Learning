﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class MoviesController : ApiController
    {
        private static List<Movie> movies = new List<Movie>();
        static MoviesController()
        {
            Movie movie1 = new Movie
            {
                Id = new Guid("B4E0BC49-568D-402B-ACF0-37B65008723F"),
                Name = "Scent of a Woman",
                Genres = new string[] { "Drama" },
                Starring = new string[] { "Al Pacino", "Chris O'Donnell" },
                Director = "Martin Brest",
                ReleaseDate = new DateTime(1992, 7, 1),
                Language     = "en",
                Story = "Frank is a retired Lt Col in the US army. He's blind and impossible to get along with. Charlie is at school and is looking forward to going to university; to help pay for a trip home for Christmas, he agrees to look after Frank over thanksgiving. Frank's niece says ..."
            };
            Movie movie2 = new Movie
            {
                Id = new Guid("315C1251-4ECC-4D4C-9598-6CF5714A68B8"),
                Name = "Donnie Brasco",
                Genres = new string[] { "Biography", "Crime", "Drama", "Thriller" },
                Starring = new string[] { "Al Pacino", "Johnny Depp", "Michael Madsen", "Bruno Kirby", "James Russo" },
                Director = "Mike Newell",
                ReleaseDate = new DateTime(1997, 9, 1),
                Language = "en",
                Story = "An FBI undercover agent infilitrates the mob and finds himself identifying more with the mafia life to the expense of his regular one..."
            };
            movies.Add(movie1);
            movies.Add(movie2);
        }

        [HttpGet]
        [Route("api/movies/language/{language?}")]
        public IEnumerable<Movie> GetMoviesByLanguage(string language = "en")
        {
            return from movie in movies
                   where string.Compare(movie.Language, language, true) == 0
                   select movie;
        }
    }
}