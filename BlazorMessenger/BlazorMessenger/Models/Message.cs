﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BlazorMessenger.Models
{
    [Table("Message")]
    public partial class Message
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Column("ComposerID")]
        public int ComposerId { get; set; }
        [Column("ReplyToID")]
        public int ReplyToId { get; set; }
        [Required]
        [StringLength(200)]
        public string Text { get; set; }
        [Required]
        [StringLength(70)]
        public string ComposerName { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateTime { get; set; }

        [ForeignKey(nameof(ComposerId))]
        [InverseProperty(nameof(User.Messages))]
        public virtual User Composer { get; set; }
    }
}
