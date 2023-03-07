using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.Domain
{
    public class Category
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Category? ParenCategory { get; set; }

        public Guid? ParenCategoryId { get; set; }

        public ICollection<Category> Subcategories { get; set; }
    }
}
