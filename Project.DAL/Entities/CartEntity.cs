using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class CartEntity
    {
        #region MyRegion
       public int Id { get; set; }

       public ICollection<Game> Games { get; set; }

       public double TotalPrice { get; set; }

        #endregion





    }
}
