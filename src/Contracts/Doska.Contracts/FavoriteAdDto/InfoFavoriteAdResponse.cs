using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.Contracts.FavoriteAdDto
{
    public class InfoFavoriteAdResponse
    {
        public Guid UserId { get; set; }

        public Guid AdId { get; set; }
    }
}
