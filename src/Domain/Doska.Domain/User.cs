﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Doska.Domain
{
    public class User : Microsoft.AspNetCore.Identity.IdentityUser
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Region { get; set; }

        public ICollection<Ad> Ads { get; set; }

        public ICollection<FavoriteAd> FavoriteAds { get; set; }

        public ICollection<Chat> Chats { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public string KodBase64 { get; set; }

    }
}
