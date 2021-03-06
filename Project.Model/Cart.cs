﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Model
{
    public class Cart : ICart
    {
        public int Id { get; set; }

        public ICollection<IGame> Games { get; set; }

        public double TotalPrice {


            get
            {

               double price = 0;

                foreach (var game in Games)
                {
                    price += game.Price;

                }
                return price;
            
            }
            
        }

    }
}
