using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class Game : IGame
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IDeveloper Developer { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public ICollection<IGameGenre> Genre { get; set; }

        public double Price { get; set; }
    }
}
