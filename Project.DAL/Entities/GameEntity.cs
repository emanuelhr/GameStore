using Project.Model;
using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class GameEntity
    {
        #region Properties

        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public DeveloperEntity Developer { get; set; }
        
        public int DeveloperId { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [Required]

        public ICollection<GameGenreGameEntity> GameGenre { get; set; }
        [Required]
        public double Price { get; set; }

        #endregion

        public override string ToString()
        {
            return Name;

        }
    }
}
