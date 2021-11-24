using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _57blocks.Model.Models
{
    public class PokemonModel
    {
        public decimal PokemonId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string TypePrincipal { get; set; }
        public string TypeAlternate { get; set; }
        public int Level { get; set; }
        public decimal PC { get; set; }
    }
}
