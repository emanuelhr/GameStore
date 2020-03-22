using Project.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class GameGenreEntity
    {

        public GameGenreEntity()
        {
            GameGenre = new Collection<GameGenreGameEntity>();
        }

        #region Properties
        public int Id { get; set; }

        [Required]
        [MaxLength(10)]
        [DataType("VARCHAR")]

        public string Genre { get; set; }

        
        public ICollection<GameGenreGameEntity> GameGenre { get; set; }

        #endregion

    }
}
