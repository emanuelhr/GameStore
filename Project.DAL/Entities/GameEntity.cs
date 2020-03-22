using Project.Model;
using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class GameEntity
    {

        public GameEntity()
        {
            GameGenre = new Collection<GameGenreGameEntity>();
            CartsGames = new Collection<CartsGamesEntity>();
        }


        #region Properties

        public int Id { get; set; }

        [Required]
        [DataType("varchar")]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public DeveloperEntity Developer { get; set; }
        
        public int DeveloperId { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [Required]

        public ICollection<GameGenreGameEntity> GameGenre { get; set; }
        [Required]
        [DataType("smallmoney")]
        public double Price { get; set; }

        public ICollection<CartsGamesEntity> CartsGames { get; set; }
        #endregion

        public override string ToString()
        {
            return Name;

        }
    }
}
