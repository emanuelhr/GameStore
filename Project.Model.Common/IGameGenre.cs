using System.Collections.Generic;

namespace Project.Model.Common
{
    public interface IGameGenre
    {
        int Id { get; set; }

        string Genre { get; set; }

        ICollection<IGame> Games { get; set; }
    }
}