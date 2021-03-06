﻿using Project.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.DAL.Entities
{
    public class DeveloperEntity
    {

        #region Properties
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [DataType("varchar")]
        public string Name { get; set; }

        [Required]
        [MaxLength(50)]
        [DataType("varchar")]
        public string Headquarters { get; set; }

        public ICollection<GameEntity> Games { get; private set; }

        #endregion

        public override string ToString()
        {
            return Name;
        }

    }
}
