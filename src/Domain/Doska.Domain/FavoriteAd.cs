using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.Domain
{
    public class FavoriteAd
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public Guid AdId { get; set; }

        public Ad Ad { get; set; }
    }
}
