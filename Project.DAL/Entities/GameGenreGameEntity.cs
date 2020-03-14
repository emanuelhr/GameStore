using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class GameGenreGameEntity
    {
        public int GameEntityId { get; set; }
        public GameEntity GameEntity { get; set; }

        public int GameGenreEntityId { get; set; }
        public GameGenreEntity GameGenreEntity { get; set; }
    }
}
