using System.Collections.Generic;

namespace Project.Model
{
    public interface ICart
    {
        int Id { get; set; }

        ICollection<IGame> Games { get; set; }

        double TotalPrice { get; }

    }
}