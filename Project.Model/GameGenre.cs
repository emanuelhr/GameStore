using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Project.Model
{
    public class GameGenre : IGameGenre
    {
        public int Id { get; set; }

        public string Genre { get; set; }

        public ICollection<IGame> Games { get; set; }
    }
}
