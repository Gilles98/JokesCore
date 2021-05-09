using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JokesCore.Models
{
    public class Categorie
    {
        public int Id { get; set; }

        public string Naam { get; set; }

        //navigatie
        public List<JokeCategorie> jokeCategories { get; set; }
    }
}
