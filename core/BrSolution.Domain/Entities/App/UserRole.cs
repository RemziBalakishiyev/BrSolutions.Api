using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrSolution.Domain.Entities.App
{
    public class UserRole : IEntity
    {
        public int UserId { get; set; }

        public User User { get; set; }

        public int RoleId { get; set; }

        public Role Role { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
