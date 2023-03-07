using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.Contracts.CategoryDto
{
    public class CreateCategoryRequest
    {
        public Guid? ParentId { get; set; }

        public string Name { get; set; }
    }
}
