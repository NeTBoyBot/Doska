﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.Contracts.AdDto
{
    public class CreateOrUpdateAdRequest
    {
        public string Name { get; set; }
        
        public Guid UserId { get; set; }

        public Guid SubcategoryId { get; set; }

        public string Description { get; set; } 

        public decimal Price { get; set; }

        public bool PossibilityOfDelivery { get; set; }
    }
}
