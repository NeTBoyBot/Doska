using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Doska.Domain
{
    public class Comment
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }  

        public string Containment { get; set; }
    }
}
