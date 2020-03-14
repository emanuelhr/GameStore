using Project.Model.Common;
using System;
using System.Collections.Generic;

namespace Project.Model
{
    public interface IGame
    {
         int Id { get; set; }
         string Name { get; set; }

         IDeveloper Developer { get; set; }

         DateTime? ReleaseDate { get; set; }

         ICollection<IGameGenre> Genre { get; set; }

         double Price { get; set; }
    }
}