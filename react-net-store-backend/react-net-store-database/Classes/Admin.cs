using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace react_net_store_database.Classes
{
    public class Admin // a database object linked to one admin user
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
