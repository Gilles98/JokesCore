using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JokesCore.Models
{
    public class JokeCategorie
    {
        public int Id { get; set; }

        [ForeignKey("Joke")]
        public int JokeId { get; set; }

        [ForeignKey("Categorie")]
        public int CategorieId { get; set; }

        //navigatie

        public Categorie Categorie { get; set; }
        public Joke Joke { get; set; }
    }
}
