﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Merchanmusic.Enums;

namespace Merchanmusic.Data.Entities
{
    public abstract class User
    {
        [Key]
        public string Id { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public bool State { get; set; } = true;
        public string Role { get; set; }

    }
}
