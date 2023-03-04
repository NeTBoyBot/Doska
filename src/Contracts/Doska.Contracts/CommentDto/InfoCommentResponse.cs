using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.Contracts.CommentDto
{
    public class InfoCommentResponse
    {
        public Guid Id { get; set; }

        public Guid UserId { get; set; }

        public string Containment { get; set; }
    }
}
