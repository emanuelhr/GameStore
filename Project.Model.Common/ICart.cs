using System.Collections.Generic;

namespace Project.Model
{
    public interface ICart
    {
        int Id { get; set; }

        IList<IGame> Games { get; set; }

        double TotalPrice { get; set; }

    }
}