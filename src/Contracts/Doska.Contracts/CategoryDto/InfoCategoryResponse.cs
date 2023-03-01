using Doska.Contracts.SubCategoryDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.Contracts.CategoryDto
{
    public class InfoCategoryResponse
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public ICollection<InfoSubCategoryResponse> Subcategories { get; set; }
    }
}
