using react_net_store_database.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace react_net_store_core.DTO
{
    public class UserDTO
    {
        public string Username { get; set; }
        public string Token { get; set; }
        public bool IsAdmin { get; set; }
        public int CartId { get; set; }

        public UserDTO() { }

        public UserDTO(User u)
        {
            Username = u.Username;
        }

        // type conversion from Review into ReviewDTO
        public static explicit operator UserDTO(User u) => new UserDTO(u);
    }
}
