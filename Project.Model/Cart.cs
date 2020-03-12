using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class Cart : ICart
    {
        public int Id { get; set; }

        public IList<IGame> Games { get; set; }

        public double TotalPrice { get; set; }

    }
}
