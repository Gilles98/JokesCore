using JokesCore.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesCore.ViewModels
{
    public class TestJokeViewModel
    {
        //load home
        public List<Joke> Jokes { get; set; }

        public List<string> Emails { get; set; }


        public List<IdentityUser> Gebruikers { get; set; }

        //create joke

        public Joke NewJoke { get; set; }
    }
}
