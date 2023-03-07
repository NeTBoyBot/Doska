using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.Domain
{
    public class Ad
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public Category Subcategory { get; set; }

        public User User { get; set; }

        public decimal Price { get; set; }

        public Guid UserId { get; set; }
        
        public Guid? СategoryId { get; set; }

        public DateTime CreateTime { get; set; }
    }
}
