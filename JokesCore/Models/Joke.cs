using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JokesCore.Models
{
    public class Joke
    {
        public int Id { get; set; }

        [ForeignKey("Account")]
        public string AccountId { get; set; }

        public string Bericht { get; set; }

        public int Rating { get; set; }


        //navigatie

        public IdentityUser Account { get; set; }

        public List<JokeCategorie> jokeCategories { get; set; }
    }
}
