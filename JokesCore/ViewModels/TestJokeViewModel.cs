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
        public Joke Joke { get; set; }

        public string Email { get; set; }
    }
}
