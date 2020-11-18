using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

#nullable disable

namespace BlazorMessenger.Models
{
    [Table("User")]
    [Index(nameof(Username), Name = "UK_USERNAME", IsUnique = true)]
    [Index(nameof(Username), Name = "USERNAME_IDX")]
    public partial class User
    {
        public User()
        {
            FollowerFollowerNavigations = new HashSet<Follower>();
            FollowerUsers = new HashSet<Follower>();
            Messages = new HashSet<Message>();
        }

        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(30)]
        public string Username { get; set; }
        [Required]
        [StringLength(30)]
        public string Password { get; set; }
        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(30)]
        public string LastName { get; set; }
        public int IsPublic { get; set; }

        [InverseProperty(nameof(Follower.FollowerNavigation))]
        public virtual ICollection<Follower> FollowerFollowerNavigations { get; set; }
        [InverseProperty(nameof(Follower.User))]
        public virtual ICollection<Follower> FollowerUsers { get; set; }
        [InverseProperty(nameof(Message.Composer))]
        public virtual ICollection<Message> Messages { get; set; }
    }
}
