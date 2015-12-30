using Repository.Pattern.Ef6;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger.Example.Models
{
    public class User : Entity
    {
        public User()
        {
            this.Roles = new HashSet<Role>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }

        public ICollection<Role> Roles { get; set; }
    }

    public class Role : Entity
    {
        public Role()
        {
            this.Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<User> Users { get; set; }
    }
}
