using Project.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class Developer : IDeveloper
    {
        public int Id { get; set; }
        public string Name { get ; set ; }
        public string Headquarters { get ; set ; }

        public ICollection<IGame> Games { get;  set; }
    }
}
